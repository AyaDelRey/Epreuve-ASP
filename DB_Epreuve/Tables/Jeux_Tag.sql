CREATE TABLE [dbo].[Jeux_Tag]
(
    [Jeu_Tag_Id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    [Jeu_Id] UNIQUEIDENTIFIER NOT NULL, -- Référence au GUID du jeu
    [Tag_Id] UNIQUEIDENTIFIER NOT NULL, -- Référence au GUID du tag
    CONSTRAINT FK_Jeux_Tags_Jeu FOREIGN KEY ([Jeu_Id]) REFERENCES dbo.Jeux([Jeu_Id]) ON DELETE CASCADE,
    CONSTRAINT FK_Jeux_Tags_Tag FOREIGN KEY ([Tag_Id]) REFERENCES dbo.Tag([Tag_Id]) ON DELETE CASCADE,
    CONSTRAINT UQ_Jeux_Tags UNIQUE ([Jeu_Id], [Tag_Id])
)
