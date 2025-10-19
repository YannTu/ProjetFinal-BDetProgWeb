CREATE TABLE Saisons.Saison(
	SaisonID int IDENTITY NOT NULL,
	NumeroSaison int NOT NULL,
	DateDebut date NOT NULL,
	DateFin date NOT NULL,
	Profit int NOT NULL,
	Note numeric(3,1) NOT NULL,
	CONSTRAINT PK_Saison_SaisonID PRIMARY KEY (SaisonID)
);
GO

CREATE TABLE Saisons.Episode(
	EpisodeID int IDENTITY NOT NULL,
	NumeroEpisode int NOT NULL,
	NomEpisode nvarchar(50) NOT NULL,
	DateTransmission date NOT NULL,
	DureeMinutes int NOT NULL,
	Note numeric(3,1) NOT NULL,
	NomRealisateur nvarchar(30) NOT NULL,
	SaisonID int NOT NULL,
	CONSTRAINT PK_Episode_EpisodeID PRIMARY KEY (EpisodeID)
);
GO

CREATE TABLE Personnages.PersonnageEpisode(
	PersonnageEpisodeID int IDENTITY NOT NULL,
	Acteur nvarchar(30) NOT NULL,
	PremiereApparition nvarchar(20) NOT NULL,
	EpisodeID int NOT NULL,
	PersonnageID int NOT NULL,
	CONSTRAINT PK_PersonnageEpisode_PersonnageEpisodeID PRIMARY KEY (PersonnageEpisodeID)
);
GO

CREATE TABLE Personnages.Personnage(
	PersonnageID int IDENTITY NOT NULL,
	Prenom nvarchar(15) NOT NULL,
	Nom nvarchar(15) NULL,
	Genre nvarchar(10) NOT NULL,
	Ethnicite nvarchar(20) NOT NULL,
	AgeDebutSerie int NULL,
	AgeFinSerie int NULL,
	Statut nvarchar(20) NOT NULL,
	CONSTRAINT PK_Personnage_PersonnageID PRIMARY KEY (PersonnageID)
);
GO

CREATE TABLE Personnages.PersonnageGroupe(
	PersonnageGroupeID int IDENTITY NOT NULL,
	EstChef bit NOT NULL,
	GroupeID int NOT NULL,
	PersonnageID int NOT NULL,
	CONSTRAINT PK_PersonnageGroupe_PersonnageGroupeID PRIMARY KEY (PersonnageGroupeID)
);
GO

CREATE TABLE Groupes.Groupe(
	GroupeID int IDENTITY NOT NULL,
	Nom nvarchar(30) NOT NULL,
	PremiereApparition nvarchar(20) NOT NULL,
	Statut nvarchar(20) NOT NULL,
	CONSTRAINT PK_Groupe_GroupeID PRIMARY KEY (GroupeID)
);
GO

CREATE TABLE Groupes.Emplacement(
	EmplacementID int IDENTITY NOT NULL,
	Emplacement nvarchar(30) NOT NULL,
	GroupeID int NOT NULL,
	CONSTRAINT PK_Emplacement_EmplacementID PRIMARY KEY (EmplacementID)
);
GO


ALTER TABLE Saisons.Episode ADD CONSTRAINT FK_Episode_SaisonID
FOREIGN KEY (SaisonID)
REFERENCES Saisons.Saison(SaisonID)
ON DELETE CASCADE

ALTER TABLE Personnages.PersonnageEpisode ADD CONSTRAINT FK_PersonnageEpisode_EpisodeID
FOREIGN KEY (EpisodeID)
REFERENCES Saisons.Episode(EpisodeID)

ALTER TABLE Personnages.PersonnageEpisode ADD CONSTRAINT FK_PersonnageEpisode_PersonnageID
FOREIGN KEY (PersonnageID)
REFERENCES Personnages.Personnage(PersonnageID)

ALTER TABLE Personnages.PersonnageGroupe ADD CONSTRAINT FK_PersonnageGroupe_GroupeID
FOREIGN KEY (GroupeID)
REFERENCES Groupes.Groupe(GroupeID)

ALTER TABLE Personnages.PersonnageGroupe ADD CONSTRAINT FK_PersonnageGroupe_PersonnageID
FOREIGN KEY (PersonnageID)
REFERENCES Personnages.Personnage(PersonnageID)

ALTER TABLE Groupes.Emplacement ADD CONSTRAINT FK_Emplacement_GroupeID
FOREIGN KEY (GroupeID)
REFERENCES Groupes.Groupe(GroupeID)
GO

ALTER TABLE Saisons.Saison
ADD CONSTRAINT CK_Saison_Note CHECK (Note BETWEEN 0 AND 10 )
GO
ALTER TABLE Saisons.Episode
ADD CONSTRAINT CK_Episode_Note CHECK (Note BETWEEN 0 AND 10 )
GO
ALTER TABLE Personnages.PersonnageEpisode 
ADD CONSTRAINT UC_PersonnageEpisode_Acteur UNIQUE (Acteur)
GO
ALTER TABLE Personnages.Personnage
ADD CONSTRAINT CK_Personnage_Genre CHECK (Genre in ('Homme', 'Femme') )
GO
ALTER TABLE Personnages.Personnage
ADD CONSTRAINT CK_Personnage_Statut CHECK (Statut in ('Vivant', 'Mort', 'Inconnu') )
GO
ALTER TABLE Groupes.Groupe
ADD CONSTRAINT CK_Groupe_Statut CHECK (Statut in ('Vivant', 'Éliminé', 'Inconnu') )
GO
ALTER TABLE Personnages.PersonnageGroupe
ADD CONSTRAINT DF_PersonnageGroupe_EstChef Default 0 FOR EstChef;
GO