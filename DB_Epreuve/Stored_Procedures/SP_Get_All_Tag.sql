CREATE PROCEDURE [dbo].[SP_Get_All_Tag]
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Tag_Id,
        Nom
    FROM dbo.Tag;
END;
