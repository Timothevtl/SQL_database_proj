-- REQUÊTES SUR LA BDD VÉLOMAX
-- pour aider au passage à la console C# et tester les requêtes

-- création utilisateurs
CREATE USER 'root'@'localhost' IDENTIFIED BY 'root';
CREATE USER 'bozo'@'localhost' IDENTIFIED BY 'bozo';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'localhost';
GRANT SELECT ON *.* TO 'Bozo'@'localhost';

-- pour modifier le paramère safe mode (si probleme)
-- ----------------------------------------
-- show variables like 'sql_safe_updates' ;
-- set sql_safe_updates = 0 ;

-- GESTION 

-- Gestion des pièces de rechanges
-- affichage
SELECT * FROM PiècesD;
-- création : 
#INSERT INTO PiècesD VALUES(@NumP,@DescPiece,@DateIP , @DateDP ,@NomF,@NumCata,@PrixUP, @Stock);
-- suppression : 
DELETE FROM PiècesD WHERE NumP = @NumP;
-- maj :
UPDATE PiècesD SET NumP = @nouvNumP WHERE NumP=@NumP;
UPDATE PiècesD SET DescPiece = @DescPiece WHERE NumP=@NumP;
UPDATE PiècesD SET DateIP = @DateIP WHERE NumP=@NumP;
UPDATE PiècesD SET DateDP = @DateDP WHERE NumP=@NumP;
UPDATE PiècesD SET NomF = @NomF WHERE NumP=@NumP;
UPDATE PiècesD SET NumCata = @NumCata WHERE NumP=@NumP;
UPDATE PiècesD SET PrixUP = @PrixUP WHERE NumP=@NumP;
UPDATE PiècesD SET Stock = @Stock WHERE NumP=@NumP;

-- Gestion des Bicyclettes
-- affichage
SELECT * FROM Bicyclette;
-- création : 
#INSERT INTO Bicyclette VALUES(@NumV ,@NomV ,@GrandeurV,@PrixUV,@DateIM,@DateDM,@Ligne, @Cadre, @Guidon, @Freins, @Selle, @Derailleur_Avant, @Derailleur_Arrière, @Roue_Avant, @Roue_Arrière, @Reflecteurs, @Pedalier, @Ordinateur, @Panier)
-- suppression : 
DELETE FROM Bicyclette WHERE NumV = @NumV;
-- maj :
UPDATE Bicyclette SET NomV = @NomV WHERE NumV=@NumV;
UPDATE Bicyclette SET GrandeurV = @GrandeurV WHERE NumV=@NumV;
UPDATE Bicyclette SET PrixUV = @PrixUV WHERE NumV=@NumV;
UPDATE Bicyclette SET DateIM = @DateIM WHERE NumV=@NumV;
UPDATE Bicyclette SET DateDM = @DateDM WHERE NumV=@NumV;
UPDATE Bicyclette SET Ligne = @Ligne WHERE NumV=@NumV;
UPDATE Bicyclette SET Cadre = @Cadre WHERE NumV=@NumV;
UPDATE Bicyclette SET Guidon = @Guidon WHERE NumV=@NumV;
UPDATE Bicyclette SET Freins = @Freins WHERE NumV=@NumV;
UPDATE Bicyclette SET Selle = @Selle WHERE NumV=@NumV;
UPDATE Bicyclette SET Derailleur_Avant = @Derailleur_Avant WHERE NumV=@NumV;
UPDATE Bicyclette SET Derailleur_Arrière = @Derailleur_Arriere WHERE NumV=@NumV;
UPDATE Bicyclette SET Roue_Avant = @Roue_Avant WHERE NumV=@NumV;
UPDATE Bicyclette SET Roue_Arrière = @Roue_Arriere WHERE NumV=@NumV;
UPDATE Bicyclette SET Reflecteurs = @Reflecteurs WHERE NumV=@NumV;
UPDATE Bicyclette SET Pedalier = @Pedalier WHERE NumV=@NumV;
UPDATE Bicyclette SET Ordinateur = @Ordinateur WHERE NumV=@NumV;
#UPDATE Bicyclette SET Panier = @Panier WHERE NumV=@NumV;

