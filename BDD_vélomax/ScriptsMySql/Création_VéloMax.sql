-- CRÉATION DES TABLES DANS LA BDD VÉLOMAX

-- Création de la BDD VéloMax

DROP DATABASE IF EXISTS velomax;
CREATE DATABASE IF NOT EXISTS velomax;
USE velomax;

-- Création des utilisateurs
#ALTER USER 'root'@'localhost' IDENTIFIED BY 'root';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'localhost';
GRANT SELECT ON *.* TO 'bozo'@'localhost';

-- Création des tables d'entités

DROP TABLE IF EXISTS Bicyclette;
DROP TABLE IF EXISTS Commande;
DROP TABLE IF EXISTS PiècesD;
DROP TABLE IF EXISTS Fournisseur;
DROP TABLE IF EXISTS Client;
DROP TABLE IF EXISTS Adresse;
DROP TABLE IF EXISTS Boutique;
DROP TABLE IF EXISTS Individu;
DROP TABLE IF EXISTS Fidélio;
DROP TABLE IF EXISTS Individu;

-- Table Bicyclette
CREATE TABLE IF NOT EXISTS Bicyclette (
NumV INTEGER PRIMARY KEY,
NomV VARCHAR(20),
GrandeurV VARCHAR(20),
PrixUV INTEGER,
DateIM DATE,
DateDM DATE,
Ligne VARCHAR(20),
Cadre VARCHAR(20),
Guidon VARCHAR(20),
Freins VARCHAR(20),
Selle VARCHAR(20),
Derailleur_Avant VARCHAR(20),
derailleur_Arrière VARCHAR(20),
Roue_Avant VARCHAR(20),
Roue_Arrière VARCHAR(20),
Reflecteurs VARCHAR(20),
Pedalier VARCHAR(20),
Ordinateur VARCHAR(20),
Panier VARCHAR(20)
);


-- Table PiècesD
CREATE TABLE IF NOT EXISTS PiècesD (
NumP VARCHAR(20) PRIMARY KEY,
DescPiece VARCHAR(20),
DateIP DATE,
DateDP DATE,
NomF VARCHAR(20),
NumCata VARCHAR(20),
PrixUP INTEGER,
Stock INTEGER
);

-- Table Fournisseur
CREATE TABLE IF NOT EXISTS Fournisseur (
Siret BIGINT PRIMARY KEY,
NomE VARCHAR(20),
ContactE VARCHAR(50),
AddE VARCHAR(20),
Libellé VARCHAR(20)
);

-- Table Client
CREATE TABLE IF NOT EXISTS Client (
Id_Client INTEGER PRIMARY KEY,
tel VARCHAR(20),
Courriel VARCHAR(20),
NomCompagnie VARCHAR(20),
NomIndiv VARCHAR(20),
Id_Adresse INTEGER,
NumProg INTEGER
);

-- Table Adresse
CREATE TABLE IF NOT EXISTS Adresse (
Id_Adresse INTEGER PRIMARY KEY,
Rue VARCHAR(200),
Ville VARCHAR(20),
CodePostal INTEGER,
Province VARCHAR(20)
);

-- Table Boutique
CREATE TABLE IF NOT EXISTS Boutique (
Id_Client INTEGER PRIMARY KEY,
FOREIGN KEY (Id_Client) REFERENCES 
	Client(Id_Client),
NomCompagnie VARCHAR(20),
NomContact VARCHAR(20),
REMISE INTEGER
);

-- Table Individu
CREATE TABLE IF NOT EXISTS Individu (
Id_Client INTEGER PRIMARY KEY,
FOREIGN KEY (Id_Client) REFERENCES 
	Client(Id_Client),
NomIndiv VARCHAR(20),
PrenomIndiv VARCHAR(20)
);

-- Table Fidélio
CREATE TABLE IF NOT EXISTS Fidélio (
NumProg INTEGER PRIMARY KEY,
DescProg VARCHAR(20),
CoutProg INTEGER,
DureeProg INTEGER,
RabaisProg INTEGER
);

