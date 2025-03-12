CREATE PROCEDURE [dbo].[SP_GetById_Emprunt]
    @Emprunt_Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Emprunt_Id,
        Jeux_Utilisateur_Id,
        Emprunteur_Id,
        DateEmprunt,
        DateRetour,
        EvaluationPreteur,
        EvaluationEmprunteur
    FROM dbo.Emprunt
    WHERE Emprunt_Id = @Emprunt_Id;
END;
