CREATE PROCEDURE [dbo].[SP_Update_Utilisateur]
    @Utilisateur_Id UNIQUEIDENTIFIER,
    @Pseudo NVARCHAR(64)
AS
BEGIN
    UPDATE dbo.Utilisateur
    SET Pseudo = @Pseudo
    WHERE Utilisateur_Id = @Utilisateur_Id;
END;