-- Table Commande
CREATE TABLE IF NOT EXISTS Commande (
NumC INTEGER PRIMARY KEY,
AddLiv VARCHAR(200),
DateL DATE,
DateC DATE,
Id_Client INTEGER,
FOREIGN KEY (Id_Client) REFERENCES 
	Client(Id_Client)
);

-- Création des tables associations

DROP TABLE IF EXISTS Assemblage;
DROP TABLE IF EXISTS Contient_PiècesD;
DROP TABLE IF EXISTS Contient_Vélo;
DROP TABLE IF EXISTS Fournit;
DROP TABLE IF EXISTS Affecte_Adresse;
DROP TABLE IF EXISTS Adhère;

-- Table Assemblage
CREATE TABLE IF NOT EXISTS Assemblage (
NumV INTEGER,
FOREIGN KEY (NumV) REFERENCES 
	Bicyclette(NumV),
NumP VARCHAR(20),
FOREIGN KEY (NumP) REFERENCES
	PiècesD(NumP),
PRIMARY KEY(NumV, NumP)
);

-- Table Contient_PiècesD
CREATE TABLE IF NOT EXISTS Contient_PiècesD (
NumC INTEGER,
FOREIGN KEY (NumC) REFERENCES 
	Commande(NumC),
NumP VARCHAR(20),
FOREIGN KEY (NumP) REFERENCES
	PiècesD(NumP),
Quantite_PiècesD INTEGER,
PRIMARY KEY(NumC, NumP)
);

-- Table Contient_Vélo
CREATE TABLE IF NOT EXISTS Contient_Vélo (
NumC INTEGER,
FOREIGN KEY (NumC) REFERENCES 
	Commande(NumC),
NumV INTEGER,
FOREIGN KEY (NumV) REFERENCES
	Bicyclette(NumV),
Quantite_Vélo INTEGER,
PRIMARY KEY(NumC, NumV)
);

-- Table Fournit
CREATE TABLE IF NOT EXISTS Fournit (
Siret BIGINT,
FOREIGN KEY (Siret) REFERENCES 
	Fournisseur(Siret),
NumP VARCHAR(20),
FOREIGN KEY (NumP) REFERENCES
	PiècesD(NumP),
PRIMARY KEY(Siret, NumP)
);

-- Table Affecte_Adresse
CREATE TABLE IF NOT EXISTS Affecte_Adresse (
Id_Client INTEGER,
FOREIGN KEY (Id_Client) REFERENCES 
	Client(Id_Client),
Id_Adresse INTEGER,
FOREIGN KEY (Id_Adresse) REFERENCES
	Adresse(Id_Adresse),
PRIMARY KEY(Id_Client, Id_Adresse)
);
-- Table Adhère
CREATE TABLE IF NOT EXISTS Adhère (
Id_Client INTEGER,
FOREIGN KEY (Id_Client) REFERENCES 
	Client(Id_CLient),
NumProg INTEGER,
FOREIGN KEY (NumProg) REFERENCES
	Fidélio(NumProg),
Date_Adh_Ind DATE,
Date_pay_Ind DATE,
PRIMARY KEY(Id_Client, NumProg)
);


-- Vérification après avoir chargé le fichier Peuplement_VéloMax
SELECT * FROM Bicyclette;
SELECT * FROM Commande;
SELECT * FROM PiècesD;
SELECT * FROM Fournisseur;
SELECT * FROM Client;
SELECT * FROM Adresse;
SELECT * FROM Boutique;
SELECT * FROM Individu;
SELECT * FROM Fidélio;
SELECT * FROM Individu;

SELECT * FROM Assemblage;
SELECT * FROM Contient_PiècesD;
SELECT * FROM Contient_Vélo;
SELECT * FROM Fournit;
SELECT * FROM Affecte_Adresse;
SELECT * FROM Adhère;

