using CommonSolution.Database.Interfaces;
using CommonSolution.Entities.Common;
using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.IntegrationSchema;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProcessExternalWebhookReceiver.Application.Interfaces;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;

namespace ProcessExternalWebhookReceiver.Application.Worker
{
    public class ExecuteService : IExecuteService
    {
        private readonly ILogger<ExecuteService> _logger;
        private readonly IExternalWebhookReceiverRepository _externalWebhookReceiverRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<DefaultUserService> _defaultUser;
        private readonly IProcessExternalWebhookReceiver _processExternalWebhookReceiver;
        public ExecuteService(
            ILogger<ExecuteService> logger,
            IExternalWebhookReceiverRepository externalWebhookReceiverRepository,
            IUnitOfWork unitOfWork,
            IOptions<DefaultUserService> defaultUser,
            IProcessExternalWebhookReceiver processExternalWebhookReceiver)
        {
            _logger = logger;
            _externalWebhookReceiverRepository = externalWebhookReceiverRepository;
            _unitOfWork = unitOfWork;
            _defaultUser = defaultUser;
            _processExternalWebhookReceiver = processExternalWebhookReceiver;
        }
        public async Task ExecuteAsync(int batchSize, CancellationToken cancellationToken)
        {
            List<ExternalWebhookReceiver> externalWebhookReceivers = await _externalWebhookReceiverRepository.GetExternalWebhookReceiverByStatusAsync(ExternalWebhookReceiverStatus.Created, cancellationToken);
            List<ExternalWebhookReceiver> externalWebhookReceiversError = await _externalWebhookReceiverRepository.GetExternalWebhookReceiverByStatusAsync(ExternalWebhookReceiverStatus.Error, cancellationToken);
            
            externalWebhookReceivers.AddRange(externalWebhookReceiversError);
            externalWebhookReceivers = externalWebhookReceivers.Take(batchSize).ToList();

            foreach (var externalWebhookReceiver in externalWebhookReceivers)
            {
                try
                {
                    await _unitOfWork.BeginTransaction(cancellationToken);

                    await _externalWebhookReceiverRepository.UpdateExternalWebhookReceiverStatusById(
                        externalWebhookReceiver.ExternalWebhookReceiverId,
                        ExternalWebhookReceiverStatus.Pending,
                        _defaultUser.Value.DefaultUserId,
                        cancellationToken);

                    await _processExternalWebhookReceiver.ProcessExternalWebhookReceiver(externalWebhookReceiver, cancellationToken);

                    await _unitOfWork.Commit(cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing ExternalWebhookReceiverId {Id}", externalWebhookReceiver.ExternalWebhookReceiverId);

                    try
                    {
                        await _unitOfWork.Rollback(cancellationToken);

                    }
                    catch (Exception rollbackEx)
                    {
                        _logger.LogError(rollbackEx, "Error rolling back transaction for ExternalWebhookReceiverId {Id}", externalWebhookReceiver.ExternalWebhookReceiverId);
                    }

                    try
                    {
                        await _externalWebhookReceiverRepository.UpdateExternalWebhookReceiverStatusById(
                            externalWebhookReceiver.ExternalWebhookReceiverId,
                            ExternalWebhookReceiverStatus.Error,
                            _defaultUser.Value.DefaultUserId,
                            cancellationToken);
                    }
                    catch (Exception updateEx)
                    {
                        _logger.LogError(updateEx, "Error updating status for ExternalWebhookReceiverId {Id} to Error", externalWebhookReceiver.ExternalWebhookReceiverId);
                    }
                }
            }

            _logger.LogInformation("Executing batch of size {BatchSize} at {Time}", batchSize, DateTimeOffset.Now);
            await Task.CompletedTask;
        }
    }
}