-- Gestion des clients
-- affichage (tous les clients, boutiques et individus confondus, puis seulement les boutiques, puis seulement les individus)
SELECT * FROM Client;
SELECT * FROM Boutique;
SELECT * FROM Individu;
SELECT * FROM Adresse;
SELECT * FROM Affecte_Adresse;
SELECT * FROM Fidélio;
SELECT * FROM Adhère;

SELECT * FROM Client Natural Join Boutique Natural Join Adresse;
SELECT * FROM Client Natural Join Individu Natural Join Adresse Natural Join Adhère;

#création : 
#INSERT INTO Client values(@Id_Client, @tel, @Courriel, @NomCompagnie, @NomIndiv, @Id_Adresse, @NumProg);
#INSERT INTO Boutique values(@Id_Client, @NomCompagnie, @NomContact, @Remise);
#INSERT INTO Individu Values(@Id_Client,@NomIndiv, @PrenomIndiv);
#INSERT INTO Adhère Values(@Id_Client,@NumProg, @DateAdh, @DatePay);
#INSERT INTO Adresse Values(@Id_Adresse,@Rue, @Ville, @CodePostal, @Province);
#INSERT INTO Affecte_Adresse Values(@Id_Client, @Id_Adresse);

#suppression : 
DELETE FROM Individu WHERE Id_Client = @Id_Client;
#maj :
UPDATE Client SET tel = @tel WHERE Id_Client=@Id_Client;
UPDATE Client SET Courriel = @Courriel WHERE Id_Client=@Id_Client;
UPDATE Client SET NomCompagnie = @NomCompagnie WHERE Id_Client=@Id_Client;
UPDATE Client SET NomIndiv = @NomIndiv WHERE Id_Client=@Id_Client;
UPDATE Client SET Id_Adresse = @Id_Adresse WHERE Id_Client=@Id_Client;
UPDATE Client SET NumProg = @NumProg WHERE Id_Client=@Id_Client;

UPDATE Boutique SET NomCompagnie = @NomCompagnie WHERE Id_Client=@Id_Client;
UPDATE Boutique SET NomContact = @NomContact WHERE Id_Client=@Id_Client;
UPDATE Boutique SET Remise = @Remise WHERE Id_Client=@Id_Client;

UPDATE Individu SET NomIndiv = @NomIndiv WHERE Id_Client=@Id_Client;
UPDATE Individu SET PrenomIndiv = @PrenomIndiv WHERE Id_Client=@Id_Client;

UPDATE Adresse SET Rue = @Rue WHERE Id_Adresse=@Id_Adresse;
UPDATE Adresse SET Ville = @Ville WHERE Id_Adresse=@Id_Adresse;
UPDATE Adresse SET CodePostal = @CodePostal WHERE Id_Adresse=@Id_Adresse;
UPDATE Adresse SET Province = @Province WHERE Id_Adresse=@Id_Adresse;

UPDATE Affecte_Adresse SET Id_Adresse = @Id_Adresse WHERE Id_Client=@Id_Client;

UPDATE Adhère SET NumProg = @NumProg WHERE Id_Client=@Id_Client;
UPDATE Adhère SET Date_Adh_ind = @Date_Adh_ind WHERE Id_Client=@Id_Client;
UPDATE Adhère SET Date_pay_ind = @Date_pay_ind WHERE Id_Client=@Id_Client;


-- Gestion des fournisseur
-- affichage
SELECT * FROM Fournisseur;

