CREATE PROCEDURE [dbo].[SP_Get_Jeux_By_Tag]
    @Tag_Nom VARCHAR(100)  -- Le nom du tag pour lequel on recherche les jeux
AS
BEGIN
    -- Sélectionner tous les jeux associés au tag spécifié
    SELECT 
        j.Jeu_Id,                  -- L'ID du jeu
        j.Nom,                     -- Le nom du jeu
        j.Description,             -- La description du jeu
        j.AgeMin,                  -- L'âge minimum recommandé pour le jeu
        j.AgeMax,                  -- L'âge maximum recommandé pour le jeu
        j.NbJoueurMin,             -- Le nombre minimum de joueurs pour le jeu
        j.NbJoueurMax,             -- Le nombre maximum de joueurs pour le jeu
        j.DureeMinute,             -- La durée approximative d'une partie du jeu en minutes
        t.Nom AS Tag_Nom           -- Le nom du tag associé
    FROM dbo.Jeux j
    INNER JOIN dbo.Jeux_Tag jt
        ON j.Jeu_Id = jt.Jeu_Id
    INNER JOIN dbo.Tag t
        ON jt.Tag_Id = t.Tag_Id
    WHERE t.Nom LIKE '%' + @Tag_Nom + '%';  -- Utiliser un LIKE pour rechercher des jeux par nom de tag
END;

