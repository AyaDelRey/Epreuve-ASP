CREATE PROCEDURE [dbo].[SP_Get_All_Jeu]
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Jeu_Id,
        Nom,
        Description
    FROM dbo.Jeux;
END;