-- création : 
#INSERT INTO Fournisseur VALUES(@Siret,@NomE,@ContactE , @AddE ,@Libellé);
-- suppression : 
#DELETE FROM Fournisseur WHERE NomE = @NomE;
#DELETE FROM PiècesD WHERE NumP IN (SELECT * FROM PiècesD JOIN Fournisseur ON Fournisseur.NomE=PiècesD.NomF WHERE Fournisseur.Siret = 555978464687);
#SELECT * FROM PiècesD JOIN Fournisseur ON Fournisseur.NomE=PiècesD.NomF WHERE Fournisseur.Siret = 555978464687 ;
#DELETE FROM Fournit WHERE Siret NOT IN (SELECT Siret FROM Fournisseur WHERE NomE = @NomE);
#DELETE FROM PiècesD WHERE NumP NOT IN (SELECT NumP FROM Fournit);

-- maj :
UPDATE Fournisseur SET NomE = @nouvnom WHERE NomE=@NomE;
UPDATE Fournisseur SET Siret = @Siret WHERE NomE=@NomE;
UPDATE Fournisseur SET ContactE = @ContactE WHERE NomE=@NomE;
UPDATE Fournisseur SET AddE = @AddE WHERE NomE=@NomE;
UPDATE Fournisseur SET Libellé = @Libelle WHERE NomE=@NomE;


-- Gestion des commandes
-- affichage
SELECT * FROM Commande;
SELECT * FROM Commande JOIN Contient_PiècesD ON Contient_PiècesD.NumC=Commande.NumC JOIN Contient_Vélo ON Contient_Vélo.NumC=Commande.NumC;
SELECT * FROM Contient_PiècesD;
SELECT * FROM Contient_Vélo;

-- création : 
#INSERT INTO Commande VALUES(@NumC,@AddLiv,@DateL , @DateC);
#INSERT INTO Contient_PiècesD VALUES(@NumC,@NumP,@Quantite_PiècesD);
#INSERT INTO Contient_Vélo VALUES(@NumC,@NumV,@Quantite_Vélo);

-- suppression : 
DELETE FROM Commande WHERE NumC = @NumC;

-- maj :
UPDATE Commande SET AddLiv = @AddLiv WHERE NumC=@NumC;
UPDATE Commande SET DateL = @DateL WHERE NumC=@NumC;
UPDATE Commande SET DateC = @DateC WHERE NumC=@NumC;
UPDATE Commande SET Id_Client = @Id_Client WHERE NumC=@NumC;
UPDATE Contient_PiècesD SET NumP = @NumP WHERE NumC=@NumC;
UPDATE Contient_PiècesD SET Quantite_PiècesD = @Quantite_PiecesD WHERE NumC=@NumC;
UPDATE Contient_Vélo SET NumV = @NumV WHERE NumC=@NumC;
UPDATE Contient_Vélo SET Quantite_Vélo = @Quantite_Velo WHERE NumC=@NumC;


-- Gestion du stock
-- Aperçu des stocks par pièce : 
select * from PiècesD;
SELECT DescPiece AS Nom , count(*) AS Nombre FROM PiècesD P
GROUP BY P.DescPiece;

SELECT * FROM PiècesD P 
WHERE P.DescPiece = "@piece";

-- Aperçu des stocks par fournisseur : 
SELECT NomE , count(NumP) AS NombrePiece FROM Fournisseur NATURAL JOIN Fournit
GROUP BY Siret;

SELECT * FROM PiècesD P JOIN Fournit ON P.NumP=Fournit.NumP
WHERE P.NomF = "Fournisseur1"
ORDER BY Fournit.Siret;

SELECT * FROM PiècesD P 
WHERE P.NomF = "Fournisseur1";

SELECT DescPiece, sum(Stock) FROM PiècesD P JOIN Fournit ON P.NumP=Fournit.NumP
WHERE P.NomF = "Fournisseur1"
GROUP BY P.DescPiece;

-- Aperçu des stocks par vélo : 
SELECT NomV, count(*) FROM Bicyclette GROUP BY NomV;

-- Aperçu des stocks par catégorie de vélo : 
SELECT Ligne, count(*) FROM Bicyclette GROUP BY Ligne;

-- Aperçu des stocks par grandeur de vélo : 
SELECT GrandeurV, count(*) FROM Bicyclette GROUP BY GrandeurV;

