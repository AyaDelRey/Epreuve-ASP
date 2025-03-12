CREATE PROCEDURE [dbo].[SP_Get_All_Utilisateur]
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Utilisateur_Id,
        Email,
        Password,
        Pseudo,
        CreatedAt,
        DisabledAt
    FROM dbo.Utilisateur;
END;
