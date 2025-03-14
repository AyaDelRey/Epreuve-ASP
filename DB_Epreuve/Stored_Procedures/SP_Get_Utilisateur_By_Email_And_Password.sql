
CREATE PROCEDURE [dbo].[SP_Get_Utilisateur_By_Email_And_Password]
    @Email NVARCHAR(255),
    @Password VARBINARY(64) -- Changer le type ici !
AS
BEGIN
    SELECT *
    FROM Utilisateur
    WHERE Email = @Email 
      AND Password = CONVERT(VARBINARY(64), @Password);
END;