-- Aperçu des stocks par Prix unitaire : 
SELECT PrixUV, count(*) FROM Bicyclette GROUP BY PrixUV ;
SELECT NumP, PrixUP FROM PiècesD ;


-- MODULE STATISTIQUES
-- Quantités vendues de chaque item de l’inventaire
SELECT DescPiece, NumP, count(*) FROM PiècesD NATURAL JOIN Contient_PiècesD
GROUP BY PiècesD.NumP;

-- Liste des membres pour chaque programme Fidélio
SELECT NomIndiv, PrenomIndiv FROM Individu NATURAL JOIN Client NATURAL JOIN Adhère
WHERE Adhère.NumProg = 1;
SELECT NomIndiv, PrenomIndiv FROM Individu NATURAL JOIN Client NATURAL JOIN Adhère
WHERE Adhère.NumProg = 2;
SELECT NomIndiv, PrenomIndiv FROM Individu NATURAL JOIN Client NATURAL JOIN Adhère
WHERE Adhère.NumProg = 3;
SELECT NomIndiv, PrenomIndiv FROM Individu NATURAL JOIN Client NATURAL JOIN Adhère
WHERE Adhère.NumProg = 4;
SELECT Adhère.NumProg, NomIndiv, PrenomIndiv FROM Individu NATURAL JOIN Client NATURAL JOIN Adhère
ORDER BY Adhère.NumProg;

-- Date d’expiration des adhésions

-- Nombre total de commandes
SELECT Count(NumC) FROM Commande;

-- Prix total de chaque commande
SELECT Commande.NumC, SUM(Quantite_PiècesD*PrixUP + Quantite_Vélo*PrixUV) AS PrixTCommande FROM Commande
JOIN Contient_PiècesD ON Contient_PiècesD.NumC = Commande.NumC
JOIN  Contient_Vélo ON Contient_Vélo.NumC = Commande.NumC
NATURAL JOIN Bicyclette
NATURAL JOIN PiècesD
GROUP BY Commande.NumC;

-- Moyenne des montants des commandes
# a faire sur C# à partir des 2 requêtes précédentes

-- Moyenne du nombre de pièces par commande
-- Nombre de pièces par commande
SELECT Commande.NumC, SUM(Quantite_PiècesD) AS nbPièce FROM Commande
JOIN Contient_PiècesD ON Contient_PiècesD.NumC = Commande.NumC
NATURAL JOIN PiècesD
GROUP BY Commande.NumC;

-- Moyenne du nombre de vélos par commande
-- Nombre de vélos par commande
SELECT Commande.NumC, SUM(Quantite_Vélo) AS nbVelo FROM Commande
JOIN Contient_Vélo ON Contient_Vélo.NumC = Commande.NumC
NATURAL JOIN Bicyclette
GROUP BY Commande.NumC;


-- Le meilleur client en fonction des quantités achetées

SELECT nomIndiv, NomCompagnie, sum(Quantite_Vélo+Quantite_PiècesD) AS cumul FROM client 
join Commande on client.Id_Client = commande.Id_Client 
join Contient_PiècesD on Contient_PiècesD.NumC = commande.NumC
join  Contient_Vélo on Contient_Vélo.numC = commande.NumC
natural join bicyclette
natural join PiècesD
GROUP BY commande.NumC
ORDER BY cumul DESC LIMIT 1;


-- Le meilleur client en fonction du cumul en euros 
SELECT nomIndiv, NomCompagnie, sum(prixUP*Quantite_PiècesD+prixUV*Quantite_Vélo) AS cumul FROM client 
join Commande on client.Id_Client = commande.Id_Client 
join Contient_PiècesD on Contient_PiècesD.NumC = commande.NumC
join  Contient_Vélo on Contient_Vélo.numC = commande.NumC
natural join bicyclette
natural join PiècesD
GROUP BY commande.NumC
ORDER BY cumul DESC LIMIT 1;


