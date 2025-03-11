CREATE PROCEDURE [dbo].[SP_Cloturer_Emprunt]
    @Emprunt_Id UNIQUEIDENTIFIER,             -- L'ID de l'emprunt
    @DateRetour DATE,                         -- La date de retour
    @EvaluationPreteur DECIMAL(2, 1),         -- L'évaluation du prêteur
    @EvaluationEmprunteur DECIMAL(2, 1)       -- L'évaluation de l'emprunteur
AS
BEGIN
    -- Mettre à jour la table Emprunt avec la date de retour et les évaluations
    UPDATE dbo.Emprunt
    SET DateRetour = @DateRetour, 
        EvaluationPreteur = @EvaluationPreteur,
        EvaluationEmprunteur = @EvaluationEmprunteur
    WHERE Emprunt_Id = @Emprunt_Id;

END
