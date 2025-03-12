CREATE PROCEDURE [dbo].[SP_GetById_Tag]
    @Tag_Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Tag_Id,
        Nom
    FROM dbo.Tag
    WHERE Tag_Id = @Tag_Id;
END;
