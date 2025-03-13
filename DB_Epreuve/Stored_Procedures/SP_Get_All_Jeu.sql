CREATE PROCEDURE [dbo].[SP_Get_All_Jeu]
AS
BEGIN
    SET NOCOUNT ON;

    -- Sélection de toutes les colonnes nécessaires
    SELECT 
        Jeu_Id,                -- Identifiant du jeu
        Nom,                   -- Nom du jeu
        Description,           -- Description du jeu
        AgeMin,                -- Âge minimum recommandé
        AgeMax,                -- Âge maximum recommandé
        NbJoueurMin,           -- Nombre minimum de joueurs
        NbJoueurMax,           -- Nombre maximum de joueurs
        DureeMinute,           -- Durée approximative en minutes
        DateCreation           -- Date de création du jeu
    FROM dbo.Jeux;
END;


