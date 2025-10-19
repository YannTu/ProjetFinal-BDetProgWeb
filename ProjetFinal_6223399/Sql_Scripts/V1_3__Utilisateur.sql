	CREATE TABLE Utilisateurs.Utilisateur(
		UtilisateurID int IDENTITY(1,1),
		Pseudo nvarchar(50) NOT NULL,
		MotDePasseHache varbinary(64) NOT NULL,
		Sel varbinary(16) NOT NULL,
		CONSTRAINT PK_Utilisateur_UtilisateurID PRIMARY KEY (UtilisateurID)
	);
	GO
		
	ALTER TABLE Utilisateurs.Utilisateur ADD CONSTRAINT
	UC_Utilisateur_Pseudo UNIQUE (Pseudo);
	GO


	CREATE PROCEDURE Utilisateurs.USP_CreerUtilisateur
		@Pseudo nvarchar(50),
		@MotDePasse nvarchar(50)
	AS
	BEGIN
	
		DECLARE @Sel varbinary(16) = CRYPT_GEN_RANDOM(16);

		DECLARE @MotDePasseSel nvarchar(116) = CONCAT(@MotDePasse, @Sel)

		DECLARE @MotDePasseHache varbinary(64) = HASHBYTES('SHA2_256', @MotDePasseSel);
		
		INSERT INTO Utilisateurs.Utilisateur (Pseudo, MotDePasseHache, Sel)
		VALUES
		(@Pseudo, @MotDePasseHache, @Sel);
	
	END
	GO
	
	
	CREATE PROCEDURE Utilisateurs.USP_AuthUtilisateur
		@Pseudo nvarchar(50),
		@MotDePasse nvarchar(50)
	AS
	BEGIN

		DECLARE @Sel varbinary(16);
		DECLARE @Mdp varbinary(64);
		SELECT @Sel = Sel, @Mdp = MotDePasseHache
		FROM Utilisateurs.Utilisateur
		WHERE Pseudo = @Pseudo;
		
		IF HASHBYTES('SHA2_256', CONCAT(@MotDePasse, @Sel)) = @Mdp
		BEGIN
			SELECT * FROM Utilisateurs.Utilisateur WHERE Pseudo = @Pseudo;
		END
		ELSE
		BEGIN
			SELECT TOP 0 * FROM Utilisateurs.Utilisateur
		END
	END
	GO


	EXEC Utilisateurs.USP_CreerUtilisateur @Pseudo = 'max', @MotDePasse = 'Salut1!';
	GO
	
	EXEC Utilisateurs.USP_CreerUtilisateur @Pseudo = 'bob', @MotDePasse = 'Allo1!';
	GO