-- Requête synchronisée
SELECT NumV, NomV, GrandeurV, Ligne, PrixUV FROM Bicyclette 
WHERE PrixUV < (SELECT AVG(PrixUV) FROM Bicyclette);
SELECT AVG(PrixUV) FROM Bicyclette;

-- Requête avec auto-jointure
SELECT V1.NumV, V1.NomV, V2.NumV, V2.NomV, V1.PrixUV
FROM Bicyclette V1, Bicyclette V2
WHERE V1.PrixUV=V2.PrixUV;

-- Requête avec une union
SELECT NumV, NomV, GrandeurV, Ligne FROM Bicyclette
WHERE PrixUV<200 AND Ordinateur=''
UNION
SELECT NumV, NomV, GrandeurV, Ligne FROM Bicyclette
WHERE Ordinateur!='';

SELECT JSON_ARRAYAGG(JSON_OBJECT('id_Client', id_Client, 'tel', tel,'NomCompagnie', NomCompagnie,'NomIndiv', NomIndiv,'Id_Adresse', Id_Adresse, 'NumProg', NumProg)) from Client INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/client.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('Id_Adresse',Id_Adresse, 'Rue', Rue, 'Ville', Ville, 'CodePostal', CodePostal, 'Province', Province )) from adresse INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/adresse.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('Id_Client',Id_Client, 'Id_Adresse', Id_Adresse)) from affecte_adresse INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/affecte_adresse.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('NumV', NumV, 'NumP', NumP)) from assemblage INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/assemblage.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('NumV', NumV, 'NomV', NomV, 'GrandeurV', GrandeurV, 'PrixUV', PrixUV, 'DateIM', DateIM, 'DateDM', DateDM, 'Ligne', Ligne, 'Cadre', Cadre, 'Guidon', Guidon, 'Freins', Freins, 'Selle', Selle, 'Derailleur_Avant', Derailleur_Avant, 'derailleur_Arriere', derailleur_Arrière, 'Roue_Avant', Roue_Avant, 'Roue_Arrière', Roue_Arrière, 'Réflecteurs', Reflecteurs, 'Pedalier', Pedalier, 'Ordinateur', Ordinateur, 'Panier', Panier)) from bicyclette INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/bicyclette.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('Id_Client', Id_Client, 'NomCompagnie', NomCompagnie, 'NomContact', NomContact, 'Remise', Remise)) from boutique INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/boutique.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('Id_Client', Id_Client, 'Numprog', NumProg, 'Date_Adh_Ind',Date_Adh_Ind, 'Date_pay_Ind', Date_pay_Ind )) from adhère INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/adhere.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('NumC', NumC, 'AddLiv', AddLiv, 'DateL', DateL, 'DateC', DateC, 'Id_Client', Id_Client)) from Commande INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/Commande.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('NumC', NumC, 'NumP', NumP, 'Quantite_PiècesD',Quantite_PiècesD )) from contient_piècesD INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/contient_piecesD.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('NumC', NumC, 'NumV', NumV,'Quantite_Vélo', Quantite_Vélo)) from contient_vélo INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/contient_velo.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('NumProg', NumProg, 'DescProg', DescProg, 'CoutProg', CoutProg, 'DureeProg', DureeProg, 'RabaisProg', RabaisProg)) from fidélio INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/fidelio.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('Siret', Siret, 'NomE', NomE, 'ContactE', ContactE, 'AddE', AddE, 'libellé', Libellé)) from fournisseur INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/fournisseur.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('Siret', Siret, 'NumP', NumP)) from fournit INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/fournit.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('Id_Client', Id_Client, 'NomIndiv', NomIndiv, 'PrénomIndiv', PrenomIndiv)) from individu INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/individu.json';
SELECT JSON_ARRAYAGG(JSON_OBJECT('NumP', NumP, 'DescPiece', DescPiece, 'DateIP', DateIP, 'DateDP', DateDP, 'NomF', NomF, 'NumCata', NumCata, 'PrixUP', PrixUP, 'Stock', Stock)) from PiècesD INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/PiecesD.json';


