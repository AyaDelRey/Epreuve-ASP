
CREATE PROCEDURE [dbo].[SP_Create_Utilisateur]
    @Email NVARCHAR(320),
    @Password VARBINARY(64),         -- Le mot de passe déjà salé et haché
    @Pseudo NVARCHAR(64)            -- Le pseudo de l'utilisateur
AS
BEGIN
    -- Insérer l'utilisateur avec le mot de passe haché, le sel et le pseudo dans la table Utilisateur
    INSERT INTO dbo.Utilisateur (Email, Password, Pseudo, CreatedAt)
    VALUES (@Email, @Password, @Pseudo, GETDATE());
END;