CREATE PROCEDURE [dbo].[SP_Delete_Jeu]
    @Utilisateur_Id UNIQUEIDENTIFIER,   -- L'ID de l'utilisateur qui veut supprimer l'exemplaire
    @Jeu_Id UNIQUEIDENTIFIER            -- L'ID du jeu (identifiant du jeu dans la collection de l'utilisateur)
AS
BEGIN
    -- Suppression de l'exemplaire du jeu de la table 'Jeux_Utilisateur' 
    DELETE FROM dbo.Jeux_Utilisateur
    WHERE Jeu_Id = @Jeu_Id 
      AND Utilisateur_Id = @Utilisateur_Id;

END;
