ALTER TABLE Personnages.Personnage ADD
Identifiant uniqueidentifier NOT NULL ROWGUIDCOL DEFAULT newid();
GO

ALTER TABLE Personnages.Personnage ADD CONSTRAINT UC_Personnage_Identifiant
UNIQUE (Identifiant);
GO

ALTER TABLE Personnages.Personnage ADD
Image varbinary(max) FILESTREAM NULL;
GO


UPDATE Personnages.Personnage
SET Image = (SELECT BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\6223399\Desktop\ProjetFinal_6223399\Images\Rick.png', SINGLE_BLOB) AS myfile)
WHERE PersonnageID = 1;

UPDATE Personnages.Personnage
SET Image = (SELECT BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\6223399\Desktop\ProjetFinal_6223399\Images\Daryl.png', SINGLE_BLOB) AS myfile)
WHERE PersonnageID = 2;

UPDATE Personnages.Personnage
SET Image = (SELECT BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\6223399\Desktop\ProjetFinal_6223399\Images\Carol.png', SINGLE_BLOB) AS myfile)
WHERE PersonnageID = 3;

UPDATE Personnages.Personnage
SET Image = (SELECT BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\6223399\Desktop\ProjetFinal_6223399\Images\Maggie.png', SINGLE_BLOB) AS myfile)
WHERE PersonnageID = 4;