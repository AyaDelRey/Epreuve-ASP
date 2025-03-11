CREATE PROCEDURE [dbo].[SP_Check_Password]
    @Email NVARCHAR(320),
    @Password NVARCHAR(32)
AS
BEGIN
    DECLARE @Salt UNIQUEIDENTIFIER;
    DECLARE @StoredPassword VARBINARY(64);
    
    -- Récupérer le sel et le mot de passe haché
    SELECT @Salt = Salt, 
           @StoredPassword = Password
    FROM dbo.Utilisateur
    WHERE Email = @Email;

    -- Si le sel existe (l'email est valide)
    IF @Salt IS NOT NULL
    BEGIN
        -- Saler et hacher le mot de passe fourni
        DECLARE @HashedPassword VARBINARY(64);
        SET @HashedPassword = dbo.SF_SaltAndHash(@Password, @Salt);

        -- Vérifier si le mot de passe correspond
        IF @HashedPassword = @StoredPassword
        BEGIN
            -- Si le mot de passe est correct
            SELECT 1 AS IsValid;  -- 1 = Valide
        END
        ELSE
        BEGIN
            -- Si le mot de passe est incorrect
            SELECT 0 AS IsValid;  -- 0 = Invalide
        END
    END
    ELSE
    BEGIN
        -- Si l'email n'existe pas
        SELECT 0 AS IsValid;  -- 0 = Invalide
    END
END;

