CREATE OR ALTER VIEW Groupes.vw_DetailsGroupe AS
SELECT G.GroupeID, G.Nom AS [Nom du groupe], CONCAT(P_Chef.Prenom, ' ', P_Chef.Nom) AS [Nom du chef], SUM(CASE WHEN P.Genre = 'Homme' THEN 1 ELSE 0 END) AS [Nombre d'hommes], SUM(CASE WHEN P.Genre = 'Femme' THEN 1 ELSE 0 END) AS [Nombre de femmes], COUNT(P.PersonnageID) AS [Nombre total de membres], PG_Chef.PersonnageGroupeID, P_Chef.PersonnageID 
FROM Groupes.Groupe G
INNER JOIN Personnages.PersonnageGroupe PG
ON G.GroupeID = PG.GroupeID
INNER JOIN Personnages.Personnage P
ON PG.PersonnageID = P.PersonnageID
LEFT JOIN Personnages.PersonnageGroupe PG_Chef 
ON G.GroupeID = PG_Chef.GroupeID AND PG_Chef.EstChef = 1
LEFT JOIN Personnages.Personnage P_Chef 
ON PG_Chef.PersonnageID = P_Chef.PersonnageID
GROUP BY G.GroupeID, G.Nom, P_Chef.Nom, P_Chef.Prenom, PG_Chef.PersonnageGroupeID, P_Chef.PersonnageID
GO