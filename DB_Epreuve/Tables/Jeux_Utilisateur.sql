CREATE TABLE [dbo].[Jeux_Utilisateur]
(
	[Jeux_Utilisateur_Id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY, -- Identifiant unique pour la liaison
    [Utilisateur_Id] UNIQUEIDENTIFIER NOT NULL,         -- Référence au GUID de l'utilisateur
    [Jeu_Id] UNIQUEIDENTIFIER NOT NULL,                -- Référence au GUID du jeu
    [DateAcquisition] DATE DEFAULT GETDATE(),-- Optionnel : date d'acquisition
    [Etat] VARCHAR(20) NOT NULL,
    CONSTRAINT FK_Utilisateur_Jeux_Utilisateur FOREIGN KEY ([Utilisateur_Id]) REFERENCES dbo.Utilisateur([Utilisateur_Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_Utilisateur_Jeux_Jeux FOREIGN KEY ([Jeu_Id]) REFERENCES dbo.Jeux([Jeu_Id]) ON DELETE CASCADE,
    CONSTRAINT UQ_Utilisateur_Jeux UNIQUE ([Utilisateur_Id], [Jeu_Id]),
    CONSTRAINT CK_Etat_Jeu CHECK ([Etat] IN ('Neuf', 'Abimé', 'Incomplet')),
)
