CREATE PROCEDURE [dbo].[SP_Get_Jeux_Utilisateur]
    @Utilisateur_Id UNIQUEIDENTIFIER  -- L'ID de l'utilisateur pour lequel on récupère les jeux
AS
BEGIN
    -- Sélectionner tous les jeux appartenant à l'utilisateur
    SELECT 
        ju.Jeux_Utilisateur_Id,   -- L'identifiant unique de la relation entre l'utilisateur et le jeu
        j.Nom,                     -- Le nom du jeu
        j.Description,              -- La description du jeu
        j.AgeMin,                   -- L'âge minimum recommandé pour le jeu
        j.AgeMax,                   -- L'âge maximum recommandé pour le jeu
        j.NbJoueurMin,              -- Le nombre minimum de joueurs pour le jeu
        j.NbJoueurMax,              -- Le nombre maximum de joueurs pour le jeu
        j.DureeMinute,              -- La durée approximative d'une partie du jeu en minutes
        ju.Etat,                    -- L'état du jeu (Neuf, Abimé, Incomplet)
        ju.DateAcquisition          -- La date d'acquisition du jeu
    FROM dbo.Jeux_Utilisateur ju
    INNER JOIN dbo.Jeux j
        ON ju.Jeu_Id = j.Jeu_Id
    WHERE ju.Utilisateur_Id = @Utilisateur_Id;
END;
