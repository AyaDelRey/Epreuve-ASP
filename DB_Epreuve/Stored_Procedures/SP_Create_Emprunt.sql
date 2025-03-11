CREATE PROCEDURE [dbo].[SP_Create_Emprunt]
    @Utilisateur_Id UNIQUEIDENTIFIER,    -- L'ID de l'utilisateur emprunteur
    @Jeu_Id UNIQUEIDENTIFIER,             -- L'ID du jeu emprunté
    @DateEmprunt DATE                     -- La date de l'emprunt
AS
BEGIN
    -- Vérifier si l'utilisateur possède un exemplaire du jeu et si l'état est valide (pas "Incomplet")
    DECLARE @Jeux_Utilisateur_Id UNIQUEIDENTIFIER;

    SELECT @Jeux_Utilisateur_Id = Jeux_Utilisateur_Id
    FROM dbo.Jeux_Utilisateur
    WHERE Jeu_Id = @Jeu_Id 
    AND Utilisateur_Id = @Utilisateur_Id 
    AND Etat != 'Incomplet';

    -- Si un exemplaire valide du jeu est trouvé, on peut procéder à l'emprunt
    IF @Jeux_Utilisateur_Id IS NOT NULL
    BEGIN
        -- Ajouter l'emprunt dans la table Emprunt
        INSERT INTO dbo.Emprunt (Jeux_Utilisateur_Id, Emprunteur_Id, DateEmprunt)
        VALUES (@Jeux_Utilisateur_Id, @Utilisateur_Id, @DateEmprunt);
    END
END;
