CREATE OR ALTER PROCEDURE Personnages.usp_quantitePersonnagesGroupe
(@GroupeID int, @Statut nvarchar(20))
AS
BEGIN
	SELECT P.*
	FROM Personnages.Personnage P
	INNER JOIN PersonnageGroupe PG
	ON P.PersonnageID = PG.PersonnageID
	WHERE PG.GroupeID = @GroupeID AND P.Statut = @Statut
END
GO