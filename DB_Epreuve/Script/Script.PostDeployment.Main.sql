/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
-- Insérer des utilisateurs avec un mot de passe haché
INSERT INTO dbo.Utilisateur (Utilisateur_Id, Email, Password, Pseudo, CreatedAt)
VALUES 
    (NEWID(), 'john.doe@example.com', HASHBYTES('SHA2_512', '123'), 'JohnDoe', GETDATE()),
    (NEWID(), 'jane.smith@example.com', HASHBYTES('SHA2_512', '123'), 'JaneSmith', GETDATE());


-- Ajout des jeux
INSERT INTO dbo.Jeux (Jeu_Id, Nom, Description, AgeMin, AgeMax, NbJoueurMin, NbJoueurMax, DureeMinute, DateCreation)
VALUES 
    (NEWID(), 'Catan', 'Un jeu de stratégie pour construire des colonies.', 10, 99, 3, 4, 60.0, GETDATE()),
    (NEWID(), 'Dixit', 'Un jeu de cartes narratif et créatif.', 8, 99, 3, 6, 30.0, GETDATE()),
    (NEWID(), 'Carcassonne', 'Un jeu de placement de tuiles et de contrôle de territoire.', 7, 99, 2, 5, 45.0, GETDATE());

-- Ajout des tags
INSERT INTO dbo.Tag (Tag_Id, Nom)
VALUES 
    (NEWID(), 'Stratégie'),
    (NEWID(), 'Familial'),
    (NEWID(), 'Cartes'),
    (NEWID(), 'Créativité'),
    (NEWID(), 'Coopératif'),
    (NEWID(), 'Equipe'),
    (NEWID(), 'Dés'),
    (NEWID(), 'Plateau'),
    (NEWID(), 'Argent');

-- Lier les jeux aux tags
DECLARE @JeuId1 UNIQUEIDENTIFIER = (SELECT TOP 1 Jeu_Id FROM dbo.Jeux WHERE Nom = 'Catan');
DECLARE @JeuId2 UNIQUEIDENTIFIER = (SELECT TOP 1 Jeu_Id FROM dbo.Jeux WHERE Nom = 'Dixit');
DECLARE @JeuId3 UNIQUEIDENTIFIER = (SELECT TOP 1 Jeu_Id FROM dbo.Jeux WHERE Nom = 'Carcassonne');

INSERT INTO dbo.Jeux_Tag (Jeu_Tag_Id, Jeu_Id, Tag_Id)
VALUES 
    (NEWID(), @JeuId1, (SELECT TOP 1 Tag_Id FROM dbo.Tag WHERE Nom = 'Stratégie')),
    (NEWID(), @JeuId1, (SELECT TOP 1 Tag_Id FROM dbo.Tag WHERE Nom = 'Plateau')),
    (NEWID(), @JeuId2, (SELECT TOP 1 Tag_Id FROM dbo.Tag WHERE Nom = 'Cartes')),
    (NEWID(), @JeuId2, (SELECT TOP 1 Tag_Id FROM dbo.Tag WHERE Nom = 'Créativité')),
    (NEWID(), @JeuId3, (SELECT TOP 1 Tag_Id FROM dbo.Tag WHERE Nom = 'Stratégie')),
    (NEWID(), @JeuId3, (SELECT TOP 1 Tag_Id FROM dbo.Tag WHERE Nom = 'Familial')),
    (NEWID(), @JeuId3, (SELECT TOP 1 Tag_Id FROM dbo.Tag WHERE Nom = 'Coopératif'));

-- Ajout de la collection d'utilisateurs
DECLARE @UserId1 UNIQUEIDENTIFIER = (SELECT TOP 1 Utilisateur_Id FROM dbo.Utilisateur WHERE Pseudo = 'JohnDoe');
DECLARE @UserId2 UNIQUEIDENTIFIER = (SELECT TOP 1 Utilisateur_Id FROM dbo.Utilisateur WHERE Pseudo = 'JaneSmith');

INSERT INTO dbo.Jeux_Utilisateur (Jeux_Utilisateur_Id, Utilisateur_Id, Jeu_Id, DateAcquisition, Etat)
VALUES 
    (NEWID(), @UserId1, @JeuId1, GETDATE(), 'Neuf'),
    (NEWID(), @UserId2, @JeuId2, GETDATE(), 'Abimé'),
    (NEWID(), @UserId1, @JeuId3, GETDATE(), 'Incomplet');

-- Ajout d'emprunts
DECLARE @JeuxUtilisateurId1 UNIQUEIDENTIFIER = (SELECT TOP 1 Jeux_Utilisateur_Id FROM dbo.Jeux_Utilisateur WHERE Utilisateur_Id = @UserId1 AND Jeu_Id = @JeuId1);
DECLARE @JeuxUtilisateurId2 UNIQUEIDENTIFIER = (SELECT TOP 1 Jeux_Utilisateur_Id FROM dbo.Jeux_Utilisateur WHERE Utilisateur_Id = @UserId2 AND Jeu_Id = @JeuId2);

INSERT INTO dbo.Emprunt (Emprunt_Id, Jeux_Utilisateur_Id, Emprunteur_Id, DateEmprunt)
VALUES 
    (NEWID(), @JeuxUtilisateurId1, @UserId2, GETDATE()),
    (NEWID(), @JeuxUtilisateurId2, @UserId1, GETDATE());