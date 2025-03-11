CREATE TABLE [dbo].[Jeux]
(
	[Jeu_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[Nom] VARCHAR(255) NOT NULL,                
    [Description] TEXT,                         
    [AgeMin] INT CHECK ([AgeMin] >= 0),         -- Âge minimum recommandé (doit être >= 0)
    [AgeMax] INT CHECK ([AgeMax] >= [AgeMin]),  -- Âge maximum recommandé (doit être >= AgeMin)
    [NbJoueurMin] INT CHECK ([NbJoueurMin] > 0),-- Nombre minimum de joueurs (doit être > 0)
    [NbJoueurMax] INT CHECK ([NbJoueurMax] >= [NbJoueurMin]), -- Nombre maximum de joueurs (>= NbJoueurMin)
    [DureeMinute] DECIMAL(3, 1) CHECK ([DureeMinute] >= 0),   -- Durée approximative en minutes
    [DateCreation] DATE DEFAULT GETDATE()       -- Date de création de l'enregistrement
)
