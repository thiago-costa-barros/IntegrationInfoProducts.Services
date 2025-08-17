CREATE OR ALTER PROCEDURE [IntegrationSchema].[UpdateExternalWebhookReceiverStatusById]
    @paramExternalWebhookReceiverId INT,
    @paramStatus INT,
    @paramUserId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [IntegrationSchema].[ExternalWebhookReceiver]
       SET [Status] = @paramStatus
          ,[UpdateDate] = GETUTCDATE()
          ,[UpdateUserId] = @paramUserId
     WHERE [ExternalWebhookReceiverId] = @paramExternalWebhookReceiverId
END;