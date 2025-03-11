CREATE TABLE dbo.Emprunt (
    [Emprunt_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Jeu_Id] UNIQUEIDENTIFIER NOT NULL,                                  
    [Emprunteur_Id] UNIQUEIDENTIFIER NOT NULL,                          
    [DateEmprunt] DATE NOT NULL,                          
    [DateRetour] DATE NULL,                                
    [EvaluationPreteur] DECIMAL(2, 1) CHECK ([EvaluationPreteur] BETWEEN 0 AND 5),
    [EvaluationEmprunteur] DECIMAL(2, 1) CHECK ([EvaluationEmprunteur] BETWEEN 0 AND 5),
    CONSTRAINT FK_Emprunt_Jeu FOREIGN KEY ([Jeu_Id]) REFERENCES dbo.Jeux([Jeu_Id]) ON DELETE CASCADE,
    CONSTRAINT FK_Emprunt_Utilisateur FOREIGN KEY ([Emprunteur_Id]) REFERENCES dbo.Utilisateur([Utilisateur_Id]) ON DELETE CASCADE
)
