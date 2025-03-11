CREATE PROCEDURE [dbo].[SP_Create_Utilisateur]
    @Email NVARCHAR(320),
    @Password VARBINARY(64),         -- Le mot de passe déjà salé et haché
    @Salt UNIQUEIDENTIFIER,         -- Le sel généré pour cet utilisateur
    @Pseudo NVARCHAR(64)            -- Le pseudo de l'utilisateur
AS
BEGIN
    -- Insérer l'utilisateur avec le mot de passe haché, le sel et le pseudo dans la table Utilisateur
    INSERT INTO dbo.Utilisateur (Email, Password, Salt, Pseudo, CreatedAt)
    VALUES (@Email, @Password, @Salt, @Pseudo, GETDATE());
END;
