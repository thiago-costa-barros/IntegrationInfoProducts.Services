using CommonSolution.Entities.Common.Enums;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart
{
    public class HotmartOperationProcessFactory
    {
        private readonly Dictionary<OperationType, IHotmartOperationProcessFactory> _processors;
        public HotmartOperationProcessFactory(IEnumerable<IHotmartOperationProcessFactory> processors)
        {
            _processors = processors.ToDictionary(p => p.OperationType, p => p);
        }
        public IHotmartOperationProcessFactory CreateInstance(OperationType type)
        {
            if (!_processors.TryGetValue(type, out var processor))
                throw new InvalidOperationException($"Nenhum processador encontrado para o tipo {type}");

            return processor;
        }
    }
}
