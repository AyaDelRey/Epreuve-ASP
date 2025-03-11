CREATE PROCEDURE [dbo].[SP_Create_Jeu]
@Utilisateur_Id UNIQUEIDENTIFIER,    -- L'ID de l'utilisateur qui ajoute le jeu
    @Nom VARCHAR(255),                    -- Le nom du jeu
    @Description TEXT,                    -- La description du jeu
    @AgeMin INT,                          -- L'âge minimum recommandé pour jouer
    @AgeMax INT,                          -- L'âge maximum recommandé pour jouer
    @NbJoueurMin INT,                     -- Le nombre minimum de joueurs
    @NbJoueurMax INT,                     -- Le nombre maximum de joueurs
    @DureeMinute DECIMAL(3,1),            -- La durée approximative du jeu en minutes
    @Etat VARCHAR(50)                     -- L'état du jeu (Neuf, Abimé, Incomplet)
AS
BEGIN
    -- Insérer le jeu dans la table 'Jeux' avec l'utilisateur associé
    DECLARE @Jeu_Id UNIQUEIDENTIFIER = NEWID(); -- Créer un nouvel ID pour le jeu
    INSERT INTO dbo.Jeux 
        (Jeu_Id, Nom, Description, AgeMin, AgeMax, NbJoueurMin, NbJoueurMax, DureeMinute, DateCreation)
    VALUES 
        (@Jeu_Id, @Nom, @Description, @AgeMin, @AgeMax, @NbJoueurMin, @NbJoueurMax, @DureeMinute, GETDATE());

    -- Ajouter ce jeu à la collection de l'utilisateur dans la table 'Jeux_Utilisateur'
    INSERT INTO dbo.Jeux_Utilisateur 
        (Utilisateur_Id, Jeu_Id, Etat, DateAcquisition)
    VALUES 
        (@Utilisateur_Id, @Jeu_Id, @Etat, GETDATE());
    
    -- Retourner l'ID du jeu créé pour référence
    SELECT @Jeu_Id AS JeuId;
END;
