-- La table PersonnageGroupe utilise les colonnes GroupeId et PersonnageId pour faire des jointures avec Groupe et Personnage
-- On retrouve une jointure avec Personnage dans la proc�dure et dans la vue, les tables Groupe et Personnage sont utilis�es
-- De plus, GroupeId est une des param�tres de la proc�dure utilis�e
CREATE NONCLUSTERED INDEX IX_PersonnageGroupe_GroupeId_PersonnageId
ON Personnages.PersonnageGroupe(GroupeId,PersonnageId)

-- Le Statut de la table Personnage est l'autre param�tre de la proc�dure et permet donc de chercher des personnages selon un Statut 
CREATE NONCLUSTERED INDEX IX_Personnage_Statut
ON Personnages.Personnage(Statut)