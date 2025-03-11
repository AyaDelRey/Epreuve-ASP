CREATE TABLE dbo.Emprunt (
    [Emprunt_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Jeux_Utilisateur_Id] UNIQUEIDENTIFIER NOT NULL,  -- Référence vers l'exemplaire spécifique du jeu possédé par l'utilisateur
    [Emprunteur_Id] UNIQUEIDENTIFIER NOT NULL,        -- L'utilisateur qui emprunte le jeu
    [DateEmprunt] DATE NOT NULL,                      
    [DateRetour] DATE NULL,                           
    [EvaluationPreteur] DECIMAL(2, 1) CHECK ([EvaluationPreteur] BETWEEN 0 AND 5) NULL,
    [EvaluationEmprunteur] DECIMAL(2, 1) CHECK ([EvaluationEmprunteur] BETWEEN 0 AND 5) NULL,
    
    CONSTRAINT FK_Emprunt_Jeux_Utilisateur FOREIGN KEY ([Jeux_Utilisateur_Id]) REFERENCES dbo.Jeux_Utilisateur([Jeux_Utilisateur_Id]) ON DELETE CASCADE,
    CONSTRAINT FK_Emprunt_Utilisateur FOREIGN KEY ([Emprunteur_Id]) REFERENCES dbo.Utilisateur([Utilisateur_Id]) ON DELETE CASCADE
);

