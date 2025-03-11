CREATE PROCEDURE [dbo].[SP_Create_Utilisateur]
    @Email NVARCHAR(320),
    @Password VARBINARY(64),
    @Salt UNIQUEIDENTIFIER,
    @Pseudo NVARCHAR(64)
AS
BEGIN
    INSERT INTO dbo.Utilisateur (Email, Password, Salt, Pseudo, CreatedAt)
    VALUES (@Email, @Password, @Salt, @Pseudo, GETDATE());
END;
