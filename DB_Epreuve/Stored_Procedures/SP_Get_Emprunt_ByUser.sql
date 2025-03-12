CREATE PROCEDURE [dbo].[SP_Get_Emprunt_ByUser]
    @Utilisateur_Id UNIQUEIDENTIFIER  -- L'ID de l'utilisateur pour lequel on récupère les emprunts
AS
BEGIN
    -- Sélectionner tous les emprunts associés à l'utilisateur
    SELECT 
        e.Emprunt_Id,              -- L'identifiant unique de l'emprunt
        e.Jeux_Utilisateur_Id,     -- L'identifiant de la relation entre l'utilisateur et le jeu
        e.Emprunteur_Id,           -- L'utilisateur qui emprunte le jeu
        e.DateEmprunt,             -- La date de l'emprunt
        e.DateRetour,              -- La date de retour prévue ou effective
        e.EvaluationPreteur,       -- L'évaluation donnée par le prêteur
        e.EvaluationEmprunteur     -- L'évaluation donnée par l'emprunteur
    FROM dbo.Emprunt e
    WHERE e.Emprunteur_Id = @Utilisateur_Id;  -- On filtre par l'ID de l'emprunteur
END;
