CREATE PROCEDURE [dbo].[SP_Create_Tag]
    @Nom NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO dbo.Tag (Nom)
    VALUES (@Nom);

END;

