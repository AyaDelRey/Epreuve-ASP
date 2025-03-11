CREATE PROCEDURE [dbo].[SP_Delete_Utilisateur]
    @Utilisateur_Id UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE dbo.Utilisateur
    SET DisabledAt = GETDATE()
    WHERE Utilisateur_Id = @Utilisateur_Id;
END;
