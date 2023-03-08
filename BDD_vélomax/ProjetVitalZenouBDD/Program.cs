using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;


namespace ProjetBDDVitalZenou
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Saisissez votre nom d'utilisateur (root ou bozo) :");
            string utilisateur = Console.ReadLine();
            Console.WriteLine("Saisissez le mot de passe associé :");
            string mdp = Console.ReadLine();
            string connectionString = $"SERVER=localhost;PORT=3306;DATABASE=VéloMax;UID={utilisateur};PASSWORD={mdp};";
            MySqlConnection connection = new MySqlConnection(connectionString);
            Console.Clear();
            Console.WriteLine("Bienvenue !");
            Console.WriteLine("");
            bool boucle = true;
            //bool boucle2 = true;
            while (boucle)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("");
                Console.WriteLine("1 : Démo");
                Console.WriteLine("2 : Gestion du stock");
                Console.WriteLine("3 : Gestion des fournisseurs");
                Console.WriteLine("4 : Gestion des pièces détachées");
                Console.WriteLine("5 : Gestion des vélos");
                Console.WriteLine("6 : Gestion des clients");
                Console.WriteLine("7 : Gestion des commandes");
                Console.WriteLine("8 : Export en Json ou Xml");
                Console.WriteLine("9 : Module Statistiques");
                Console.WriteLine("10 : Autres requêtes");
                int choix = Convert.ToInt32(Console.ReadLine());
                switch (choix)
                {
                    case 1:
                        {
                            démo(connection);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("------------------");
                            Console.WriteLine("1 : Aperçu des stocks par pièce");
                            Console.WriteLine("2 : Aperçu des stocks par fournisseur");
                            Console.WriteLine("3 : Aperçu des stocks par vélo");
                            Console.WriteLine("4 : Aperçu des stocks par catégorie de vélo");
                            Console.WriteLine("5 : Aperçu des stocks par grandeur");
                            Console.WriteLine("6 : Aperçu des stocks par prix unitaire");
                            Console.WriteLine("autre nombre : Retour à l'accueil");
                            int choix2 = Convert.ToInt32(Console.ReadLine());
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        stockPiece(connection);
                                        break;
                                    }
                                case 2:
                                    {
                                        stockFournisseur(connection);
                                        break;
                                    }
                                case 3:
                                    {
                                        stockVelo(connection);
                                        break;
                                    }
                                case 4:
                                    {
                                        stockCatégorieVelo(connection);
                                        break;
                                    }
                                case 5:
                                    {
                                        stockGrandeurVelo(connection);
                                        break;
                                    }
                                case 6:
                                    {
                                        stockPrixUnitaire(connection);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("------------------");
                            Console.WriteLine("1 : Affichage des fournisseurs");
                            Console.WriteLine("2 : Création d'un fournisseur");
                            Console.WriteLine("3 : Suppression d'un fournisseur");
                            Console.WriteLine("4 : Mise à jour d'un fournisseur");
                            int choix2 = Convert.ToInt32(Console.ReadLine());
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        affichageFournisseur(connection);
                                        break;
                                    }
                                case 2:
                                    {
                                        creationFournisseur(connection);
                                        break;
                                    }
                                case 3:
                                    {
                                        suppressionFournisseur(connection);
                                        break;
                                    }
                                case 4:
                                    {
                                        majFournisseur(connection);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("------------------");
                            Console.WriteLine("1 : Affichage des pièces détachées");
                            Console.WriteLine("2 : Création d'une pièce détachée");
                            Console.WriteLine("3 : Suppression d'une pièce détachée");
                            Console.WriteLine("4 : Mise à jour d'une pièce détachée");
                            int choix2 = Convert.ToInt32(Console.ReadLine());
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        affichagePieceD(connection);
                                        break;
                                    }
                                case 2:
                                    {
                                        creationPieceD(connection);
                                        break;
                                    }
                                case 3:
                                    {
                                        suppressionPieceD(connection);
                                        break;
                                    }
                                case 4:
                                    {
                                        majPieceD(connection);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("------------------");
                            Console.WriteLine("1 : Affichage des vélos");
                            Console.WriteLine("2 : Création d'un vélo");
                            Console.WriteLine("3 : Suppression d'un vélo ");
                            Console.WriteLine("4 : Mise à jour d'un vélo");
                            int choix2 = Convert.ToInt32(Console.ReadLine());
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        affichageVelo(connection);
                                        break;
                                    }
                                case 2:
                                    {
                                        creationVelo(connection);
                                        break;
                                    }
                                case 3:
                                    {
                                        suppressionVelo(connection);
                                        break;
                                    }
                                case 4:
                                    {
                                        majVelo(connection);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("------------------");
                            Console.WriteLine("1 : Affichage des clients");
                            Console.WriteLine("2 : Création d'un client");
                            Console.WriteLine("3 : Suppression d'un client ");
                            Console.WriteLine("4 : Mise à jour d'un client");
                            int choix2 = Convert.ToInt32(Console.ReadLine());
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        affichageClient(connection);
                                        break;
                                    }
                                case 2:
                                    {
                                        creationClient(connection);
                                        break;
                                    }
                                case 3:
                                    {
                                        suppressionClient(connection);
                                        break;
                                    }
                                case 4:
                                    {
                                        majClient(connection);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine("------------------");
                            Console.WriteLine("1 : Affichage des commandes");
                            Console.WriteLine("2 : Création d'une commande");
                            Console.WriteLine("3 : Suppression d'une commande ");
                            Console.WriteLine("4 : Mise à jour d'une commande");
                            int choix2 = Convert.ToInt32(Console.ReadLine());
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        affichageCommande(connection);
                                        break;
                                    }
                                case 2:
                                    {
                                        creationCommande(connection);
                                        break;
                                    }
                                case 3:
                                    {
                                        suppressionCommande(connection);
                                        break;
                                    }
                                case 4:
                                    {
                                        majCommande(connection);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            toJson(connection);
                            break;
                        }
                    case 9:
                        {
                            Console.Clear();
                            Console.WriteLine("------------------");
                            Console.WriteLine("1 : Quantités vendues de chaque item de l’inventaire");
                            Console.WriteLine("2 : Liste des membres pour chaque programme Fidélio");
                            Console.WriteLine("3 : Analyse des commandes ");
                            Console.WriteLine("4 : Meilleur client");
                            int choix2 = Convert.ToInt32(Console.ReadLine());
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        quantitesVendues(connection);
                                        break;
                                    }
                                case 2:
                                    {
                                        listeMembres(connection);
                                        break;
                                    }
                                case 3:
                                    {
                                        analyseCommande(connection);
                                        break;
                                    }
                                case 4:
                                    {
                                        meilleurClient(connection);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 10:
                        {
                            Console.Clear();
                            Console.WriteLine("------------------");
                            Console.WriteLine("1 : Requête synchronisée : donne les vélos dont le prix est inférieur au prix moyen de tous les vélos");
                            Console.WriteLine("2 : Requête avec auto-jointure : donne des paires de vélos qui ont le même prix ");
                            Console.WriteLine("3 : Requête avec union : donne les vélos qui coûtent moins de 200€ et n'ont pas d'ordinateur ET les vélos qui ont un ordinateur (sans limite de prix)");
                            int choix2 = Convert.ToInt32(Console.ReadLine());
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        requeteSynchro(connection);
                                        break;
                                    }
                                case 2:
                                    {
                                        requeteAutoJ(connection);
                                        break;
                                    }
                                case 3:
                                    {
                                        requeteUnion(connection);
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
        }

        static void stockPiece(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT DescPiece AS Nom , count(*) AS Nombre FROM PiècesD P GROUP BY P.DescPiece";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string desc = reader.GetString(0);
                int quantite = reader.GetInt32(1);

                Console.WriteLine($"{quantite} {desc} en stock");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            
            co.Close();
        }

        static void démo(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT count(*) FROM client";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string nombre = reader.GetString(0);

                Console.WriteLine($"Il y a {nombre} clients");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();

            co.Open();
            command.CommandText = "SELECT distinct(nomIndiv), sum(prixUP*stock+prixUV) FROM client " +
                "join Commande on client.Id_Client = commande.Id_Client " +
                "join Contient_PiècesD on Contient_PiècesD.NumC = commande.NumC " +
                "join Contient_Vélo on Contient_Vélo.numC = commande.NumC " +
                "natural join bicyclette " +
                "natural join PiècesD " +
                "WHERE nomIndiv is not null GROUP BY commande.NumC;";
            Console.WriteLine("Parmis ces clients: ");
            Console.WriteLine();
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string nom = reader.GetString(0);
                int somme = reader.GetInt32(1);
                Console.WriteLine($"{nom} à un total de {somme} euros de commandes");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();

            co.Open();
            command.CommandText = "SELECT distinct(nomCompagnie), sum(prixUP*stock+prixUV) FROM client " +
                "join Commande on client.Id_Client = commande.Id_Client " +
                "join Contient_PiècesD on Contient_PiècesD.NumC = commande.NumC " +
                "join Contient_Vélo on Contient_Vélo.numC = commande.NumC " +
                "natural join bicyclette " +
                "natural join PiècesD " +
                "WHERE nomCompagnie is not null GROUP BY commande.NumC;";
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string nom = reader.GetString(0);
                int somme = reader.GetInt32(1);
                Console.WriteLine($"{nom} à un total de {somme} euros de commandes");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();

            co.Open();
            command.CommandText = "SELECT NumP, DescPiece, stock FROM PiècesD WHERE stock <= 2;";
            reader = command.ExecuteReader();
            Console.WriteLine("Pièces détachées dont la quantité en stock est inférieure ou égale à 2");
            Console.WriteLine();
            while (reader.Read())// parcours ligne par ligne
            {
                string nom = reader.GetString(0);
                string desc = reader.GetString(1);
                int stock = reader.GetInt32(2);
                Console.WriteLine($"{nom} {desc}, quantité restante: {stock}");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();

            co.Open();
            command.CommandText = "SELECT NomE , count(NumP) AS NombrePiece FROM Fournisseur NATURAL JOIN Fournit GROUP BY Siret;";
            reader = command.ExecuteReader();
            Console.WriteLine("Liste des différents fournisseurs et le nombre de pièces qu'ils fournissent");
            Console.WriteLine();
            while (reader.Read())// parcours ligne par ligne
            {
                string nom = reader.GetString(0);
                int stock = reader.GetInt32(1);
                Console.WriteLine($"{nom} fournit {stock} pièces détachées");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();

            co.Open();
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('id_Client', id_Client, 'tel', tel,'NomCompagnie', NomCompagnie,'NomIndiv', NomIndiv,'Id_Adresse', Id_Adresse, 'NumProg', NumProg)) from Client INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/client.json';";
            Console.WriteLine("Le fichier client.json a bien été créé");
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void stockFournisseur(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT NomE , count(NumP) AS NombrePiece FROM Fournisseur NATURAL JOIN Fournit GROUP BY Siret; ";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string NomE = reader.GetString(0);
                int NombrePiece = reader.GetInt32(1);

                Console.WriteLine($"{NomE} : {NombrePiece} pièces différentes en stock");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void stockVelo(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT NomV, count(*) FROM Bicyclette GROUP BY NomV;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string NomV = reader.GetString(0);
                int NombreVelo = reader.GetInt32(1);

                Console.WriteLine($"{NombreVelo} vélos {NomV} en stock");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void stockCatégorieVelo(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT Ligne, count(*) FROM Bicyclette GROUP BY Ligne;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string Ligne = reader.GetString(0);
                int NombreVelo = reader.GetInt32(1);

                Console.WriteLine($"{NombreVelo} vélos de catégorie {Ligne} en stock");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void stockGrandeurVelo(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT GrandeurV, count(*) FROM Bicyclette GROUP BY GrandeurV;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string GrandeurV = reader.GetString(0);
                int NombreVelo = reader.GetInt32(1);

                Console.WriteLine($"{NombreVelo} vélos de grandeur {GrandeurV} en stock");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void stockPrixUnitaire(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT PrixUV, count(*) FROM Bicyclette GROUP BY PrixUV ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string PrixUV = reader.GetString(0);
                int NombreVelo = reader.GetInt32(1);

                Console.WriteLine($"{NombreVelo} vélos à {PrixUV} euros en stock");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void affichageFournisseur(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();

            command.CommandText = "SELECT * FROM Fournisseur;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Nom :" + reader.GetString(1));
                Console.WriteLine("Siret :" + reader.GetString(0));
                Console.WriteLine("Adresse mail contact :" + reader.GetString(2));
                Console.WriteLine("Adresse :" + reader.GetString(3));
                Console.WriteLine("Libelle :" + reader.GetInt32(4));
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void creationFournisseur(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();

            Console.WriteLine("Merci d'entrer les informations du fournisseur à créer.");
            Console.WriteLine("Nom");
            string nom = Console.ReadLine();
            Console.WriteLine("Siret");
            string siret = Console.ReadLine();
            Console.WriteLine("Adresse mail contact");
            string tel = Console.ReadLine();
            Console.WriteLine("Adresse");
            string adresse = Console.ReadLine();
            Console.WriteLine("Libelle (1 : très bon, 2 : bon, 3 : moyen, 4 : mauvais)");
            int libelle = Convert.ToInt32(Console.ReadLine());

            command.CommandText = "INSERT INTO Fournisseur VALUES(@Siret,@NomE,@ContactE , @AddE ,@Libellé);";

            command.Parameters.Add(new MySqlParameter("@NomE", nom));
            command.Parameters.Add(new MySqlParameter("@Siret", siret));
            command.Parameters.Add(new MySqlParameter("@ContactE", tel));
            command.Parameters.Add(new MySqlParameter("@AddE", adresse));
            command.Parameters.Add(new MySqlParameter("@Libellé", libelle));
            command.ExecuteNonQuery();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void suppressionFournisseur(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command1 = co.CreateCommand();
            MySqlCommand command2 = co.CreateCommand();
            MySqlCommand command3 = co.CreateCommand();
            Console.WriteLine("Liste des Fournisseurs");
            Console.WriteLine("");
            affichageFournisseur(co);
            Console.WriteLine("Quel fournisseur voulez-vous supprimer ? (Nom)");
            string nom = Console.ReadLine();

            co.Open();
            command1.CommandText = "DELETE FROM Fournisseur WHERE NomE = @NomE;";
            command1.Parameters.Add(new MySqlParameter("@NomE", nom));
            command2.CommandText = "DELETE FROM Fournit WHERE Siret NOT IN (SELECT Siret FROM Fournisseur WHERE NomE = @NomE);";
            command2.Parameters.Add(new MySqlParameter("@NomE", nom));
            command2.CommandText = "DELETE FROM PiècesD WHERE NumP NOT IN (SELECT NumP FROM Fournit);";
            command3.Parameters.Add(new MySqlParameter("@NomE", nom));
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void majFournisseur(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command = co.CreateCommand();
            Console.WriteLine("Liste des Fournisseurs");
            Console.WriteLine("");
            affichageFournisseur(co);
            Console.WriteLine("Quel fournisseur voulez-vous mettre à jour ? (Nom)");
            string nom = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("MAJ : ");
            Console.WriteLine("1 : du nom");
            Console.WriteLine("2 : du Siret");
            Console.WriteLine("3 : de l'adresse mail contact");
            Console.WriteLine("4 : de l'adresse");
            Console.WriteLine("5 : du libellé");
            int nb = Convert.ToInt32(Console.ReadLine());
            co.Open();
            switch (nb)
            {
                case 1:
                    command.CommandText = "UPDATE Fournisseur SET NomE = @nouvnom WHERE NomE=@NomE;";
                    Console.WriteLine("Nouveau nom : ");
                    string nouvnom = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NomE", nom));
                    command.Parameters.Add(new MySqlParameter("@nouvnom", nouvnom));
                    command.ExecuteNonQuery();
                    break;
                case 2:
                    command.CommandText = "UPDATE Fournisseur SET Siret = @Siret WHERE NomE=@NomE;";
                    Console.WriteLine("Nouveau Siret : ");
                    string siret = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NomE", nom));
                    command.Parameters.Add(new MySqlParameter("@Siret", siret));
                    command.ExecuteNonQuery();
                    break;
                case 3:
                    command.CommandText = "UPDATE Fournisseur SET ContactE = @ContactE WHERE NomE=@NomE;";
                    Console.WriteLine("Nouveau mail : ");
                    string mail = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NomE", nom));
                    command.Parameters.Add(new MySqlParameter("@ContectE", mail));
                    command.ExecuteNonQuery();
                    break;
                case 4:
                    command.CommandText = "UPDATE Fournisseur SET AddE = @AddE WHERE NomE=@NomE;";
                    Console.WriteLine("Nouvelle adresse : ");
                    string adresse = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NomE", nom));
                    command.Parameters.Add(new MySqlParameter("@AddE", adresse));
                    command.ExecuteNonQuery();
                    break;
                case 5:
                    command.CommandText = "UPDATE Fournisseur SET Libellé = @Libelle WHERE NomE=@NomE;";
                    Console.WriteLine("Nouveau libellé : ");
                    string libelle = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NomE", nom));
                    command.Parameters.Add(new MySqlParameter("@Libelle", libelle));
                    command.ExecuteNonQuery();
                    break;
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void affichagePieceD(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();

            command.CommandText = "SELECT * FROM PiècesD;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Numéro Pièce :" + reader.GetString(1));
                Console.WriteLine("Description :" + reader.GetString(0));
                Console.WriteLine("Date d'introduction :" + reader.GetString(2));
                Console.WriteLine("Date de discontinuation :" + reader.GetString(3));
                Console.WriteLine("Nom Fournisseur :" + reader.GetString(4));
                Console.WriteLine("Numéro Catalogue :" + reader.GetString(5));
                Console.WriteLine("Prix Unitaire :" + reader.GetString(6));
                Console.WriteLine("Stock :" + reader.GetInt32(7));
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void creationPieceD(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();

            Console.WriteLine("Merci d'entrer les informations de la pièce à créer.");
            Console.WriteLine("Numéro Pièce");
            string numP = Console.ReadLine();
            Console.WriteLine("Description");
            string description = Console.ReadLine();
            Console.WriteLine("Date d'introduction");
            string dateI = Console.ReadLine();
            Console.WriteLine("Date de discontinuation");
            string dateD = Console.ReadLine();
            Console.WriteLine("Nom Fournisseur");
            string nomF = Console.ReadLine();
            Console.WriteLine("Numéro Catalogue");
            string numCata = Console.ReadLine();
            Console.WriteLine("Prix Unitaire");
            int prixUP = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Stock");
            int stock = Convert.ToInt32(Console.ReadLine());

            command.CommandText = "INSERT INTO PiècesD VALUES(@NumP,@DescPiece,@DateIP , @DateDP ,@NomF,@NumCata,@PrixUP, @Stock);";
            command.Parameters.Add(new MySqlParameter("@NumP", numP));
            command.Parameters.Add(new MySqlParameter("@DescPiece", description));
            command.Parameters.Add(new MySqlParameter("@DateIP", dateI));
            command.Parameters.Add(new MySqlParameter("@DateDP", dateD));
            command.Parameters.Add(new MySqlParameter("@NomF", nomF));
            command.Parameters.Add(new MySqlParameter("@NumCata", numCata));
            command.Parameters.Add(new MySqlParameter("@PrixUP", prixUP));
            command.Parameters.Add(new MySqlParameter("@Stock", stock));
            command.ExecuteNonQuery();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void suppressionPieceD(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command = co.CreateCommand();
            Console.WriteLine("Liste des Pièces détachées");
            Console.WriteLine("");
            affichagePieceD(co);
            Console.WriteLine("Quel pièce détachée voulez-vous supprimer ? (Numéro Pièce)");
            string numP = Console.ReadLine();

            co.Open();
            command.CommandText = "DELETE FROM PiècesD WHERE NumP = @NumP;";
            command.Parameters.Add(new MySqlParameter("@NumP", numP));
            command.ExecuteNonQuery();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void majPieceD(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command = co.CreateCommand();
            Console.WriteLine("Liste des Pièces détachées");
            Console.WriteLine("");
            affichagePieceD(co);
            Console.WriteLine("Quel pièce détachée voulez-vous mettre à jour ? (Numéro Pièce)");
            string numP = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("MAJ : ");
            Console.WriteLine("1 : du numéro");
            Console.WriteLine("2 : de la description");
            Console.WriteLine("3 : de la date d'introduction");
            Console.WriteLine("4 : de la date de discontinuation");
            Console.WriteLine("5 : du nom du fournisseur");
            Console.WriteLine("6 : du numéro catalogue");
            Console.WriteLine("7 : du prix unitaire");
            Console.WriteLine("8 : du stock");

            int nb = Convert.ToInt32(Console.ReadLine());
            co.Open();
            switch (nb)
            {
                case 1:
                    command.CommandText = "UPDATE PiècesD SET NumP = @nouvNumP WHERE NumP=@NumP;";
                    Console.WriteLine("Nouveau numéro : ");
                    string nouvnumP = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumP", numP));
                    command.Parameters.Add(new MySqlParameter("@nouvNumP", nouvnumP));
                    command.ExecuteNonQuery();
                    break;
                case 2:
                    command.CommandText = "UPDATE PiècesD SET DescPiece = @DescPiece WHERE NumP=@NumP;";
                    Console.WriteLine("Nouvelle description : ");
                    string desc = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumP", numP));
                    command.Parameters.Add(new MySqlParameter("@DescPiece", desc));
                    command.ExecuteNonQuery();
                    break;
                case 3:
                    command.CommandText = "UPDATE PiècesD SET DateIP = @DateIP WHERE NumP=@NumP;";
                    Console.WriteLine("Nouvelle date d'introduction : ");
                    string dateI = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumP", numP));
                    command.Parameters.Add(new MySqlParameter("@DateIP", dateI));
                    command.ExecuteNonQuery();
                    break;
                case 4:
                    command.CommandText = "UPDATE PiècesD SET DateDP = @DateDP WHERE NumP=@NumP;";
                    Console.WriteLine("Nouvelle date de discontinuation : ");
                    string dateD = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumP", numP));
                    command.Parameters.Add(new MySqlParameter("@DateIP", dateD));
                    command.ExecuteNonQuery();
                    break;
                case 5:
                    command.CommandText = "UPDATE PiècesD SET NomF = @NomF WHERE NumP=@NumP;";
                    Console.WriteLine("Nouveau fournisseur : ");
                    string nomF = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumP", numP));
                    command.Parameters.Add(new MySqlParameter("@NomF", nomF));
                    command.ExecuteNonQuery();
                    break;
                case 6:
                    command.CommandText = "UPDATE PiècesD SET NumCata = @NumCata WHERE NumP=@NumP;";
                    Console.WriteLine("Nouveau numéro catalogue : ");
                    string numCata = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumP", numP));
                    command.Parameters.Add(new MySqlParameter("@NumCata", numCata));
                    command.ExecuteNonQuery();
                    break;
                case 7:
                    command.CommandText = "UPDATE PiècesD SET PrixUP = @PrixUP WHERE NumP=@NumP;";
                    Console.WriteLine("Nouveau prix unitaire : ");
                    string prixUP = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumP", numP));
                    command.Parameters.Add(new MySqlParameter("@PrixUP", prixUP));
                    command.ExecuteNonQuery();
                    break;
                case 8:
                    command.CommandText = "UPDATE PiècesD SET Stock = @Stock WHERE NumP=@NumP;";
                    Console.WriteLine("Nouveau stock : ");
                    string stock = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumP", numP));
                    command.Parameters.Add(new MySqlParameter("@Stock", stock));
                    command.ExecuteNonQuery();
                    break;
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void affichageVelo(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();

            command.CommandText = "SELECT * FROM Bicyclette;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Numéro Vélo :" + reader.GetInt32(0));
                Console.WriteLine("Nom :" + reader.GetString(1));
                Console.WriteLine("Grandeur :" + reader.GetString(2));
                Console.WriteLine("Prix Unitaire :" + reader.GetInt32(3));
                Console.WriteLine("Date d'introduction :" + reader.GetString(4));
                Console.WriteLine("Date de discontinuation :" + reader.GetString(5));
                Console.WriteLine("Ligne :" + reader.GetString(6));
                Console.WriteLine("Cadre :" + reader.GetString(7));
                Console.WriteLine("Guidon :" + reader.GetString(8));
                Console.WriteLine("Freins :" + reader.GetString(9));
                Console.WriteLine("Selle :" + reader.GetString(10));
                Console.WriteLine("Dérailleur avant :" + reader.GetString(11));
                Console.WriteLine("Dérailleur arrière :" + reader.GetString(12));
                Console.WriteLine("Roue avant :" + reader.GetString(13));
                Console.WriteLine("Roue arrière :" + reader.GetString(14));
                Console.WriteLine("Réflecteurs :" + reader.GetString(15));
                Console.WriteLine("Pédalier :" + reader.GetString(16));
                Console.WriteLine("Ordinateur :" + reader.GetString(17));
                Console.WriteLine("Panier :" + reader.GetString(18));

                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void creationVelo(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();

            Console.WriteLine("Merci d'entrer les informations du vélo à créer.");
            Console.WriteLine("Numéro Vélo");
            int numV = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nom");
            string nomV = Console.ReadLine();
            Console.WriteLine("Grandeur");
            string grandeur = Console.ReadLine();
            Console.WriteLine("Prix unitaire");
            int prixUV = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Date d'introduction");
            string dateI = Console.ReadLine();
            Console.WriteLine("Date de discontinuation");
            string dateD = Console.ReadLine();
            Console.WriteLine("Ligne");
            string ligne = Console.ReadLine();
            Console.WriteLine("Cadre");
            string cadre = Console.ReadLine();
            Console.WriteLine("Guidon");
            string guidon = Console.ReadLine();
            Console.WriteLine("Freins");
            string freins = Console.ReadLine();
            Console.WriteLine("Selle");
            string selle = Console.ReadLine();
            Console.WriteLine("Dérailleur avant");
            string derav = Console.ReadLine();
            Console.WriteLine("Dérailleur arrière");
            string derarr = Console.ReadLine();
            Console.WriteLine("Roue avant");
            string roueav = Console.ReadLine();
            Console.WriteLine("Roue arrière");
            string rouearr = Console.ReadLine();
            Console.WriteLine("Réflecteurs");
            string refl = Console.ReadLine();
            Console.WriteLine("Pédalier");
            string pedalier = Console.ReadLine();
            Console.WriteLine("Ordinateur");
            string ordi = Console.ReadLine();
            Console.WriteLine("Panier");
            string panier = Console.ReadLine();

            command.CommandText = "INSERT INTO Bicyclette VALUES(@NumV ,@NomV ,@GrandeurV,@PrixUV,@DateIM,@DateDM,@Ligne, @Cadre, @Guidon, @Freins, @Selle, @Derailleur_Avant, @Derailleur_Arrière, @Roue_Avant, @Roue_Arrière, @Reflecteurs, @Pedalier, @Ordinateur, @Panier)";
            command.Parameters.Add(new MySqlParameter("@NumV", numV));
            command.Parameters.Add(new MySqlParameter("@NomV", nomV));
            command.Parameters.Add(new MySqlParameter("@GrandeurV", grandeur));
            command.Parameters.Add(new MySqlParameter("@PrixUV", prixUV));
            command.Parameters.Add(new MySqlParameter("@DateIM", dateI));
            command.Parameters.Add(new MySqlParameter("@DateDM", dateD));
            command.Parameters.Add(new MySqlParameter("@Ligne", ligne));
            command.Parameters.Add(new MySqlParameter("@Cadre", cadre));
            command.Parameters.Add(new MySqlParameter("@Guidon", guidon));
            command.Parameters.Add(new MySqlParameter("@Freins", freins));
            command.Parameters.Add(new MySqlParameter("@Selle", selle));
            command.Parameters.Add(new MySqlParameter("@Derailleur_Avant", derav));
            command.Parameters.Add(new MySqlParameter("@Derailleur_Arrière", derarr));
            command.Parameters.Add(new MySqlParameter("@Roue_Avant", roueav));
            command.Parameters.Add(new MySqlParameter("@Roue_Arrière", rouearr));
            command.Parameters.Add(new MySqlParameter("@Reflecteurs", refl));
            command.Parameters.Add(new MySqlParameter("@Pedalier", pedalier));
            command.Parameters.Add(new MySqlParameter("@Ordinateur", ordi));
            command.Parameters.Add(new MySqlParameter("@Panier", panier));

            command.ExecuteNonQuery();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void suppressionVelo(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command = co.CreateCommand();
            Console.WriteLine("Liste des Vélos");
            Console.WriteLine("");
            affichageVelo(co);
            Console.WriteLine("Quel vélo voulez-vous supprimer ? (Numéro Vélo)");
            string numV = Console.ReadLine();

            co.Open();
            command.CommandText = "DELETE FROM Bicyclette WHERE NumV = @NumV;";
            command.Parameters.Add(new MySqlParameter("@NumV", numV));
            command.ExecuteNonQuery();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void majVelo(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command = co.CreateCommand();
            Console.WriteLine("Liste des Vélos");
            Console.WriteLine("");
            affichageVelo(co);
            Console.WriteLine("Quel vélo voulez-vous mettre à jour ? (Numéro Vélo)");
            string numV = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("MAJ : ");
            Console.WriteLine("1 : du numéro");
            Console.WriteLine("2 : de la description");
            Console.WriteLine("3 : du prix unitaire");
            Console.WriteLine("4 : de la date d'introduction");
            Console.WriteLine("5 : de la date de discontinuation");
            Console.WriteLine("6 : de la ligne");
            Console.WriteLine("7 : du cadre");
            Console.WriteLine("8 : du guidon");
            Console.WriteLine("9 : des freins");
            Console.WriteLine("10 : de la selle");
            Console.WriteLine("11 : du dérailleur avant");
            Console.WriteLine("12 : du dérailleur arrière");
            Console.WriteLine("13 : de la roue avant");
            Console.WriteLine("14 : de la roue arrière");
            Console.WriteLine("15 : des réflecteurs");
            Console.WriteLine("16 : du pédalier");
            Console.WriteLine("17 : de l'ordinateur");
            Console.WriteLine("18 : du panier");

            int nb = Convert.ToInt32(Console.ReadLine());
            co.Open();
            switch (nb)
            {
                case 1:
                    command.CommandText = "UPDATE Bicyclette SET NomV = @NomV WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string nomV = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@NomV", nomV));
                    command.ExecuteNonQuery();
                    break;
                case 2:
                    command.CommandText = "UPDATE Bicyclette SET GrandeurV = @GrandeurV WHERE NumV=@NumV;";
                    Console.WriteLine("Nouvelle grandeur : ");
                    string grandeur = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@GrandeurV", grandeur));
                    command.ExecuteNonQuery();
                    break;
                case 3:
                    command.CommandText = "UPDATE Bicyclette SET PrixUV = @PrixUV WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau prix unitaire : ");
                    string prixUV = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@PrixUV", prixUV));
                    command.ExecuteNonQuery();
                    break;
                case 4:
                    command.CommandText = "UPDATE Bicyclette SET DateIM = @DateIM WHERE NumV=@NumV;";
                    Console.WriteLine("Nouvelle date d'intro : ");
                    string dateI = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@DateIM", dateI));
                    command.ExecuteNonQuery();
                    break;
                case 5:
                    command.CommandText = "UPDATE Bicyclette SET DateDM = @DateDM WHERE NumV=@NumV;";
                    Console.WriteLine("Nouvelle date de discontinuation : ");
                    string dateD = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@DateDM", dateD));
                    command.ExecuteNonQuery();
                    break;
                case 6:
                    command.CommandText = "UPDATE Bicyclette SET Ligne = @Ligne WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string ligne = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Ligne", ligne));
                    command.ExecuteNonQuery();
                    break;
                case 7:
                    command.CommandText = "UPDATE Bicyclette SET Cadre = @Cadre WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau cadre : ");
                    string Cadre = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Cadre", Cadre));
                    command.ExecuteNonQuery();
                    break;
                case 8:
                    command.CommandText = "UPDATE Bicyclette SET Guidon = @Guidon WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau guidon : ");
                    string Guidon = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Guidon", Guidon));
                    command.ExecuteNonQuery();
                    break;
                case 9:
                    command.CommandText = "UPDATE Bicyclette SET Freins = @Freins WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveaux freins : ");
                    string Freins = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Freins", Freins));
                    command.ExecuteNonQuery();
                    break;
                case 10:
                    command.CommandText = "UPDATE Bicyclette SET Selle = @Selle WHERE NumV=@NumV;";
                    Console.WriteLine("Nouvelle selle : ");
                    string Selle = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Selle", Selle));
                    command.ExecuteNonQuery();
                    break;
                case 11:
                    command.CommandText = "UPDATE Bicyclette SET Derailleur_Avant = @Derailleur_Avant WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Derailleur_Avant = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Derailleur_Avant", Derailleur_Avant));
                    command.ExecuteNonQuery();
                    break;
                case 12:
                    command.CommandText = "UPDATE Bicyclette SET Derailleur_Arrière = @Derailleur_Arrière WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Derailleur_Arrière = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@Derailleur_Arrière", numV));
                    command.Parameters.Add(new MySqlParameter("@Derailleur_Arrière", Derailleur_Arrière));
                    command.ExecuteNonQuery();
                    break;
                case 13:
                    command.CommandText = "UPDATE Bicyclette SET Roue_Avant = @Roue_Avant WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Roue_Avant = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Roue_Avant", Roue_Avant));
                    command.ExecuteNonQuery();
                    break;
                case 14:
                    command.CommandText = "UPDATE Bicyclette SET Roue_Arrière = @Roue_Arrière WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Roue_Arrière = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@NomRoue_ArrièreV", Roue_Arrière));
                    command.ExecuteNonQuery();
                    break;
                case 15:
                    command.CommandText = "UPDATE Bicyclette SET Reflecteurs = @Reflecteurs WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Reflecteurs = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Reflecteurs", Reflecteurs));
                    command.ExecuteNonQuery();
                    break;
                case 16:
                    command.CommandText = "UPDATE Bicyclette SET Pedalier = @Pedalier WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Pedalier = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Pedalier", Pedalier));
                    command.ExecuteNonQuery();
                    break;
                case 17:
                    command.CommandText = "UPDATE PiècesD SET Ordinateur = @Ordinateur WHERE NumP=@NumP;";
                    Console.WriteLine("Nouveau stock : ");
                    string Ordinateur = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumP", numV));
                    command.Parameters.Add(new MySqlParameter("@Ordinateur", Ordinateur));
                    command.ExecuteNonQuery();
                    break;
                case 18:
                    command.CommandText = "UPDATE Bicyclette SET Panier = @Panier WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Panier = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Panier", Panier));
                    command.ExecuteNonQuery();
                    break;
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void affichageClient(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command = co.CreateCommand();
            Console.WriteLine("1 : Afficher la liste des boutiques");
            Console.WriteLine("2 : Afficher la liste des individus");
            int nbc = Convert.ToInt32(Console.ReadLine());
            co.Open();
            switch (nbc)
            {
                case 1:
                    command.CommandText = "SELECT * FROM Client Natural Join Boutique Natural Join Adresse;";
                    MySqlDataReader reader;
                    reader = command.ExecuteReader();
                    while (reader.Read())// parcours ligne par ligne
                    {
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Numéro Client :" + reader.GetInt32(1));
                        Console.WriteLine("Nom de la Compagnie :" + reader.GetString(2));
                        Console.WriteLine("Téléphone :" + reader.GetString(3));
                        Console.WriteLine("Adresse mail :" + reader.GetString(4));
                        Console.WriteLine("Nom contact  :" + reader.GetString(7));
                        Console.WriteLine("Pourcentage de remise :" + reader.GetInt32(8));
                        Console.WriteLine("-----Adresse-----");
                        Console.WriteLine("Rue :" + reader.GetString(9));
                        Console.WriteLine("Ville :" + reader.GetString(10));
                        Console.WriteLine("Code Postal :" + reader.GetInt32(11));
                        Console.WriteLine("Province :" + reader.GetString(12));
                        Console.WriteLine("---------------------------------");
                    }
                    break;
                case 2:
                    command.CommandText = "SELECT * FROM Client Natural Join Individu Natural Join Adresse Natural Join Adhère;";
                    MySqlDataReader reader2;
                    reader2 = command.ExecuteReader();
                    while (reader2.Read())// parcours ligne par ligne
                    {
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Numéro Client :" + reader2.GetInt32(0));
                        Console.WriteLine("Nom du client :" + reader2.GetString(3));
                        Console.WriteLine("Prénom du client :" + reader2.GetString(7));
                        Console.WriteLine("Téléphone :" + reader2.GetString(4));
                        Console.WriteLine("Adresse mail :" + reader2.GetString(5));
                        Console.WriteLine("Programme Fidélio :" + reader2.GetInt32(1));
                        Console.WriteLine("Date d'adhésion au programme :" + reader2.GetString(12));
                        Console.WriteLine("Date de paiement du programme :" + reader2.GetString(13));
                        Console.WriteLine("-----Adresse-----");
                        Console.WriteLine("Rue :" + reader2.GetString(8));
                        Console.WriteLine("Ville :" + reader2.GetString(9));
                        Console.WriteLine("Code Postal :" + reader2.GetInt32(10));
                        Console.WriteLine("Province :" + reader2.GetString(11));
                        Console.WriteLine("---------------------------------");
                    }
                    break;
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void creationClient(MySqlConnection co)
        {
            Console.Clear();
            co.Open();

            Console.WriteLine("Merci d'entrer les informations du client à créer.");
            Console.WriteLine("Numéro client");
            int numC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Numéro de téléphone");
            string tel = Console.ReadLine();
            Console.WriteLine("Adresse mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Id de son adresse");
            int idAdresse = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Rue");
            string rue = Console.ReadLine();
            Console.WriteLine("Ville");
            string ville = Console.ReadLine();
            Console.WriteLine("Code Postal");
            int codeP = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Province");
            string province = Console.ReadLine();
            Console.WriteLine("Boutique ou Individu ?");
            string cli = Console.ReadLine();
            switch (cli)
            {
                case "boutique":
                    MySqlCommand command = co.CreateCommand();
                    MySqlCommand command2 = co.CreateCommand();
                    MySqlCommand command3 = co.CreateCommand();
                    MySqlCommand command4 = co.CreateCommand();
                    Console.WriteLine("Nom de la boutique");
                    string nomB = Console.ReadLine();
                    Console.WriteLine("Nom du contact");
                    string contact = Console.ReadLine();
                    Console.WriteLine("Adresse mail");
                    Console.WriteLine("Pourcentage de remise");
                    int remise = Convert.ToInt32(Console.ReadLine());
                    command.CommandText = "INSERT INTO Client values(@Id_Client, @tel, @Courriel, @NomCompagnie, null, @Id_Adresse, null);";
                    command2.CommandText = "INSERT INTO Boutique values(@Id_Client, @NomCompagnie, @NomContact, @Remise);";
                    command3.CommandText = "INSERT INTO Adresse Values(@Id_Adresse,@Rue, @Ville, @CodePostal, @Province);";
                    command4.CommandText = "INSERT INTO Affecte_Adresse Values(@Id_Client, @Id_Adresse);";
                    command.Parameters.Add(new MySqlParameter("@Id_Client", numC));
                    command.Parameters.Add(new MySqlParameter("@tel", tel));
                    command.Parameters.Add(new MySqlParameter("@Courriel", mail));
                    command.Parameters.Add(new MySqlParameter("@NomCompagnie", nomB));
                    command.Parameters.Add(new MySqlParameter("@Id_Adresse", idAdresse));
                    command.ExecuteNonQuery();

                    command2.Parameters.Add(new MySqlParameter("@Id_Client", numC));
                    command2.Parameters.Add(new MySqlParameter("@NomCompagnie", nomB));
                    command2.Parameters.Add(new MySqlParameter("@NomContact", contact));
                    command2.Parameters.Add(new MySqlParameter("@Remise", remise));

                    command3.Parameters.Add(new MySqlParameter("@Id_Adresse", idAdresse));
                    command3.Parameters.Add(new MySqlParameter("@Rue", rue));
                    command3.Parameters.Add(new MySqlParameter("@Ville", ville));
                    command3.Parameters.Add(new MySqlParameter("@CodePostal", codeP));
                    command3.Parameters.Add(new MySqlParameter("@Province", province));

                    command4.Parameters.Add(new MySqlParameter("@Id_Client", numC));
                    command4.Parameters.Add(new MySqlParameter("@Id_Adresse", idAdresse));

                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    command4.ExecuteNonQuery();

                    break;

                case "individu":
                    MySqlCommand command5 = co.CreateCommand();
                    MySqlCommand command6 = co.CreateCommand();
                    MySqlCommand command7 = co.CreateCommand();
                    MySqlCommand command8 = co.CreateCommand();
                    MySqlCommand command9 = co.CreateCommand();

                    Console.WriteLine("Nom du client");
                    string nomI = Console.ReadLine();
                    Console.WriteLine("Prénom du client");
                    string prenomI = Console.ReadLine();
                    Console.WriteLine("Adhésion à un programme Fidélio");
                    int progNum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Date d'adhésion");
                    string dateAdh = Console.ReadLine();
                    Console.WriteLine("Date de paiement");
                    string datePay = Console.ReadLine();
                    command5.CommandText = "INSERT INTO Client values(@Id_Client, @tel, @Courriel, null, @NomIndiv, @Id_Adresse, @NumProg);";
                    command6.CommandText = "INSERT INTO Individu Values(@Id_Client,@NomIndiv, @PrenomIndiv);";
                    command7.CommandText = "INSERT INTO Adhère Values(@Id_Client,@NumProg, @DateAdh, @DatePay);";
                    command8.CommandText = "INSERT INTO Adresse Values(@Id_Adresse,@Rue, @Ville, @CodePostal, @Province);";
                    command9.CommandText = "INSERT INTO Affecte_Adresse Values(@Id_Client, @Id_Adresse);";
                    command5.Parameters.Add(new MySqlParameter("@Id_Client", numC));
                    command5.Parameters.Add(new MySqlParameter("@tel", tel));
                    command5.Parameters.Add(new MySqlParameter("@Courriel", mail));
                    command5.Parameters.Add(new MySqlParameter("@NomIndiv", nomI));
                    command5.Parameters.Add(new MySqlParameter("@NumProg", progNum));
                    command5.Parameters.Add(new MySqlParameter("@Id_Adresse", idAdresse));

                    command6.Parameters.Add(new MySqlParameter("@Id_Client", numC));
                    command6.Parameters.Add(new MySqlParameter("@NomIndiv", nomI));
                    command6.Parameters.Add(new MySqlParameter("@PrenomIndiv", prenomI));

                    command7.Parameters.Add(new MySqlParameter("@Id_Client", numC));
                    command7.Parameters.Add(new MySqlParameter("@NumProg", progNum));
                    command7.Parameters.Add(new MySqlParameter("@DateAdh", dateAdh));
                    command7.Parameters.Add(new MySqlParameter("@DatePay", datePay));

                    command8.Parameters.Add(new MySqlParameter("@Id_Adresse", idAdresse));
                    command8.Parameters.Add(new MySqlParameter("@Rue", rue));
                    command8.Parameters.Add(new MySqlParameter("@Ville", ville));
                    command8.Parameters.Add(new MySqlParameter("@CodePostal", codeP));
                    command8.Parameters.Add(new MySqlParameter("@Province", province));

                    command9.Parameters.Add(new MySqlParameter("@Id_Client", numC));
                    command9.Parameters.Add(new MySqlParameter("@Id_Adresse", idAdresse));

                    command5.ExecuteNonQuery();
                    command6.ExecuteNonQuery();
                    command7.ExecuteNonQuery();
                    command8.ExecuteNonQuery();
                    command9.ExecuteNonQuery();
                    break;

            }



            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void suppressionClient(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command = co.CreateCommand();
            MySqlCommand command2 = co.CreateCommand();
            MySqlCommand command3 = co.CreateCommand();
            MySqlCommand command4 = co.CreateCommand();
            MySqlCommand command5 = co.CreateCommand();

            //Console.WriteLine("Liste des Clients");
            //Console.WriteLine("");
            //affichageClient(co);
            Console.WriteLine("Quel client voulez-vous supprimer ? (Numéro Client)");
            string numC = Console.ReadLine();

            co.Open();
            command.CommandText = "DELETE FROM Affecte_Adresse WHERE Id_Client = @Id_Client;";
            command.Parameters.Add(new MySqlParameter("@Id_Client", numC));
            command.ExecuteNonQuery();
            command2.CommandText = "DELETE FROM Boutique WHERE Id_Client = @Id_Client;";
            command2.Parameters.Add(new MySqlParameter("@Id_Client", numC));
            command2.ExecuteNonQuery();
            command3.CommandText = "DELETE FROM Individu WHERE Id_Client = @Id_Client;";
            command3.Parameters.Add(new MySqlParameter("@Id_Client", numC));
            command3.ExecuteNonQuery();
            command4.CommandText = "DELETE FROM Adhère WHERE Id_Client = @Id_Client;";
            command4.Parameters.Add(new MySqlParameter("@Id_Client", numC));
            command4.ExecuteNonQuery();
            command5.CommandText = "DELETE FROM Client WHERE Id_Client = @Id_Client;";
            command5.Parameters.Add(new MySqlParameter("@Id_Client", numC));
            command5.ExecuteNonQuery();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void majClient(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command = co.CreateCommand();
            Console.WriteLine("Liste des Vélos");
            Console.WriteLine("");
            affichageVelo(co);
            Console.WriteLine("Quel vélo voulez-vous mettre à jour ? (Numéro Vélo)");
            string numV = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("MAJ : ");
            Console.WriteLine("1 : du numéro");
            Console.WriteLine("2 : de la description");
            Console.WriteLine("3 : du prix unitaire");
            Console.WriteLine("4 : de la date d'introduction");
            Console.WriteLine("5 : de la date de discontinuation");
            Console.WriteLine("6 : de la ligne");
            Console.WriteLine("7 : du cadre");
            Console.WriteLine("8 : du guidon");
            Console.WriteLine("9 : des freins");
            Console.WriteLine("10 : de la selle");
            Console.WriteLine("11 : du dérailleur avant");
            Console.WriteLine("12 : du dérailleur arrière");
            Console.WriteLine("13 : de la roue avant");
            Console.WriteLine("14 : de la roue arrière");
            Console.WriteLine("15 : des réflecteurs");
            Console.WriteLine("16 : du pédalier");
            Console.WriteLine("17 : de l'ordinateur");
            Console.WriteLine("18 : du panier");

            int nb = Convert.ToInt32(Console.ReadLine());
            co.Open();
            switch (nb)
            {
                case 1:
                    command.CommandText = "UPDATE Bicyclette SET NomV = @NomV WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string nomV = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@NomV", nomV));
                    command.ExecuteNonQuery();
                    break;
                case 2:
                    command.CommandText = "UPDATE Bicyclette SET GrandeurV = @GrandeurV WHERE NumV=@NumV;";
                    Console.WriteLine("Nouvelle grandeur : ");
                    string grandeur = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@GrandeurV", grandeur));
                    command.ExecuteNonQuery();
                    break;
                case 3:
                    command.CommandText = "UPDATE Bicyclette SET PrixUV = @PrixUV WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau prix unitaire : ");
                    string prixUV = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@PrixUV", prixUV));
                    command.ExecuteNonQuery();
                    break;
                case 4:
                    command.CommandText = "UPDATE Bicyclette SET DateIM = @DateIM WHERE NumV=@NumV;";
                    Console.WriteLine("Nouvelle date d'intro : ");
                    string dateI = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@DateIM", dateI));
                    command.ExecuteNonQuery();
                    break;
                case 5:
                    command.CommandText = "UPDATE Bicyclette SET DateDM = @DateDM WHERE NumV=@NumV;";
                    Console.WriteLine("Nouvelle date de discontinuation : ");
                    string dateD = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@DateDM", dateD));
                    command.ExecuteNonQuery();
                    break;
                case 6:
                    command.CommandText = "UPDATE Bicyclette SET Ligne = @Ligne WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string ligne = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Ligne", ligne));
                    command.ExecuteNonQuery();
                    break;
                case 7:
                    command.CommandText = "UPDATE Bicyclette SET Cadre = @Cadre WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau cadre : ");
                    string Cadre = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Cadre", Cadre));
                    command.ExecuteNonQuery();
                    break;
                case 8:
                    command.CommandText = "UPDATE Bicyclette SET Guidon = @Guidon WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau guidon : ");
                    string Guidon = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Guidon", Guidon));
                    command.ExecuteNonQuery();
                    break;
                case 9:
                    command.CommandText = "UPDATE Bicyclette SET Freins = @Freins WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveaux freins : ");
                    string Freins = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Freins", Freins));
                    command.ExecuteNonQuery();
                    break;
                case 10:
                    command.CommandText = "UPDATE Bicyclette SET Selle = @Selle WHERE NumV=@NumV;";
                    Console.WriteLine("Nouvelle selle : ");
                    string Selle = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Selle", Selle));
                    command.ExecuteNonQuery();
                    break;
                case 11:
                    command.CommandText = "UPDATE Bicyclette SET Derailleur_Avant = @Derailleur_Avant WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Derailleur_Avant = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Derailleur_Avant", Derailleur_Avant));
                    command.ExecuteNonQuery();
                    break;
                case 12:
                    command.CommandText = "UPDATE Bicyclette SET Derailleur_Arrière = @Derailleur_Arrière WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Derailleur_Arrière = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@Derailleur_Arrière", numV));
                    command.Parameters.Add(new MySqlParameter("@Derailleur_Arrière", Derailleur_Arrière));
                    command.ExecuteNonQuery();
                    break;
                case 13:
                    command.CommandText = "UPDATE Bicyclette SET Roue_Avant = @Roue_Avant WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Roue_Avant = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Roue_Avant", Roue_Avant));
                    command.ExecuteNonQuery();
                    break;
                case 14:
                    command.CommandText = "UPDATE Bicyclette SET Roue_Arrière = @Roue_Arrière WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Roue_Arrière = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@NomRoue_ArrièreV", Roue_Arrière));
                    command.ExecuteNonQuery();
                    break;
                case 15:
                    command.CommandText = "UPDATE Bicyclette SET Reflecteurs = @Reflecteurs WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Reflecteurs = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Reflecteurs", Reflecteurs));
                    command.ExecuteNonQuery();
                    break;
                case 16:
                    command.CommandText = "UPDATE Bicyclette SET Pedalier = @Pedalier WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Pedalier = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Pedalier", Pedalier));
                    command.ExecuteNonQuery();
                    break;
                case 17:
                    command.CommandText = "UPDATE PiècesD SET Ordinateur = @Ordinateur WHERE NumP=@NumP;";
                    Console.WriteLine("Nouveau stock : ");
                    string Ordinateur = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumP", numV));
                    command.Parameters.Add(new MySqlParameter("@Ordinateur", Ordinateur));
                    command.ExecuteNonQuery();
                    break;
                case 18:
                    command.CommandText = "UPDATE Bicyclette SET Panier = @Panier WHERE NumV=@NumV;";
                    Console.WriteLine("Nouveau nom : ");
                    string Panier = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command.Parameters.Add(new MySqlParameter("@Panier", Panier));
                    command.ExecuteNonQuery();
                    break;
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void affichageCommande(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();

            command.CommandText = "SELECT * FROM Commande JOIN Contient_PiècesD ON Contient_PiècesD.NumC=Commande.NumC JOIN Contient_Vélo ON Contient_Vélo.NumC=Commande.NumC;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Numéro de commande :" + reader.GetString(0));
                Console.WriteLine("Adresse de livraison :" + reader.GetString(1));
                Console.WriteLine("Date de livraison :" + reader.GetString(2));
                Console.WriteLine("Date de commande :" + reader.GetString(3));
                Console.WriteLine("Client à livrer :" + reader.GetInt32(4));
                Console.WriteLine("Pièce détachée :" + reader.GetString(6));
                Console.WriteLine("Quantité pièce détachée :" + reader.GetInt32(7));
                Console.WriteLine("Vélo :" + reader.GetInt32(9));
                Console.WriteLine("Quantité vélo :" + reader.GetInt32(10));
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void creationCommande(MySqlConnection co)
        {
            Console.Clear();
            co.Open();

            Console.WriteLine("Merci d'entrer les informations de la commande à créer.");
            Console.WriteLine("Numéro de commande");
            int numC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Adresse de livraison");
            string addL = Console.ReadLine();
            Console.WriteLine("Date de livraison");
            string dateL = Console.ReadLine();
            Console.WriteLine("Date de commande");
            string dateC = Console.ReadLine();
            Console.WriteLine("Id du client");
            int idClient = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ajouter une pièce ou un vélo ?");
            string com = Console.ReadLine();
            switch (com)
            {
                case "pièce":
                    MySqlCommand command = co.CreateCommand();
                    MySqlCommand command2 = co.CreateCommand();
                    Console.WriteLine("Numéro de la pièce");
                    string numP = Console.ReadLine();
                    Console.WriteLine("Quantité");
                    int quantite = Convert.ToInt32(Console.ReadLine());

                    command.CommandText = "INSERT INTO Commande VALUES(@NumC,@AddLiv,@DateL , @DateC, @Id_Client);";
                    command2.CommandText = "INSERT INTO Contient_PiècesD VALUES(@NumC,@NumP,@Quantite_PiècesD);";
                    command.Parameters.Add(new MySqlParameter("@NumC", numC));
                    command.Parameters.Add(new MySqlParameter("@AddLiv", addL));
                    command.Parameters.Add(new MySqlParameter("@DateL", dateL));
                    command.Parameters.Add(new MySqlParameter("@DateC", dateC));
                    command.Parameters.Add(new MySqlParameter("@Id_Client", idClient));
                    command.ExecuteNonQuery();

                    command2.Parameters.Add(new MySqlParameter("@NumC", numC));
                    command2.Parameters.Add(new MySqlParameter("@NumP", numP));
                    command2.Parameters.Add(new MySqlParameter("@Quantite_PiècesD", quantite));
                    command2.ExecuteNonQuery();
                    break;

                case "vélo":
                    MySqlCommand command3 = co.CreateCommand();
                    MySqlCommand command4 = co.CreateCommand();

                    Console.WriteLine("Numéro du vélo");
                    int numV = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quantité");
                    int quantiteV = Convert.ToInt32(Console.ReadLine());

                    command3.CommandText = "INSERT INTO Commande VALUES(@NumC,@AddLiv,@DateL , @DateC, @Id_Client);";
                    command4.CommandText = "INSERT INTO Contient_Vélo VALUES(@NumC,@NumV,@Quantite_Vélo);";
                    command3.Parameters.Add(new MySqlParameter("@NumC", numC));
                    command3.Parameters.Add(new MySqlParameter("@AddLiv", addL));
                    command3.Parameters.Add(new MySqlParameter("@DateL", dateL));
                    command3.Parameters.Add(new MySqlParameter("@DateC", dateC));
                    command3.Parameters.Add(new MySqlParameter("@Id_Client", idClient));
                    command3.ExecuteNonQuery();

                    command4.Parameters.Add(new MySqlParameter("@NumC", numC));
                    command4.Parameters.Add(new MySqlParameter("@NumV", numV));
                    command4.Parameters.Add(new MySqlParameter("@Quantite_Vélo", quantiteV));
                    command4.ExecuteNonQuery();
                    break;
            }

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void suppressionCommande(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command = co.CreateCommand();
            Console.WriteLine("Quel commande voulez-vous supprimer ? (Numéro de commande)");
            int numC = Convert.ToInt32(Console.ReadLine());

            co.Open();
            command.CommandText = "DELETE FROM Commande WHERE NumC = @NumC;";
            command.Parameters.Add(new MySqlParameter("@NumC", numC));

            command.ExecuteNonQuery();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void majCommande(MySqlConnection co)
        {
            Console.Clear();
            MySqlCommand command = co.CreateCommand();
            Console.WriteLine("Quel commande voulez-vous mettre à jour ? (Numéro de commande)");
            int numC = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("MAJ : ");
            Console.WriteLine("1 : de l'adresse de livraison");
            Console.WriteLine("2 : de la date de livraison");
            Console.WriteLine("3 : de la date de commande");
            Console.WriteLine("4 : de l'id client");

            int nb = Convert.ToInt32(Console.ReadLine());
            co.Open();
            switch (nb)
            {
                case 1:
                    command.CommandText = "UPDATE Commande SET AddLiv = @AddLiv WHERE NumC=@NumC;";
                    Console.WriteLine("Nouvelle addresse de livraison : ");
                    string addL = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumC", numC));
                    command.Parameters.Add(new MySqlParameter("@AddLiv", addL));
                    command.ExecuteNonQuery();
                    break;
                case 2:
                    command.CommandText = "UPDATE Commande SET DateL = @DateL WHERE NumC=@NumC;";
                    Console.WriteLine("Nouvelle date de livraison : ");
                    string dateL = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumC", numC));
                    command.Parameters.Add(new MySqlParameter("@DateL", dateL));
                    command.ExecuteNonQuery();
                    break;
                case 3:
                    command.CommandText = "UPDATE Commande SET DateC = @DateC WHERE NumC=@NumC;";
                    Console.WriteLine("Nouvelle date de commande : ");
                    string dateC = Console.ReadLine();
                    command.Parameters.Add(new MySqlParameter("@NumC", numC));
                    command.Parameters.Add(new MySqlParameter("@DateC", dateC));
                    command.ExecuteNonQuery();
                    break;
                case 4:
                    command.CommandText = "UPDATE Commande SET Id_Client = @Id_Client WHERE NumC=@NumC;";
                    Console.WriteLine("Nouvel id client pour la commande : ");
                    int idClient = Convert.ToInt32(Console.ReadLine());
                    command.Parameters.Add(new MySqlParameter("@NumC", numC));
                    command.Parameters.Add(new MySqlParameter("@Id_Client", idClient));
                    command.ExecuteNonQuery();
                    break;
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void quantitesVendues(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT DescPiece, NumP, count(*) FROM PiècesD NATURAL JOIN Contient_PiècesD GROUP BY PiècesD.NumP; ";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string desc = reader.GetString(0);
                string numP = reader.GetString(1);
                int quantite = reader.GetInt32(2);

                Console.WriteLine($"{quantite} {desc} {numP} vendu(e)s");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void listeMembres(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            Console.WriteLine("Liste des membres du programme Fidélio : ");
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT NomIndiv, PrenomIndiv FROM Individu NATURAL JOIN Client NATURAL JOIN Adhère WHERE Adhère.NumProg = 1; ";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                string nom = reader.GetString(0);
                string prenom = reader.GetString(1);

                Console.WriteLine($"{nom} {prenom}");
            }
            reader.Close();

            Console.WriteLine("Liste des membres du programme Fidélio OR : ");
            MySqlCommand command2 = co.CreateCommand();
            command2.CommandText = "SELECT NomIndiv, PrenomIndiv FROM Individu NATURAL JOIN Client NATURAL JOIN Adhère WHERE Adhère.NumProg = 2; ";

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();
            while (reader2.Read())// parcours ligne par ligne
            {
                string nom = reader2.GetString(0);
                string prenom = reader2.GetString(1);

                Console.WriteLine($"{nom} {prenom}");
            }
            reader2.Close();

            Console.WriteLine("Liste des membres du programme Fidélio PLATINE : ");
            MySqlCommand command3 = co.CreateCommand();
            command3.CommandText = "SELECT NomIndiv, PrenomIndiv FROM Individu NATURAL JOIN Client NATURAL JOIN Adhère WHERE Adhère.NumProg = 3; ";

            MySqlDataReader reader3;
            reader3 = command3.ExecuteReader();
            while (reader3.Read())// parcours ligne par ligne
            {
                string nom = reader3.GetString(0);
                string prenom = reader3.GetString(1);

                Console.WriteLine($"{nom} {prenom}");
            }
            reader3.Close();

            Console.WriteLine("Liste des membres du programme Fidélio MAX : ");
            MySqlCommand command4 = co.CreateCommand();
            command4.CommandText = "SELECT NomIndiv, PrenomIndiv FROM Individu NATURAL JOIN Client NATURAL JOIN Adhère WHERE Adhère.NumProg = 4; ";

            MySqlDataReader reader4;
            reader4 = command4.ExecuteReader();
            while (reader4.Read())// parcours ligne par ligne
            {
                string nom = reader4.GetString(0);
                string prenom = reader4.GetString(1);

                Console.WriteLine($"{nom} {prenom}");
            }
            reader4.Close();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void analyseCommande(MySqlConnection co)
        {
            Console.Clear();
            co.Open();

            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT Count(NumC) FROM Commande;";
            int nbcommande = 0;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                nbcommande = reader.GetInt32(0);
                Console.WriteLine($"Nombre total de commandes : {nbcommande}");
            }
            reader.Close();

            Console.WriteLine("Prix total de chaque commande : ");
            MySqlCommand command2 = co.CreateCommand();
            command2.CommandText = "SELECT Commande.NumC, SUM(Quantite_PiècesD*PrixUP + Quantite_Vélo*PrixUV) AS PrixTCommande FROM Commande JOIN Contient_PiècesD ON Contient_PiècesD.NumC = Commande.NumC JOIN Contient_Vélo ON Contient_Vélo.NumC = Commande.NumC NATURAL JOIN Bicyclette NATURAL JOIN PiècesD GROUP BY Commande.NumC; ";

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                int numC = reader2.GetInt32(0);
                int prixT = reader2.GetInt32(1);

                Console.WriteLine($"Prix total de la commande n°{numC} : {prixT}");
            }
            reader2.Close();

            MySqlCommand command3 = co.CreateCommand();
            command3.CommandText = "SELECT Commande.NumC, SUM(Quantite_PiècesD*PrixUP + Quantite_Vélo*PrixUV) AS PrixTCommande FROM Commande JOIN Contient_PiècesD ON Contient_PiècesD.NumC = Commande.NumC JOIN Contient_Vélo ON Contient_Vélo.NumC = Commande.NumC NATURAL JOIN Bicyclette NATURAL JOIN PiècesD GROUP BY Commande.NumC; ";
            int moyC = 0;
            MySqlDataReader reader3;
            reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                moyC += reader3.GetInt32(1);

            }
            moyC = moyC / nbcommande;
            Console.WriteLine($"Moyenne des montants des commandes : {moyC}");
            reader3.Close();

            MySqlCommand command4 = co.CreateCommand();
            command4.CommandText = "SELECT Commande.NumC, SUM(Quantite_PiècesD) AS nbPièce FROM Commande JOIN Contient_PiècesD ON Contient_PiècesD.NumC = Commande.NumC NATURAL JOIN PiècesD GROUP BY Commande.NumC; ";
            int nbP = 0;
            MySqlDataReader reader4;
            reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                nbP += reader4.GetInt32(1);

            }
            int moyNbP = nbP / nbcommande;
            Console.WriteLine($"Moyenne du nombre de pièces par commande : {moyNbP}");
            reader4.Close();

            MySqlCommand command5 = co.CreateCommand();
            command5.CommandText = "SELECT Commande.NumC, SUM(Quantite_Vélo) AS nbVelo FROM Commande JOIN Contient_Vélo ON Contient_Vélo.NumC = Commande.NumC NATURAL JOIN Bicyclette GROUP BY Commande.NumC; ";
            int nbV = 0;
            MySqlDataReader reader5;
            reader5 = command5.ExecuteReader();
            while (reader5.Read())
            {
                nbV += reader5.GetInt32(1);

            }
            int moyNbV = nbV / nbcommande;
            Console.WriteLine($"Moyenne du nombre de vélos par commande : {moyNbV}");
            reader5.Close();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void meilleurClient(MySqlConnection co)
        {
            Console.Clear();
            co.Open();

            Console.WriteLine("Meilleur client en fonction des quantités achetées : ");
            MySqlCommand command6 = co.CreateCommand();
            command6.CommandText = "SELECT nomIndiv, NomCompagnie, sum(Quantite_Vélo+Quantite_PiècesD) AS cumul FROM client join Commande on client.Id_Client = commande.Id_Client join Contient_PiècesD on Contient_PiècesD.NumC = commande.NumC join Contient_Vélo on Contient_Vélo.numC = commande.NumC natural join bicyclette natural join PiècesD GROUP BY commande.NumC ORDER BY cumul DESC LIMIT 1; ";
            MySqlDataReader reader6;
            reader6 = command6.ExecuteReader();
            while (reader6.Read())
            {
                string nomI = reader6.GetString(0);
                //string nomC = reader6.GetString(1);
                int cumul = reader6.GetInt32(2);
                Console.WriteLine($"{nomI} a acheté {cumul} éléments");
                //Console.WriteLine($"Nom de la compagnie (si boutique) : {nomC}");
            }
            reader6.Close();

            Console.WriteLine("Meilleur client en fonction du cumul en euros : ");
            MySqlCommand command7 = co.CreateCommand();
            command7.CommandText = "SELECT nomIndiv, NomCompagnie, sum(prixUP*Quantite_PiècesD+prixUV*Quantite_Vélo) AS cumul FROM client join Commande on client.Id_Client = commande.Id_Client join Contient_PiècesD on Contient_PiècesD.NumC = commande.NumC join Contient_Vélo on Contient_Vélo.numC = commande.NumC natural join bicyclette natural join PiècesD GROUP BY commande.NumC ORDER BY cumul DESC LIMIT 1; ";
            MySqlDataReader reader7;
            reader7 = command7.ExecuteReader();
            while (reader7.Read())
            {
                string nomI = reader7.GetString(0);
                //string nomC = reader7.GetString(1);
                int cumul = reader7.GetInt32(2);
                Console.WriteLine($"{nomI} a dépensé {cumul}");
                //Console.WriteLine($"Nom de la compagnie (si boutique) : {nomC}");
            }
            reader7.Close();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void toJson(MySqlConnection co)
        {
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('id_Client', id_Client, 'tel', tel,'NomCompagnie', NomCompagnie,'NomIndiv', NomIndiv,'Id_Adresse', Id_Adresse, 'NumProg', NumProg)) from Client INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/client.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('Id_Adresse',Id_Adresse, 'Rue', Rue, 'Ville', Ville, 'CodePostal', CodePostal, 'Province', Province )) from adresse INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/adresse.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('Id_Client',Id_Client, 'Id_Adresse', Id_Adresse)) from affecte_adresse INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/affecte_adresse.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('NumV', NumV, 'NumP', NumP)) from assemblage INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/assemblage.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('NumV', NumV, 'NomV', NomV, 'GrandeurV', GrandeurV, 'PrixUV', PrixUV, 'DateIM', DateIM, 'DateDM', DateDM, 'Ligne', Ligne, 'Cadre', Cadre, 'Guidon', Guidon, 'Freins', Freins, 'Selle', Selle, 'Derailleur_Avant', Derailleur_Avant, 'derailleur_Arriere', derailleur_Arrière, 'Roue_Avant', Roue_Avant, 'Roue_Arrière', Roue_Arrière, 'Réflecteurs', Reflecteurs, 'Pedalier', Pedalier, 'Ordinateur', Ordinateur, 'Panier', Panier)) from bicyclette INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/bicyclette.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('Id_Client', Id_Client, 'NomCompagnie', NomCompagnie, 'NomContact', NomContact, 'Remise', Remise)) from boutique INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/boutique.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('Id_Client', Id_Client, 'Numprog', NumProg, 'Date_Adh_Ind',Date_Adh_Ind, 'Date_pay_Ind', Date_pay_Ind )) from adhère INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/adhere.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('NumC', NumC, 'AddLiv', AddLiv, 'DateL', DateL, 'DateC', DateC, 'Id_Client', Id_Client)) from Commande INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/Commande.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('NumC', NumC, 'NumP', NumP, 'Quantite_PiècesD',Quantite_PiècesD )) from contient_piècesD INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/contient_piecesD.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('NumC', NumC, 'NumV', NumV,'Quantite_Vélo', Quantite_Vélo)) from contient_vélo INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/contient_velo.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('NumProg', NumProg, 'DescProg', DescProg, 'CoutProg', CoutProg, 'DureeProg', DureeProg, 'RabaisProg', RabaisProg)) from fidélio INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/fidelio.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('Siret', Siret, 'NomE', NomE, 'ContactE', ContactE, 'AddE', AddE, 'libellé', Libellé)) from fournisseur INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/fournisseur.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('Siret', Siret, 'NumP', NumP)) from fournit INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/fournit.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('Id_Client', Id_Client, 'NomIndiv', NomIndiv, 'PrénomIndiv', PrenomIndiv)) from individu INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/individu.json';";
            command.CommandText = "SELECT JSON_ARRAYAGG(JSON_OBJECT('NumP', NumP, 'DescPiece', DescPiece, 'DateIP', DateIP, 'DateDP', DateDP, 'NomF', NomF, 'NumCata', NumCata, 'PrixUP', PrixUP, 'Stock', Stock)) from PiècesD INTO OUTFILE 'C:/Users/timot/OneDrive/Bureau/S6/ProjetVitalZenouBDD/PiecesD.json';";
            Console.WriteLine("Les fichiers .json ont bien été créé");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();

            co.Close();
        }
        static void requeteSynchro(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT NumV, NomV, GrandeurV, Ligne, PrixUV FROM Bicyclette WHERE PrixUV< (SELECT AVG(PrixUV) FROM Bicyclette);";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Numéro Vélo :" + reader.GetInt32(0));
                Console.WriteLine("Nom du vélo :" + reader.GetString(1));
                Console.WriteLine("Grandeur :" + reader.GetString(2));
                Console.WriteLine("Ligne :" + reader.GetString(3));
                Console.WriteLine("Prix Unitaire :" + reader.GetInt32(4));
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void requeteAutoJ(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT V1.NumV, V1.NomV, V2.NumV, V2.NomV, V1.PrixUV FROM Bicyclette V1, Bicyclette V2 WHERE V1.PrixUV = V2.PrixUV; ";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                int numV1 = reader.GetInt32(0);
                string nomV1 = reader.GetString(1);
                int numV2 = reader.GetInt32(2);
                string nomV2 = reader.GetString(3);
                int prix = reader.GetInt32(4);
                Console.WriteLine($"Les vélos {numV1} {nomV1} et {numV2} {nomV2} ont le même prix : {prix}");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }

        static void requeteUnion(MySqlConnection co)
        {
            Console.Clear();
            co.Open();
            MySqlCommand command = co.CreateCommand();
            command.CommandText = "SELECT NumV, NomV, GrandeurV, Ligne FROM Bicyclette WHERE PrixUV<200 AND Ordinateur = '' UNION SELECT NumV, NomV, GrandeurV, Ligne FROM Bicyclette WHERE Ordinateur != ''; ";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Numéro Vélo :" + reader.GetInt32(0));
                Console.WriteLine("Nom du vélo :" + reader.GetString(1));
                Console.WriteLine("Grandeur :" + reader.GetString(2));
                Console.WriteLine("Ligne :" + reader.GetString(3));
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();
            co.Close();
        }
    }
}