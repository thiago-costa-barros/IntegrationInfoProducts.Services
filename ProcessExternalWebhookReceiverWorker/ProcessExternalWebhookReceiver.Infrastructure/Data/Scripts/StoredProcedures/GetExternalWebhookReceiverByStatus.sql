CREATE OR ALTER PROCEDURE [IntegrationSchema].[GetExternalWebhookReceiverByStatus]
    @paramStatus INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT [ExternalWebhookReceiverId]
          ,[SourceType]
          ,[Status]
          ,[CompanyId]
          ,[ExternalIdentifier]
          ,[Payload]
          ,[CreationDate]
          ,[UpdateDate]
          ,[CreationUserId]
          ,[UpdateUserId]
          ,[DeletionDate]
      FROM [IntegrationSchema].[ExternalWebhookReceiver]
      WHERE [DeletionDate] IS NULL
            AND [Status] IN (@paramStatus)
      ORDER BY [ExternalWebhookReceiverId] ASC;
END;