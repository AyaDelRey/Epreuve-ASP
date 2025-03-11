CREATE PROCEDURE [dbo].[SP_Update_Jeu]
    @Utilisateur_Id UNIQUEIDENTIFIER,    -- L'ID de l'utilisateur qui modifie son exemplaire
    @Jeu_Id UNIQUEIDENTIFIER,             -- L'ID du jeu à modifier
    @Etat VARCHAR(50)                     -- Nouveau statut de l'exemplaire (Neuf, Abimé, Incomplet)
AS
BEGIN
    -- Mettre à jour l'état du jeu dans la table 'Jeux_Utilisateur'
    UPDATE dbo.Jeux_Utilisateur
    SET 
        Etat = @Etat
    WHERE 
        Utilisateur_Id = @Utilisateur_Id
        AND Jeu_Id = @Jeu_Id;
END;