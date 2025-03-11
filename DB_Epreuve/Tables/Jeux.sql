CREATE TABLE [dbo].[Jeux]
(
	[Jeu_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[Nom] VARCHAR(255) NOT NULL,                
    [Description] VARCHAR(MAX) NOT NULL,                         
    [AgeMin] INT CHECK ([AgeMin] >= 0) NOT NULL,         -- Âge minimum recommandé (doit être >= 0)
    [AgeMax] INT CHECK ([AgeMax] >= [AgeMin]) NOT NULL,  -- Âge maximum recommandé (doit être >= AgeMin)
    [NbJoueurMin] INT CHECK ([NbJoueurMin] > 0) NOT NULL,-- Nombre minimum de joueurs (doit être > 0)
    [NbJoueurMax] INT CHECK ([NbJoueurMax] >= [NbJoueurMin]) NOT NULL, -- Nombre maximum de joueurs (>= NbJoueurMin)
    [DureeMinute] DECIMAL(3, 1) CHECK ([DureeMinute] >= 0),   -- Durée approximative en minutes
    [DateCreation] DATE DEFAULT GETDATE() NOT NULL  -- Date de création de l'enregistrement
    CONSTRAINT PK_Jeux PRIMARY KEY ([Jeu_Id])
)
