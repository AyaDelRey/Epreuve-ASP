CREATE PROCEDURE [dbo].[SP_Get_Utilisateur]
    @Utilisateur_Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT * FROM dbo.Utilisateur WHERE Utilisateur_Id = @Utilisateur_Id;
END;