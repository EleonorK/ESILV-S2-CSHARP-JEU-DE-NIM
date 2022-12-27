using System;
using System.IO;

namespace Jeu_de_Nim                                         
{
    class Program
    {
        static void Menu() 
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            CentrerLeTexte("BIENVENUE AUX JEUX DE NIM ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            CentrerLeTexte("Voici les règles du jeu : ");
            Console.WriteLine(" ");
            CentrerLeTexte("Les jeux de nim sont des jeux de stratégie à 2 joueurs, il en existe plusieurs versions. ");
            CentrerLeTexte("Nous démarrons le jeu avec un nombre donné d'allumettes. ");
            CentrerLeTexte("Le principe étant que chaque joueur retire 1, 2 ou 3 allumettes à tour de rôle. ");
            CentrerLeTexte("Le joueur qui prend la dernière allumette est le gagnant (ou le perdant selon certaines variantes).");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            CentrerLeTexte("A VOUS DE JOUER ! ");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            CentrerLeTexte("Nous vous proposons plusieurs versions du jeu : ");
            Console.WriteLine(" ");
            CentrerLeTexte("1 - Partie 1 ");
            CentrerLeTexte("2 - Partie 2 ");
            CentrerLeTexte("3 - Partie 3 ");
            CentrerLeTexte("4 - Partie 4 ");
            CentrerLeTexte("5 - Quitter  ");
            Console.WriteLine(" ");

            int a = Securite(1, 5);
            
            if (a == 1)
            {
                Console.Clear();
                Partie_1();
            }
            if (a == 2)
            {
                Console.Clear();
                Partie_2();
            }
            if (a == 3)
            {
                Console.Clear();
                Partie_3();
            }
            if (a == 4)
            {
                Console.Clear();
                Partie_4();
            }
            if (a == 5)
            {
                Environment.Exit(0);
            }
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  

        #region Partie 1

        #region centrer le texte
        /// <summary>
        /// Pour centrer le texte écrit, code trouvé sur internet (c'est le seul programe pris sur internet)
        /// https://openclassrooms.com/fr/courses/1526901-apprenez-a-developper-en-c/2867826-une-console
        /// </summary>
        /// <param name="texte"></param> le texte affiché sur la console (à la ligne)
        static void CentrerLeTexte(string texte)
        {
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.WriteLine(texte);
        }
        /// <summary>
        /// Pour centrer le texte écrit, code trouvé sur internet (c'est le seul programe pris sur internet)
        /// https://openclassrooms.com/fr/courses/1526901-apprenez-a-developper-en-c/2867826-une-console
        /// </summary>
        /// <param name="texte"></param>le texte affiché sur la console (à la suite)
        static void CentrerLeTexteL(string texte)
        {
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.Write(texte);
        }
        #endregion
        #region règle du jeu
        /// <summary>
        /// Ce sont les règles du jeu
        /// </summary>
        static void RegleDuJEu()
        {
            Console.WriteLine();
            CentrerLeTexte("Voici les règles du jeux (2 joueurs)");
            Console.WriteLine();
            CentrerLeTexte("Les joueurs sont devant un certain nombre d'allumettes (au choix). A chaque tour, il faut en enlever 1, 2 ou 3. Celui qui prend la dernière gagne ou perd suivant les versions.");
        }
        #endregion
        #region Demande de regle du jeu
        /// <summary>
        /// demande a l'utilisateur si il veut les règles du jeu
        /// </summary>
        static void DemandeDeRegleDuJeu()
        {
            CentrerLeTexte("Bienvenue dans le jeu n°1");
            Console.WriteLine();
            CentrerLeTexte("Voulez vous les règles du jeux ? ");
            CentrerLeTexte("1. Oui" + "\t" + "2. Non");
            Console.WriteLine();
            CentrerLeTexteL("Vous avez saisi l'option : ");
            int n = SecuriteCentre(1, 2);
            Console.WriteLine();
            if (n == 1) { RegleDuJEu(); }
        }
        #endregion
        #region nombre allumettes, gagnant/perdant
        /// <summary>
        /// demande à l'utilisateur le nombre d'allumette qu'il veut au départ
        /// demande à l'utilisateur s'il veut le jeu gagnant ou perdant
        /// </summary>
        static void NbAlluEtGagnantOuPerdant()
        {
            Console.WriteLine();
            Console.WriteLine();
            CentrerLeTexteL("Combien d'allumettes voulez vous au départ (maximum 20 allumettes) ? ");
            int nb = SecuriteCentre(1, 20);
            int nbA = nb;
            Console.WriteLine();
            Console.WriteLine();
            CentrerLeTexte("Voulez vous que celui / celle qui prend le dernier bâton gagne ou perd ? ");
            CentrerLeTexte("1. Gagnant " + "\t" + "2. Perdant ");
            Console.WriteLine();
            CentrerLeTexteL("Vous avez saisi l'option : ");
            int option = SecuriteCentre(1, 2);
            Console.WriteLine();
            Console.WriteLine();
            if (option == 1) { Gagnant(nb, nbA); }
            if (option == 2) { Perdant(nb, nbA); }
        }
        #endregion
        #region Gagnant
        /// <summary>
        /// jeu gagnant 
        /// </summary>
        /// <param name="nb"></param> nombre d'allumette au départ
        /// <param name="nbA"></param> nombre d'allumette au départ fixe
        static void Gagnant(int nb, int nbA)
        {
            //déclaration des tableaux
            int i = 0, j = 0;
            char[] tabAllu = new char[nb];
            string[] tabAlluNum = new string[nb];

            //remplisage des tabeaux
            AffichageAllumettes(nb, tabAllu, tabAlluNum, i, j);
            EcritTableau(tabAllu, tabAlluNum);

            //partie joueur n°1
            //demande du nombre d'allumettes que l'utilistateur veut prendre
            while (nb > 0)
            {
                int a = -1;
                int nb1 = 0;
                int nbessai = 0;
                while (a < 1 || a > 3)
                {
                    if (nb == 2)
                    {
                        CentrerLeTexte("Joueur n°1");
                        CentrerLeTexte("Voulez vous prendre 1 ou 2 allumette(s) ? ");
                        a = SecuriteNbAllu(1, 2, nb);
                        Console.WriteLine();
                    }
                    if (nb == 1)
                    {
                        CentrerLeTexte("Joueur n°1");
                        CentrerLeTexte("Il ne reste qu'une allumette ! ");
                        a = 1;
                        Console.WriteLine();
                    }
                    if (nb > 2)
                    {
                        CentrerLeTexte("Joueur n°1");
                        CentrerLeTexte("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                        a = SecuriteNbAllu(1, 3, nb);
                        Console.WriteLine();
                    }
                }
                nb = nb - a; // pour savoir le nombre d'allumette restant

                //demande de l'allumette à enlever
                CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");
                while (nbessai != a)
                {
                    CentrerLeTexte("Allumette n° ");
                    nb1 = SecuriteAllu(1, nbA);
                    EnlevementAllumettes(nb, tabAllu, tabAlluNum, i, j, nb1, nbA);
                    EcritTableau(tabAllu, tabAlluNum);
                    nbessai++;
                }
                if (nb == 0) { CentrerLeTexte("Joueur n°1, vous avez gagné (*w*) "); }

                //partie joueur n°2
                //même commentaires
                else
                {
                    a = -1;
                    nb1 = 0;
                    nbessai = 0;
                    while (a < 1 || a > 3)
                    {
                        if (nb == 2)
                        {
                            CentrerLeTexte("Joueur n°2");
                            CentrerLeTexte("Voulez vous prendre 1 ou 2 allumette(s) ? ");
                            a = SecuriteNbAllu(1, 2, nb);
                            Console.WriteLine();
                        }
                        if (nb == 1)
                        {
                            CentrerLeTexte("Joueur n°2");
                            CentrerLeTexte("Il ne reste qu'une allumette ! ");
                            a = 1;
                            Console.WriteLine();
                        }
                        if (nb > 2)
                        {
                            CentrerLeTexte("Joueur n°2");
                            CentrerLeTexte("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                            a = SecuriteNbAllu(1, 3, nb);
                            Console.WriteLine();
                        }
                    }
                    nb = nb - a;
                    CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");
                    while (nbessai != a)
                    {
                        CentrerLeTexte("Allumette n° ");
                        nb1 = SecuriteAllu(1, nbA);
                        EnlevementAllumettes(nb, tabAllu, tabAlluNum, i, j, nb1, nbA);
                        EcritTableau(tabAllu, tabAlluNum);
                        nbessai++;
                    }
                    if (nb == 0) { CentrerLeTexte("Joueur n°2, vous avez gagné (*w*) "); }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            CentrerLeTexte("Voulez vous rejouer ?");
            Console.WriteLine(" ");
            CentrerLeTexte("1) Oui");
            CentrerLeTexte("2) Non");
            Console.WriteLine();
            CentrerLeTexteL("Vous avez choisi l'option : ");
            int n = SecuriteCentre(1, 2);
            Console.Clear();
            if (n == 1)
            {
                Console.Clear();
                ExecutionOrdi1();
            }
            if (n == 2)
            {
                Console.WriteLine();
                Console.WriteLine();
                CentrerLeTexte("Voulez vous retourner au menu de départ ou au menu de la partie 1 ?");
                Console.WriteLine(" ");
                CentrerLeTexte("1) Menu principal  ");
                CentrerLeTexte("2) Menu Partie n°1 ");
                Console.WriteLine();
                CentrerLeTexteL("Vous avez choisi l'option : ");
                int b = SecuriteCentre(1, 2);
                if (b == 1)
                {
                    Console.Clear();
                    Menu();
                }
                if (b == 2)
                {
                    Console.Clear();
                    Partie_1();
                }
            }
        }
        #endregion
        #region Perdant
        /// <summary>
        /// jeu perdant
        /// Même commentaire que pour la partie gagnante
        /// </summary>
        /// <param name="nb"></param> nombre d'allumette au départ
        /// <param name="nbA"></param> nombre d'allumette au départ fixe
        static void Perdant(int nb, int nbA)
        {
            int i = 0, j = 0;
            char[] tabAllu = new char[nb];
            string[] tabAlluNum = new string[nb];

            AffichageAllumettes(nb, tabAllu, tabAlluNum, i, j);
            EcritTableau(tabAllu, tabAlluNum);

            while (nb > 0)
            {
                int a = -1;
                int nb1 = 0;
                int nbessai = 0;
                while (a < 1 || a > 3)
                {
                    if (nb == 2)
                    {
                        CentrerLeTexte("Joueur n°1");
                        CentrerLeTexte("Voulez vous prendre 1 ou 2 allumette(s) ? ");
                        a = SecuriteNbAllu(1, 2, nb);
                        Console.WriteLine();
                    }
                    if (nb == 1)
                    {
                        CentrerLeTexte("Joueur n°1");
                        CentrerLeTexte("Il ne reste qu'une allumette ! ");
                        a = 1;
                        Console.WriteLine();
                    }
                    if (nb > 2)
                    {
                        CentrerLeTexte("Joueur n°1");
                        CentrerLeTexte("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                        a = SecuriteNbAllu(1, 3, nb);
                        Console.WriteLine();
                    }
                }
                nb = nb - a;

                CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");
                while (nbessai != a)
                {
                    CentrerLeTexte("Allumette n° ");
                    nb1 = SecuriteAllu(1, nbA);
                    EnlevementAllumettes(nb, tabAllu, tabAlluNum, i, j, nb1, nbA);
                    EcritTableau(tabAllu, tabAlluNum);
                    nbessai++;
                }
                if (nb == 0) { CentrerLeTexte("Joueur n°1, vous avez perdu T~T "); }
                else
                {
                    a = -1;
                    nb1 = 0;
                    nbessai = 0;
                    while (a < 1 || a > 3)
                    {
                        if (nb == 2)
                        {
                            CentrerLeTexte("Joueur n°2");
                            CentrerLeTexte("Voulez vous prendre 1 ou 2 allumette(s) ? ");
                            a = SecuriteNbAllu(1, 2, nb);
                            Console.WriteLine();
                        }
                        if (nb == 1)
                        {
                            CentrerLeTexte("Joueur n°2");
                            CentrerLeTexte("Il ne reste qu'une allumette ! ");
                            a = 1;
                            Console.WriteLine();
                        }
                        if (nb > 2)
                        {
                            CentrerLeTexte("Joueur n°2");
                            CentrerLeTexte("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                            a = SecuriteNbAllu(1, 3, nb);
                            Console.WriteLine();
                        }
                    }
                    nb = nb - a;
                    CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");
                    while (nbessai != a)
                    {
                        CentrerLeTexte("Allumette n° ");
                        nb1 = SecuriteAllu(1, nbA);
                        EnlevementAllumettes(nb, tabAllu, tabAlluNum, i, j, nb1, nbA);
                        EcritTableau(tabAllu, tabAlluNum);
                        nbessai++;
                    }
                    if (nb == 0) { CentrerLeTexte("Joueur n°2, vous avez perdu T~T "); }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            CentrerLeTexte("Voulez vous rejouer ?");
            Console.WriteLine(" ");
            CentrerLeTexte("1) Oui");
            CentrerLeTexte("2) Non");
            Console.WriteLine();
            CentrerLeTexteL("Vous avez choisi l'option : ");
            int n = SecuriteCentre(1, 2);
            Console.Clear();
            if (n == 1)
            {
                Console.Clear();
                ExecutionOrdi2();              
            }
            if (n == 2)
            {
                Console.WriteLine();
                Console.WriteLine();
                CentrerLeTexte("Voulez vous retourner au menu de départ ou au menu de la partie 1 ?");
                Console.WriteLine(" ");
                CentrerLeTexte("1) Menu principal  ");
                CentrerLeTexte("2) Menu Partie n°1 ");
                Console.WriteLine();
                CentrerLeTexteL("Vous avez choisi l'option : ");
                int b = SecuriteCentre(1, 2);
                if (b == 1)
                {
                    Console.Clear();
                    Menu();
                }
                if (b == 2)
                {
                    Console.Clear();
                    Partie_1();
                }
            }
        }
        #endregion
        #region remplissage allumettes départ
        /// <summary>
        /// il remplit les tabeaux  
        /// </summary>
        /// <param name="nb"></param> nombre d'allumette au départ
        /// <param name="tabAllu"></param> tableau d'allumettes
        /// <param name="tabAlluNum"></param> tableau des numéros des allumettes
        /// <param name="i"></param> index du tableau d'allumettes
        /// <param name="j"></param> index du tableau des numéros des allumettes
        static void AffichageAllumettes(int nb, char[] tabAllu, string[] tabAlluNum, int i, int j)
        {
            if (tabAllu != null && tabAlluNum != null)
            {
                if (i != tabAllu.Length && j != tabAlluNum.Length)
                {
                    for (i = 0; i < tabAllu.Length; i++)
                    {
                        for (j = 0; j < tabAlluNum.Length; j++)
                        {
                            tabAllu[i] = '¡';
                            tabAlluNum[j] = "n°" + (j + 1);
                        }
                    }
                }
                else { Console.WriteLine(" i = taille ou j = taille "); }
            }
            else { Console.WriteLine(" null "); }
        }
        #endregion
        #region ecrit tableau 
        /// <summary>
        /// il affiche les tableaux 
        /// </summary>
        /// <param name="tabAllu"></param> tableau d'allumettes
        /// <param name="tabAlluNum"></param> tableau des numéros des allumettes
        static void EcritTableau(char[] tabAllu, string[] tabAlluNum)
        {
            int k = 0, m = 0;
            if (tabAllu.Length < 11 && tabAlluNum.Length < 11)
            {
                Console.Write("\t" + "\t" + "\t");
                for (k = 0; k < tabAllu.Length; k++)
                {
                    Console.Write(" " + tabAllu[k] + "\t");
                }
                Console.WriteLine();
                Console.Write("\t" + "\t" + "\t");
                for (m = 0; m < tabAlluNum.Length; m++)
                {
                    Console.Write(tabAlluNum[m] + "\t");
                }
                Console.WriteLine("\n");
            }

            // Présentation des allumettes
            if (tabAllu.Length > 10 && tabAlluNum.Length > 10)
            {
                Console.Write("\t" + "\t" + "\t");
                for (k = 0; k < 10; k++)
                {
                    Console.Write(" " + tabAllu[k] + "\t");
                }
                Console.WriteLine();
                Console.Write("\t" + "\t" + "\t");
                for (m = 0; m < 10; m++)
                {
                    Console.Write(tabAlluNum[m] + "\t");
                }
                Console.WriteLine("\n");
                Console.Write("\t" + "\t" + "\t");
                for (k = 10; k < tabAllu.Length; k++)
                {
                    Console.Write(" " + tabAllu[k] + "\t");
                }
                Console.WriteLine();
                Console.Write("\t" + "\t" + "\t");
                for (m = 10; m < tabAlluNum.Length; m++)
                {
                    Console.Write(tabAlluNum[m] + "\t");
                }
                Console.WriteLine("\n");
            }
        }
        #endregion
        #region enlèvement allumettes 
        /// <summary>
        /// il enlève les allumettes selectionnées par l'utilisateur
        /// </summary>
        /// <param name="nb"></param> nombre d'allumette restant
        /// <param name="tabAllu"></param> tableau d'allumettes
        /// <param name="tabAlluNum"></param> tableau des numéros des allumettes
        /// <param name="i"></param> index du tableau d'allumettes
        /// <param name="j"></param> index du tableau des numéros d'allumettes
        /// <param name="nb1"></param> numero saisi par l'utilisateur 
        /// <param name="nbA"></param> nombre d'allumettes au départ
        static void EnlevementAllumettes(int nb, char[] tabAllu, string[] tabAlluNum, int i, int j, int nb1, int nbA)
        {
            if (tabAllu != null && tabAlluNum != null)
            {
                if (i != tabAllu.Length && j != tabAlluNum.Length)
                {
                    for (i = 0; i < tabAllu.Length; i++)
                    {
                        for (j = 0; j < tabAlluNum.Length; j++)
                        {
                            // si le numéro de l'allumette selectionnée a déja été enlevé
                            if (nb1 == (i + 1) && nb1 == (j + 1) && tabAllu[i] == ' ' && tabAlluNum[j] == " ")
                            {
                                while (nb1 == (i + 1) && nb1 == (j + 1) && tabAllu[i] == ' ' && tabAlluNum[j] == " ")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Cette allumette a déja été enlevée, veuillez choisir une allumette encore disponible ");
                                    Console.Write("Allumettes n° ");
                                    nb1 = SecuriteAllu(0, nbA);
                                }
                            }

                            // retirer l'allumette selectionnée
                            if (nb1 == (i + 1) && nb1 == (j + 1))
                            {
                                tabAllu[i] = ' ';
                                tabAlluNum[j] = " ";
                            }
                        }
                    }
                }
                else { Console.WriteLine(" i = taille ou j = taille "); }
            }
            else
            {
                Console.WriteLine(" null ");
            }

        }
        #endregion
        #region appel du jeu
        /// <summary>
        /// appel du jeu
        /// </summary>
        static void Partie_1()
        {
            #region demande de regle du jeu
            DemandeDeRegleDuJeu();
            #endregion
            #region nb allu, gagnant/perdant
            NbAlluEtGagnantOuPerdant();
            #endregion
        }
        #endregion
        #region execution ordi
        static void ExecutionOrdi1()
        {
            int n = ChoixNbAllu();
            Gagnant(n, n);     
        }
        static void ExecutionOrdi2()
        {
            int n = ChoixNbAllu();
            Perdant(n, n);
        }
        #endregion

        #endregion Partie 1                                                                                                                                         

        #region Partie 2
        static void Partie_2()  // menu de la partie 2
        {
            // donner le choix à l'utilisateur
            Console.Clear();
            Console.WriteLine(" ");
            CentrerLeTexte("Voulez-vous jouer contre un joueur ou contre l'ordinateur ? ");
            Console.WriteLine(" ");
            CentrerLeTexte("1 - Contre un joueur   ");
            CentrerLeTexte("2 - Contre l'ordinateur ");
            Console.WriteLine(" ");
            int a = Securite(1, 2); // vérif saisie utilisateur

            if(a==1)
            {
                Console.Clear();
                Console.WriteLine(" ");
                string joueur1 = "";
                CentrerLeTexte("Ecrire le nom du joueur 1 ");
                joueur1 = Console.ReadLine();
                string joueur2 = "";
                Console.WriteLine(" ");
                CentrerLeTexte("Ecrire le nom du joueur 2 ");
                joueur2 = Console.ReadLine();
                NbAllumettes(1, joueur1, joueur2);
            }
            if(a==2)
            {
                Console.Clear();
                Console.WriteLine(" ");
                CentrerLeTexte("Voulez-vous que l'ordinateur joue de manière aléatoire (libre choix) ou consécutive ?");
                Console.WriteLine(" ");
                CentrerLeTexte("1 - Aléatoire  ");
                CentrerLeTexte("2 - Consécutif ");
                Console.WriteLine(" ");
                int choix = Securite(1, 2);
                if(choix == 1)
                {
                    Console.Clear();
                    int n = 0;
                    Console.WriteLine(" ");
                    CentrerLeTexte("Combien d'allumettes voulez vous ? (max 20) ");
                    n = Securite(1, 20); // vérif saisie utilisateur
                    Console.Clear();
                    JoueurVSOrdi(n);
                }
                else
                {
                    Console.Clear();
                    CentrerLeTexte("Comment t'appelles tu ? ");
                    string joueur1 = Console.ReadLine();
                    CentrerLeTexte("Combien d'allumettes ? (max 20) ");
                    int nb = Securite(1, 20); // vérif saisie utilisateur
                    Console.Clear();
                    Console.Write("\n");
                    MoyenConsecutif(nb, joueur1);
                }   
            }
        }

        #region Random 
        // sous programmes qui génèrent un ou des nombre(s) aléatoire(s)
       
        static int NombreAleaAllumette(int n)    // n = nombre d'allumettes restant
        {
            int nbAlea = 0;
            do
            {
                Random generateurAlea = new Random();
                nbAlea = generateurAlea.Next(1, 4); // générer un nombre aléatoire entre 1 et 3
                System.Threading.Thread.Sleep(100);
            } while (nbAlea > n); // il faut avoir un nombre inférieur au nombre d'allumettes restant

            return nbAlea;
        }

        static int NombreAleaVerif(int a, char[] tabAllumettes) // vérifie si la position choisie par l'ordinateur contient une allumette
        {
            if (a > 0)
            {
                int nbAlea = 0;
                Random generateurAlea = new Random();
                do
                {
                    nbAlea = generateurAlea.Next(1, a); // avoir un nombre aléa entre 1 et 3
                    System.Threading.Thread.Sleep(100);
                }
                while (tabAllumettes[nbAlea - 1] == ' '); // -1 car l'allumette 1 est dans la case 0 du tableau
                return (nbAlea);
            }
            return -1;
        }
        #endregion Random

        #region partie2 joueur VS joueur

        static void JoueurVSJoueur(int n, string joueur1, string joueur2) // version consécutif
        {
            int nballu = n;
            //déclaration des tableaux
            char[] tabAllumettes = new char[n]; // tableau contenant l'allumettes
            string[] tabPosition = new string[n]; // tableau contenant la position de l'allumette
            AffichageJeu(tabAllumettes, tabPosition); 
            EcritTableau(tabAllumettes, tabPosition);

            int position = 0; //ces deux variables servent à savoir à partir de quelle position il faut enlever les allumettes
            int newposition = 0;

            while (n > 0) // permettre aux joueurs de jouer tant qu'il y a des allumettes dans le plateau de jeu
            {

                int choix = 0;
                int nbessai = 0;
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Green;
                CentrerLeTexte(joueur1);
                Console.ResetColor();
                CentrerLeTexte("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                Console.WriteLine(" ");
                choix = Securite(1, 3);
                if ((n - choix) < 0) // si le joueur veut retirer plus d'allumettes que le nombre d'allumettes disponible
                {
                    do
                    {
                        CentrerLeTexte("Il ne reste plus que " + n + " allumettes ");
                        Console.WriteLine(" ");
                        choix = Securite(1, n);
                    } while (choix > n);
                }
                n = n - choix; // nombre d'allumette(s) restant

                do
                {
                    if (nbessai == 0)
                    {
                        position = newposition + 1; // position : on enlève les allumettes de gauche à droit
                    }

                    if (nbessai > 0)
                    {
                        position++;
                    }

                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);

                    nbessai++;
                } while (nbessai < choix); // redemander au joueur jusqu'au nombre d'allumettes qu'il a choisi de retirer

                newposition = position;

                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    CentrerLeTexte(joueur1 + " vous avez perdu T~T ");
                }

                else // 2ème joueur qui joue
                {
                    choix = 0;
                    nbessai = 0;
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    CentrerLeTexte(joueur2);
                    Console.ResetColor();
                    CentrerLeTexte("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                    Console.WriteLine(" ");
                    choix = Securite(1, 3);
                    Console.WriteLine(" ");
                    if ((n - choix) < 0)
                    {
                        do
                        {
                            CentrerLeTexte("Il ne reste plus que " + n + " allumettes ");
                            Console.WriteLine(" ");
                            choix = Securite(1, n);
                        } while (choix > n);
                    }
                    n = n - choix; // nombre d'allumettes restant

                    do
                    {
                        if (nbessai == 0)
                        {
                            position = newposition + 1; 
                        }

                        if (nbessai > 0)
                        {
                            position++;
                        }

                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);

                        nbessai++;
                    } while (nbessai < choix);

                    newposition = position;

                    if (n == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        CentrerLeTexte(joueur2 + " vous avez perdu T~T ");
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine(" ");
            CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
            Console.WriteLine(" ");
            CentrerLeTexte("1- oui");
            CentrerLeTexte("2- non");
            int choix1 = Securite(1, 2);
            if (choix1 == 1)
            {
                Console.Clear();
                JoueurVSJoueur(ChoixNbAllu(), joueur1, joueur2);
            }
            else
            {
                Console.Clear();
                Menu();
            }
        }

        static void NbAllumettes(int choix, string joueur1, string joueur2) // demande du nombre d'allumettes
        {
            int n = 0;
            do
            {
                CentrerLeTexte("Combien d'allumettes voulez vous ? ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 1 || n > 20); // vérification de la saisie 


            if (choix == 1)
            {
                Console.Clear();
                Console.WriteLine(" ");
                JoueurVSJoueur(n, joueur1, joueur2); // appel du jeu
            }
        }
        #endregion partie2 joueurVSjoueur

        #region partie2 joueur VS ordi

        static void JoueurVSOrdi(int n) // libre choix 
        {
            string joueur1 = "";
            Console.WriteLine(" ");
            CentrerLeTexte("Quel est ton prénom ? ");
            joueur1 = Console.ReadLine();
            Console.Clear();
            int nballu = n; // nombre d'allumettes
            // déclaration des tableaux
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            Console.WriteLine("\n");
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);

            while (n > 0)
            {
                int choix = 0;
                int position = 0;
                int nbessai = 0;
                while (choix < 1 || choix > 3 || choix > n) // nombre d'allumettes à retirer
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CentrerLeTexte(joueur1);
                    Console.ResetColor();
                    CentrerLeTexte("Combien d'allumettes voulez vous prendre ? ");
                    choix = Securite(1, 3);
                    if (choix < 1 || choix > 3)
                    {
                        CentrerLeTexte("Tu peux enlever 1, 2 ou 3 allumettes ");
                    }
                    Console.WriteLine();
                }
                n = n - choix; // nombre d'allumette restant

                CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");

                do
                {
                    Console.Write("Allumettes n° ");
                    position = SecuritePosition(0, nballu+1, tabAllumettes);
                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);
                    nbessai++;
                } while (nbessai != choix);

                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    CentrerLeTexte(joueur1+ ", vous avez perdu ");
                    Console.ResetColor();
                }
                else // ordinateur qui joue
                {
                    choix = -1;
                    position = 0;
                    nbessai = 0;
                    while (choix < 1 || choix > 3 || choix > n)
                    { 
                        choix = NombreAleaAllumette(n); // n = nombre d'allumettes encore disponible
                        Console.WriteLine();
                    }
                    n = n - choix;
                    CentrerLeTexte("Ordinateur : je vais enlever " + choix + " allumettes");
                    while (nbessai != choix)
                    {
                        position = NombreAleaVerif(nballu+1, tabAllumettes); // ordi chosit une position aléatoire
                        CentrerLeTexte("Ordinateur : j'ai pris de la position " + position);
                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);
                        nbessai++;
                    }
                    if (n == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        CentrerLeTexte("Bravo "+ joueur1+ ", vous avez gagné contre l'ordinateur ");
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine(" ");
            CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
            Console.WriteLine(" ");
            CentrerLeTexte("1- oui");
            CentrerLeTexte("2- non");
            int choix1 = Securite(1, 2);
            if (choix1 == 1)
            {
                Console.Clear();
                JoueurVSOrdi(n);
            }
            else
            {
                CentrerLeTexte("1- Retourner menu Partie 2 ");
                CentrerLeTexte("2- Retourner menu principal ");
                Console.WriteLine(" ");
                int choix2 = Securite(1, 2);
                if(choix2==1)
                {
                    Console.Clear();
                    Partie_2();
                }
                else
                {
                    Console.Clear();
                    Menu();
                }          
            }
        }
        #endregion partie2 joueur VS ordi

        static void EnleverAllu(char[] tabAllumettes, string[] tabPosition, int position) // pour enlever l'allumette séléctionée
        {
            int i = 0;
            int j = 0;
            if (tabAllumettes != null && tabPosition != null) // vérification du contenu des tableaux (sécurité)
            {
                if (i != tabAllumettes.Length && j != tabPosition.Length)
                {
                    for (i = 0; i < tabAllumettes.Length; i++) // boucle pour l'allumette
                    {
                        for (j = 0; j < tabPosition.Length; j++) // boucle pour la position
                        {
                            if (position == (i + 1) && position == (j + 1))
                            {
                                tabAllumettes[i] = ' '; // mettre un espace vide à la place de l'allumette à enlever
                                tabPosition[j] = " "; // mettre un espace vide à la place du numéro de la position
                            }
                        }
                    }
                }
            }
        }

        static void AffichageJeu(char[] tabAllumettes, string[] tabPosition) // affichage du plateau de jeu avec les allumettes et leurs positions
        {
            int i = 0;
            int j = 0;
            if (tabAllumettes != null && tabPosition != null) // vérification du contenu des tableaux (sécurité)
            {
                if (i != tabAllumettes.Length && j != tabPosition.Length) //sécurité
                {
                    for (i = 0; i < tabAllumettes.Length; i++)
                    {
                        for (j = 0; j < tabPosition.Length; j++)
                        {
                            tabAllumettes[i] = '¡'; // remplissage de la case du tableau des allumettes
                            tabPosition[j] = " "+(j + 1); // remplissage de la case de la position de l'allumette
                        }
                    }
                }
            }
        }

        #endregion Partie 2                                                                                                                        
        
        #region Partie 3

        #region compte
        /// <summary>
        /// enregister le nouvel utilisateur dans un fichier
        /// </summary>
        /// <param name="fileName"></param> fichier
        /// <param name="nom"></param>nom du joueur
        /// <param name="mdp"></param>mot de passe du joueur
        /// <param name="nbVic"></param>nombre de victoire soit 0
        static void NouvelUTil(string fileName, string nom, string mdp, int nbVic)
        {
            try
            {
                StreamWriter str = new StreamWriter("repertoire.txt", true);
                str.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string nvxText = null;
            StreamReader sr = new StreamReader("repertoire.txt");
            string autre = sr.ReadLine();
            var text = File.ReadAllText("repertoire.txt");
            string[] lignes = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            sr.Close();
            for (int i = 0; i < lignes.Length; i++)
            {
                if (autre != null)
                {
                    nvxText = nvxText + lignes[i] + "\n";
                }
                else
                {
                    nvxText = nvxText + lignes[i];
                }
            }
            File.WriteAllText("repertoire.txt", nvxText);
            try
            {
                if (autre != null)
                {
                    StreamWriter sk = new StreamWriter(fileName);
                    sk.Write(nvxText);
                    sk.Close();
                }
                StreamWriter sw = new StreamWriter(fileName, true);
                sw.Write(nom + "," + mdp + "," + nbVic);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// inscription
        /// </summary>
        /// <returns></returns> le nom du joueur
        static string Inscription()
        {
            int nbVictoires = 0;
            CentrerLeTexte("**** Inscription ****");
            Console.WriteLine();
            string nom = "", mdp1 = "", mdp = "";
            CentrerLeTexteL("Veuillez saisir un nom d'utilisateur : ");
            nom = Console.ReadLine();
            Console.WriteLine();
            CentrerLeTexteL("Veuilez saisir un mot de passe : ");
            mdp1 = Console.ReadLine();
            Console.WriteLine();
            CentrerLeTexteL("Veuillez confirmer votre mot de passe : ");
            mdp = Console.ReadLine();

            if (mdp != mdp1)
            {
                while (mdp != mdp1)
                {
                    Console.WriteLine();
                    CentrerLeTexte("Mot de passe incorrect");
                    CentrerLeTexteL("Veuillez confirmer votre mot de passe ");
                    mdp = Console.ReadLine();
                }
            }

            NouvelUTil("repertoire.txt", nom, mdp, nbVictoires);
            return nom;
        }
        /// <summary>
        /// se connecte a son compte 
        /// </summary>
        /// <param name="fileName"></param> fichier
        /// <param name="nom1"></param> nom du joueur 2
        /// <param name="mdp1"></param> mdp du joueur 2
        /// <returns></returns>
        static bool Connexion(string fileName, string nom1, string mdp1)
        {
            bool exist = false;
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string ligne = "";
                string[] temp = null;
                while (sr.EndOfStream == false && exist == false)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split(',');
                    if (temp[0].ToLower() == nom1.ToLower() && temp[1].ToLower() == mdp1.ToLower())
                    {
                        exist = true;
                    }
                }
                if (exist == true)
                {
                    CentrerLeTexte("   Succès de connexion");
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    CentrerLeTexte("Echec de connexion");
                    CentrerLeTexte("  Ce compte n'existe pas ! ");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return exist;
        }
        /// <summary>
        /// menu du jeu 3
        /// </summary>
        /// <returns></returns> nom du joueur
        static string Partie3()
        {
            string nom = null;
            CentrerLeTexte("**** Menu du jeu n°3 ****");
            Console.WriteLine();
            CentrerLeTexte("Vous devez avoir un compte pour pouvoir jouer");
            Console.WriteLine();
            CentrerLeTexte("1) Inscription              ");
            CentrerLeTexte("2) Connexion                ");
            CentrerLeTexte("3) Classement               ");
            CentrerLeTexte("4) Retour au Menu principal ");
            Console.WriteLine();
            CentrerLeTexteL("Vous avez choisi l'option : ");
            int a = SecuriteCentre(1, 4);
            Console.Clear();

            if (a == 1) { nom = Inscription(); }
            if (a == 2)
            {


                string mdp = null;
                bool exist = false;

                while (exist != true)
                {
                    CentrerLeTexte("**** Connexion ****");
                    Console.WriteLine();
                    CentrerLeTexteL("Nom d'utilisateur : ");
                    nom = Console.ReadLine();
                    Console.WriteLine();
                    CentrerLeTexteL("Mot de passe : ");
                    mdp = Console.ReadLine();
                    exist = Connexion("repertoire.txt", nom, mdp);
                    Console.WriteLine();
                }
            }
            if (a == 3)
            {
                Classement();
            }
            if (a == 4)
            {
                Console.Clear();
                Menu();               
            }
            Console.Clear();
            return nom;
        }
        #endregion
        static void ModeDeJeu(string nom)
        {
            string joueur1 = nom;
            Console.WriteLine();
            Console.WriteLine();
            CentrerLeTexte("Voulez vous jouer contre un joueur ou contre un ordinateur ? ");
            CentrerLeTexte("1) Joueur VS Joueur " + "\t" + "2) Joueur VS Ordinateur");
            Console.WriteLine();
            CentrerLeTexteL("Vous avez choisi l'option : ");
            int a = SecuriteCentre(1, 2);
            Console.Clear();
            if (a == 1)
            {

                Console.WriteLine();
                Console.WriteLine();
                CentrerLeTexte("Joueur n°2, avez vous déjà un compte ?");
                CentrerLeTexte("1) Oui" + "\t" + "2) Non");
                Console.WriteLine();
                CentrerLeTexteL("Vous avez choisi l'option : ");
                int n = SecuriteCentre(1, 2);
                Console.Clear();
                if (n == 1)
                {
                    string nom1 = null, mdp1 = null;
                    bool exist = false;

                    while (exist != true)
                    {
                        CentrerLeTexte("**** Connexion ****");
                        Console.WriteLine();
                        CentrerLeTexteL("Nom d'utilisateur : ");
                        nom1 = Console.ReadLine();
                        Console.WriteLine();
                        CentrerLeTexteL("Mot de passe : ");
                        mdp1 = Console.ReadLine();
                        exist = Connexion("repertoire.txt", nom1, mdp1);
                    }
                    Console.Clear();
                    joueurVSjoueur(nom, nom1);
                }
                if (n == 2)
                {
                    string nom1 = Inscription();
                    joueurVSjoueur(nom, nom1);
                }
            }
            if (a == 2)
            {
                ExecutionOrdi(nom);
            }
        }
        #region jeu 
        /// <summary>
        /// jeu
        /// </summary>
        /// <param name="nb"></param> nb d'allumettes
        /// <param name="nbA"></param> nb d'allumettes restant
        /// <param name="nom"></param> joueur 1
        /// <param name="nom1"></param> jooueur 2
        static void Perdant(int nb, int nbA, string nom, string nom1)
        {
            int i = 0, j = 0;
            double tempsJ1 = 0, tempsJ2 = 0, debutTempsJeu = Environment.TickCount;
            char[] tabAllu = new char[nb];
            string[] tabAlluNum = new string[nb];

            AffichageAllumettes(nb, tabAllu, tabAlluNum, i, j);
            EcritTableau(tabAllu, tabAlluNum);
            while (nb > 0)
            {
                int a = -1;
                int nb1 = 0;
                int nbessai = 0;
                double debutTempsJ1 = Environment.TickCount;
                while (a < 1 || a > 3)
                {
                    if (nb == 2)
                    {
                        Console.WriteLine(nom);
                        Console.Write("Voulez vous prendre 1 ou 2 allumette(s) ? ");
                        a = SecuriteNbAllu(1, 2, nb);
                        Console.WriteLine();
                    }
                    if (nb == 1)
                    {
                        Console.WriteLine(nom);
                        Console.WriteLine("Il ne reste qu'une allumette ! ");
                        a = 1;
                        Console.WriteLine();
                    }
                    if (nb > 2)
                    {
                        Console.WriteLine(nom);
                        Console.Write("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                        a = SecuriteNbAllu(1, 3, nb);
                        Console.WriteLine();
                    }
                }
                nb = nb - a;

                Console.WriteLine("Quelle(s) allumette(s) voulez vous enlever ? ");
                while (nbessai != a)
                {
                    Console.Write("Allumette n° ");
                    nb1 = SecuriteAllu(0, nbA);
                    EnlevementAllumettes(nb, tabAllu, tabAlluNum, i, j, nb1, nbA);
                    EcritTableau(tabAllu, tabAlluNum);
                    nbessai++;
                }
                double finTempsJ1 = Environment.TickCount - debutTempsJ1;
                tempsJ1 = tempsJ1 + finTempsJ1;
                Console.Clear();
                EcritTableau(tabAllu, tabAlluNum);
                if (nb == 0)
                {
                    Console.WriteLine(nom + ", vous avez perdu T~T ");
                    Victoires("repertoire.txt", nom1);
                    Console.WriteLine();
                }
                else
                {
                    a = -1;
                    nb1 = 0;
                    nbessai = 0;
                    double debutTempsJ2 = Environment.TickCount;
                    while (a < 1 || a > 3)
                    {
                        if (nb == 2)
                        {
                            Console.WriteLine(nom1);
                            Console.Write("Voulez vous prendre 1 ou 2 allumette(s) ? ");
                            a = SecuriteNbAllu(1, 2, nb);
                            Console.WriteLine();
                        }
                        if (nb == 1)
                        {
                            Console.WriteLine(nom1);
                            Console.WriteLine("Il ne reste qu'une allumette ! ");
                            a = 1;
                            Console.WriteLine();
                        }
                        if (nb > 2)
                        {
                            Console.WriteLine(nom1);
                            Console.Write("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                            a = SecuriteNbAllu(1, 3, nb);
                            Console.WriteLine();
                        }
                    }
                    nb = nb - a;
                    Console.WriteLine("Quelle(s) allumette(s) voulez vous enlever ? ");
                    while (nbessai != a)
                    {
                        Console.Write("Allumette n° ");
                        nb1 = SecuriteAllu(1, nbA);
                        EnlevementAllumettes(nb, tabAllu, tabAlluNum, i, j, nb1, nbA);
                        EcritTableau(tabAllu, tabAlluNum);
                        nbessai++;
                    }
                    double finTempsJ2 = Environment.TickCount - debutTempsJ2;
                    tempsJ2 = tempsJ2 + finTempsJ2;
                    Console.Clear();
                    EcritTableau(tabAllu, tabAlluNum);
                    if (nb == 0)
                    {
                        Console.WriteLine(nom1 + ", vous avez perdu T~T ");
                        Victoires("repertoire.txt", nom);
                        Console.WriteLine();
                    }
                }
            }
            double tempsJeuFinal = Environment.TickCount - debutTempsJeu;
            if (tempsJeuFinal < 60000)
            {
                tempsJeuFinal = tempsJeuFinal * 0.001;
                tempsJeuFinal = Math.Round(tempsJeuFinal);
                Console.WriteLine("La partie a durée environ " + tempsJeuFinal + " secondes ");
            }
            else
            {
                tempsJeuFinal = tempsJeuFinal * 0.00001667;
                tempsJeuFinal = Math.Round(tempsJeuFinal);
                Console.WriteLine("La partie a durée environ " + tempsJeuFinal + " minutes ");
            }
            Console.WriteLine();
            if (tempsJ1 < 60000)
            {
                tempsJ1 = tempsJ1 * 0.001;
                tempsJ1 = Math.Round(tempsJ1);
                Console.WriteLine(nom + ", vous avez pris " + tempsJ1 + " secondes de saisie au total ");
            }
            else
            {
                tempsJ1 = tempsJ1 * 0.00001667;
                tempsJ1 = Math.Round(tempsJ1);
                Console.WriteLine(nom + ", vous avez pris " + tempsJ1 + " minutes de saisie au total ");
            }
            Console.WriteLine();
            if (tempsJ2 < 60000)
            {
                tempsJ2 = tempsJ2 * 0.001;
                tempsJ2 = Math.Round(tempsJ2);
                Console.WriteLine(nom1 + ", vous avez pris " + tempsJ2 + " secondes de saisie au total ");
            }
            else
            {
                tempsJ2 = tempsJ2 * 0.00001667;
                tempsJ2 = Math.Round(tempsJ2);
                Console.WriteLine(nom1 + ", vous avez pris " + tempsJ2 + " minutes de saisie au total ");
            }
            Console.WriteLine();
            RetourMenus(nom, nom1);
        }
        #endregion
        #region retour aux menus
        /// <summary>
        /// retour au menu
        /// </summary>
        /// <param name="nom"></param> joueur 1
        /// <param name="nom1"></param> joueur 2
        static void RetourMenus(string nom, string nom1)
        {
            CentrerLeTexte("Voulez vous rejouer ?");
            CentrerLeTexte("1) Oui" + "\t" + "2) Non");
            Console.WriteLine();
            CentrerLeTexteL("Vous avez choisi l'option : ");
            int n = SecuriteCentre(1, 2);
            Console.Clear();
            if (n == 1)
            {
                NbAllu(nom, nom1);
            }
            if (n == 2)
            {
                Console.WriteLine();
                Console.WriteLine();
                CentrerLeTexte("Voulez vous retourner au menu de départ ou au menu de la partie 3 ?");
                CentrerLeTexte("1) Menu principal " + "\t" + "2) Menu Partie n°3 ");
                Console.WriteLine();
                CentrerLeTexteL("Vous avez choisi l'option : ");
                int b = SecuriteCentre(1, 2);
                if (b == 1)
                {
                    Console.Clear();
                    Menu();
                }
                if (b == 2)
                {
                    Console.Clear();
                    nom = Partie_3();
                }
            }
        }
        #endregion
        #region appel du jeu
        /// <summary>
        /// appel du jeu
        /// </summary>
        static void joueurVSjoueur(string nom, string nom1)
        {
            #region demande de regle du jeu
            DemandeDeRegleDuJeu();
            #endregion
            Console.Clear();
            #region nb allu, gagnant/perdant
            NbAllu(nom, nom1);
            #endregion

        }
        #endregion
        /// <summary>
        /// victoires
        /// </summary>
        /// <param name="fileName"></param> fichier 
        /// <param name="nom"></param> le joueur ayant gagné
        static void Victoires(string fileName, string nom)
        {
            int i = 0;
            string[] temp = null;
            string nvlLigne = null;
            StreamReader sr = new StreamReader(fileName);
            string autre = sr.ReadLine();
            sr.Close();
            var text = File.ReadAllText("repertoire.txt");
            string[] lignes = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (i = 0; i < lignes.Length; i++)
            {
                temp = lignes[i].Split(',');
                if (temp[0] == nom)
                {
                    temp[2] = Convert.ToString(Convert.ToInt32(temp[2]) + 1);
                    nvlLigne = temp[0] + "," + temp[1] + "," + temp[2];
                    lignes[i] = nvlLigne;
                    break;
                }
            }
            string nvxText = null;
            for (int l = 0; l < lignes.Length; l++)
            {
                if (l == lignes.Length - 1)
                {
                    nvxText = nvxText + lignes[l];
                }
                else
                {
                    nvxText = nvxText + lignes[l] + "\n";
                }
            }
            File.WriteAllText("repertoire.txt", nvxText);
        }
        static void Moyen(int n, string nom)
        {
            Console.Clear();
            int nballu = n;
            double debutTemps = Environment.TickCount;
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            Console.WriteLine("\n");
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);
            Console.ResetColor();
            while (n > 0)
            {
                int choix = 0;
                int position = 0;
                int nbessai = 0;
                if (n == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Black;//***********************************************************************************
                    Console.WriteLine(nom + " vous avez perdu ");
                    Victoires("repertoire.txt", nom);
                    n = 0;
                }
                else
                {
                    while (choix < 1 || choix > 3 || choix > n)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(nom);
                        Console.ForegroundColor = ConsoleColor.Black;//***********************************************************************************
                        Console.Write("Combien d'allumettes voulez vous prendre ? ");
                        choix = Convert.ToInt32(Console.ReadLine());
                        if (choix < 1 || choix > 3)
                        {
                            Console.WriteLine("Tu peux enlever 1, 2 ou 3 allumettes ");
                        }
                        Console.WriteLine();
                    }
                    n = n - choix;
                    Console.WriteLine("Quelle(s) allumette(s) voulez vous enlever ? ");
                    do
                    {
                        Console.Write("Allumettes n° ");
                        position = SecuritePosition(0, nballu + 1, tabAllumettes);
                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);
                        nbessai++;
                    } while (nbessai != choix);
                }
                if (n == 1)
                {
                    Console.ResetColor();
                    Console.WriteLine("Ordinateur : j'ai perdu ");
                    Victoires("repertoire.txt", nom);
                    Console.WriteLine();
                    n = 0;
                }
                else
                {
                    choix = 0;
                    position = 0;
                    nbessai = 0;
                    while (choix < 1 || choix > 3 || choix > n)
                    {
                        choix = NombreAleaAllumette(n);
                        Console.WriteLine();
                    }
                    n = n - choix;
                    Console.WriteLine("Ordinateur : je vais enlever " + choix + " allumettes");
                    while (nbessai < choix)
                    {
                        position = NombreAleaVerif(nballu+1, tabAllumettes);
                        Console.WriteLine("Ordinateur : j'ai pris la position " + position);
                        Console.WriteLine();
                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);
                        Console.ResetColor();
                        nbessai++;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Black;//***********************************************************************************
            double tempsJeuFinal = Environment.TickCount - debutTemps;
            if (tempsJeuFinal < 60000)
            {
                tempsJeuFinal = tempsJeuFinal * 0.001;
                tempsJeuFinal = Math.Round(tempsJeuFinal);
                Console.WriteLine("La partie a durée environ " + tempsJeuFinal + " secondes ");
            }
            else
            {
                tempsJeuFinal = tempsJeuFinal * 0.00001667;
                tempsJeuFinal = Math.Round(tempsJeuFinal);
                Console.WriteLine("La partie a durée environ " + tempsJeuFinal + " minutes ");
            }
            RetourMenus1(nom);
        }
        static void RetourMenus1(string nom)
        {
            CentrerLeTexte("Voulez vous rejouer ?");
            CentrerLeTexte("1) Oui" + "\t" + "2) Non");
            Console.WriteLine();
            CentrerLeTexteL("Vous avez choisi l'option : ");
            int n = SecuriteCentre(1, 2);
            Console.Clear();
            if (n == 1)
            {
                ExecutionOrdi(nom);
            }
            if (n == 2)
            {
                Console.WriteLine();
                Console.WriteLine();
                CentrerLeTexte("Voulez vous retourner au menu de départ ou au menu de la partie 3 ?");
                CentrerLeTexte("1) Menu de départ " + "\t" + "2) Menu Partie n°3 ");
                Console.WriteLine();
                CentrerLeTexteL("Vous avez choisi l'option : ");
                int b = SecuriteCentre(1, 2);
                if (b == 1)
                {
                    Console.Clear();
                    Menu();
                }
                if (b == 2)
                {
                    Console.Clear();
                    nom = Partie_3();
                }
            }
        }
        static void ExecutionOrdi(string nom)
        {
            int n = ChoixNbAllu();
            Moyen(n, nom);
        }

        /// <summary>
        /// Classement 
        /// </summary>
        static void Classement()
        {
            int i = 0;
            string[] temp = null;
            string autre = null;
            bool tri = false;
            var text = File.ReadAllText("repertoire.txt");
            string[] lignes = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            if (lignes != null)
            {
                while (tri == false)
                {
                    tri = true;
                    for (i = 0; i < lignes.Length - 1; i++)
                    {
                        temp = lignes[i].Split(',');
                        for (int j = i + 1; j < lignes.Length; j++)
                        {
                            string[] temp1 = lignes[j].Split(',');
                            if (temp1[2] == null)
                            {
                                break;
                            }
                            int a = Convert.ToInt32(temp[2]);
                            int b = Convert.ToInt32(temp1[2]);
                            if (a < b)
                            {
                                autre = lignes[i];
                                lignes[i] = lignes[j];
                                lignes[j] = autre;
                                tri = false;
                            }
                        }
                    }
                }
            }
            int f = 1;
            CentrerLeTexte("**** Classement ****");
            Console.WriteLine();
            for (int z = 0; z < lignes.Length; z++)
            {
                temp = lignes[z].Split(',');
                if (f == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    CentrerLeTexte(f + "er  ");
                    CentrerLeTexte(temp[0] + " : " + temp[2] + " Victoires " + "\n");
                }
                if (f == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    CentrerLeTexte(f + "ème  ");
                    CentrerLeTexte(temp[0] + " : " + temp[2] + " Victoires " + "\n");
                }
                if (f == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    CentrerLeTexte(f + "ème  ");
                    CentrerLeTexte(temp[0] + " : " + temp[2] + " Victoires " + "\n");
                }
                if (f > 3 && f < 6)
                {
                    Console.ResetColor();
                    CentrerLeTexte(f + "ème  ");
                    CentrerLeTexte(temp[0] + " : " + temp[2] + " Victoires " + "\n");
                }
                f++;
            }

            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            Partie_3();
        }

        #region nombre d'allumettes 
        static void NbAllu(string nom, string nom1)
        {
            Console.WriteLine();
            Console.WriteLine();
            CentrerLeTexteL("Combien d'allumettes voulez vous au départ (maximum 20 allumettes) ? ");
            int nb = SecuriteCentre(1, 20);
            int nbA = nb;
            Console.Clear();
            Perdant(nb, nbA, nom, nom1);
        }
        #endregion

        static string Partie_3()
        {
            string nom = null;
            nom = Partie3();
            ModeDeJeu(nom);
            return nom;
        }

        #endregion Partie 3
    
        #region Partie 4

        #region menu Partie 4
        static void Partie_4() // explication de la partie 4 et appel des programmes
        {
            Console.Clear();
            Console.WriteLine("\n");
            CentrerLeTexte("Dans cette version du jeu, vous pouvez jouer contre un autre joueur ou contre l'ordinateur");
            CentrerLeTexte("Vous pouvez enlever les allumettes de manière libre ou de manière consécutive ");
            CentrerLeTexte("Vous pouvez jouer avec intelligence artificielle ou sans ");
            CentrerLeTexte("Nous vous proposons également plusieurs niveaux de difficulté ");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            CentrerLeTexte("A VOUS DE JOUER ! ");
            Console.WriteLine("\n");
            Console.ResetColor();
            CentrerLeTexte("Voulez-vous jouer contre un autre joueur ou contre l'ordinateur ? ");
            Console.WriteLine(" ");
            CentrerLeTexte("1 - Contre un joueur   ");
            CentrerLeTexte("2 - Contre l'ordinateur ");
            Console.WriteLine(" ");
            int a = Securite(1, 2);

            if (a == 1)
            {
                Console.Clear();
                Console.WriteLine(" ");
                CentrerLeTexte("Choisissez une option ");
                Console.WriteLine(" ");
                CentrerLeTexte("1 - Libre choix ");
                CentrerLeTexte("2 - Consécutif ");
                Console.WriteLine(" ");
                int aa = Securite(1, 2);
                if(aa==1)
                {
                    Console.Clear();
                    JoueurVSJoueur(ChoixNbAllu()); // libre choix
                }
                if(aa==2)
                {
                    Console.Clear();
                    string joueur1 = "";
                    Console.WriteLine(" ");
                    CentrerLeTexte("Ecrire le nom du joueur 1 ");
                    joueur1 = Console.ReadLine();
                    string joueur2 = "";
                    CentrerLeTexte("Ecrire le nom du joueur 2 ");
                    joueur2 = Console.ReadLine();
                    JoueurVSJoueur(ChoixNbAllu(), joueur1, joueur2); // consécutif
                }

            }
            if (a == 2)
            {
                Console.Clear();
                Console.WriteLine(" ");
                CentrerLeTexte("Choisissez une option ");
                Console.WriteLine(" ");
                CentrerLeTexte("1 - Libre choix ");
                CentrerLeTexte("2 - Consécutif ");
                Console.WriteLine(" ");
                int aaa = Securite(1, 2);
                if(aaa == 1)
                {
                    Console.Clear();
                    Console.WriteLine(" ");
                    CentrerLeTexte("Choisissez le niveau de difficulté ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("1 - Facile  ");
                    CentrerLeTexte("2 - Moyen  ");
                    CentrerLeTexte("3 - Avec IA");
                    Console.WriteLine(" ");
                    int aaaa = Securite(1, 3);
                    if(aaaa == 1)
                    {
                        Console.Clear();
                        Facile(ChoixNbAllu());
                    }
                    if(aaaa == 2)
                    {
                        Console.Clear();
                        Console.WriteLine(" ");
                        CentrerLeTexte("Vous voulez de l'aide pour battre l'ordinateur ? ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("1 - Oui ");
                        CentrerLeTexte("2 - Non ");
                        int b = Securite(1, 2);
                        if (b == 1)
                        {
                            CentrerLeTexte("Un chiffre vous sera donné pour vous aider à choisir le bon nombre d'allumettes à enlever à chaque fois ");
                            CentrerLeTexte("Vous n'êtes pas obligé de suivre les indications :) ");
                            IntelligenceArtificielle(ChoixNbAllu());
                        }
                        if (b == 2)
                        {
                            Console.Clear();
                            Moyen(ChoixNbAllu());
                        }                      
                    }
                    if(aaaa==3)
                    {
                        Console.Clear();
                        Difficile(ChoixNbAllu());
                    }
                }
                if (aaa == 2)
                {
                    Console.Clear();
                    Console.WriteLine(" ");
                    CentrerLeTexte("Choisissez le niveau de difficulté ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("1 - Facile  ");
                    CentrerLeTexte("2 - Moyen  ");
                    CentrerLeTexte("3 - Avec IA");
                    Console.WriteLine(" ");
                    int aaaaa = Securite(1, 3);
                    if (aaaaa == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(" ");
                        CentrerLeTexte("Quel est ton prénom ? ");
                        string joueur1 = Console.ReadLine();
                        FacileConsecutif(ChoixNbAllu(), joueur1);
                    } 
                    if (aaaaa == 2)
                    {
                        Console.WriteLine(" ");
                        CentrerLeTexte("Vous voulez de l'aide pour battre l'ordinateur ? ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("1 - Oui ");
                        CentrerLeTexte("2 - Non ");
                        int b = Securite(1, 2);
                        if(b==1)
                        {
                            CentrerLeTexte("Un chiffre vous sera donné pour vous aider à choisir le bon nombre d'allumettes à enlever à chaque fois ");
                            CentrerLeTexte("Vous n'êtes pas obligé de suivre les indications :) ");
                            Console.WriteLine(" ");
                            string joueuria = "";
                            CentrerLeTexte("Quel est ton prénom ?");
                            joueuria = Console.ReadLine();
                            IAConsecutif(ChoixNbAllu(), joueuria);
                        }
                        if(b==2)
                        {
                            Console.Clear();
                            Console.WriteLine(" ");
                            CentrerLeTexte("Quel est ton prénom ? ");
                            string joueur1 = Console.ReadLine();
                            MoyenConsecutif(ChoixNbAllu(), joueur1);
                        }      
                    }
                    if (aaaaa == 3)
                    {
                        Console.Clear();
                        Console.WriteLine(" ");
                        CentrerLeTexte("Quel est ton prénom ? ");
                        string joueur1 = Console.ReadLine();
                        DifficileConsecutif(ChoixNbAllu(), joueur1);
                    }
                }
            }
        }
        #endregion menu Partie 4 

        #region Joueur VS joueur

        #region libre choix

        static void JoueurVSJoueur(int n) // version libre choix
        {
            string joueur1 = "";
            CentrerLeTexte("Joueur 1, quel est ton prénom ? ");
            joueur1 = Console.ReadLine();
            string joueur2 = "";
            CentrerLeTexte("Joueur 2, quel est ton prénom ? ");
            joueur2 = Console.ReadLine();
            Console.Clear();
            int nballu = n;
            // déclaration des tableaux
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            Console.WriteLine("\n");
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);

            while (n > 0)
            {
                int choix = 0;
                int position = 0;
                int nbessai = 0;
                while (choix < 1 || choix > 3 || choix > n)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    CentrerLeTexte(joueur1);
                    Console.ResetColor();
                    CentrerLeTexte("Combien d'allumettes voulez vous prendre ? ");
                    choix = Securite(1, 3);
                    if (choix < 1 || choix > 3)
                    {
                        CentrerLeTexte("Tu peux enlever 1, 2 ou 3 allumettes ");
                    }
                    Console.WriteLine();
                }
                n = n - choix; // nombre d'allumettes restant

                CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");
                do
                {
                    Console.Write("Allumettes n° ");
                    position = SecuritePosition(0, nballu, tabAllumettes);
                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);
                    nbessai++;
                } while (nbessai != choix);

                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CentrerLeTexte("WINNER : "+joueur2);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    CentrerLeTexte("LOSER : " + joueur1);
                }
                else
                {
                    choix = 0;
                    position = 0;
                    nbessai = 0;
                    while (choix < 1 || choix > 3 || choix > n)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        CentrerLeTexte(joueur2);
                        Console.ResetColor();
                        CentrerLeTexte("Combien d'allumettes voulez vous prendre ? ");
                        choix = Securite(1, 3); 
                        if (choix < 1 || choix > 3)
                        {
                            CentrerLeTexte("Tu peux enlever 1, 2 ou 3 allumettes ");
                        }
                        Console.WriteLine();
                    }
                    n = n - choix; // nombre d'allumettes restant

                    CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");
                    do
                    {
                        Console.Write("Allumettes n° ");
                        position = SecuritePosition(0, nballu, tabAllumettes);
                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);
                        nbessai++;
                    } while (nbessai != choix);

                    if (n == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        CentrerLeTexte("WINNER : " + joueur1);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        CentrerLeTexte("LOSER : " + joueur2);
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine(" ");
            CentrerLeTexte("Saisir une option ");
            Console.WriteLine(" ");
            CentrerLeTexte("1- Rejouer ");
            CentrerLeTexte("2- Retour au menu 4 ");
            CentrerLeTexte("3- Retour au menu principal ");
            int choix1 = Securite(1, 3);
            if (choix1 == 1)
            {
                Console.Clear();
                JoueurVSJoueur(ChoixNbAllu());
            }
            if (choix1 == 2)
            {
                Console.Clear();
                Partie_4();
            }
            if (choix1 == 3)
            {
                Console.Clear();
                Menu();
            }
        }

        #endregion libre choix

        #region consecutif
        // appel du programme dans le menu partie 4 JoueurVSJoueur(int n, string joueur1, string joueur 2)
        #endregion consecutif

        #endregion joueur VS joueur

        #region joueur VS Ordi

        #region consecutif
        static void FacileConsecutif(int n, string joueur1) // l'ordinateur joue de façon à faire gagne le joueur
        {
            int nballu = n;
            // déclaration des tableaux
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);

            int position = 0;
            int newposition = 0;

            while (n > 0)
            {

                int choix = 0;
                int nbessai = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                CentrerLeTexte(joueur1);
                Console.ResetColor();
                CentrerLeTexte("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                choix = Securite(1, 3);
                if ((n - choix) < 0)
                {
                    do
                    {
                        CentrerLeTexte("Il ne reste plus que " + n + " allumettes ");
                        choix = Securite(1, n);
                    } while (choix > n);
                }
                n = n - choix;

                do
                {
                    if (nbessai == 0)
                    {
                        position = newposition + 1;
                    }

                    if (nbessai > 0)
                    {
                        position++;
                    }

                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);

                    nbessai++;
                } while (nbessai != choix);

                newposition = position;

                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CentrerLeTexte("WINNER : Ordi");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    CentrerLeTexte("LOSER : " + joueur1+"  ");
                }

                else // au tour de l'ordinateur de jouer 
                {
                    choix = 0;
                    nbessai = 0;
                    position = 0;
                    nbessai = 0;
                    if (n <= 2) // l'ordinateur fait exprès de prendre le mauvais nombre d'allumettes afin que le joueur gagne
                    {
                        if (n == 2)
                        {
                            choix = 2;
                        }
                        if (n == 1)
                        {
                            choix = 1;
                        }
                    }
                    else
                    {
                        if (n % 4 == 3) // l'ordinateur choisi exactement le nombre d'allumettes à ne PAS choisir pour faire gagner le joueur
                        {
                            choix = 1;
                        }
                        if (n % 4 == 2)
                        {
                            choix = 2;
                        }
                        if (n % 4 == 1)
                        {
                            choix = 1;
                        }
                        if (n % 4 == 0)
                        {
                            choix = 1;
                        }

                    }
                    CentrerLeTexte("Ordinateur : je vais prendre " + choix + " allumettes");
                    n = n - choix; // nombre d'allumettes restant

                    do
                    {
                        if (nbessai == 0)
                        {
                            position = newposition + 1;
                        }

                        if (nbessai > 0)
                        {
                            position++;
                        }

                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);

                        nbessai++;
                    } while (nbessai != choix);

                    newposition = position;

                    if (n == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        CentrerLeTexte("WINNER : " + joueur1+ "  ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        CentrerLeTexte("LOSER : Ordi ");
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine(" ");
            CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
            Console.WriteLine(" ");
            CentrerLeTexte("1- oui");
            CentrerLeTexte("2- non");
            int choix1 = Securite(1, 2);
            if (choix1 == 1)
            {
                Console.Clear();
                FacileConsecutif(ChoixNbAllu(), joueur1);
            }
            else
            {
                Console.Clear();
                Partie_4();
            }
        }

        static void MoyenConsecutif(int n, string joueur1) // l'ordinateur joue au hasard
        {
            int nballu = n;
            //déclaration des tableaux
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);

            int position = 0;
            int newposition = 0;

            while (n > 0)
            {
                int choix = 0;
                int nbessai = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                CentrerLeTexte(joueur1);
                Console.ResetColor();
                CentrerLeTexte("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                choix = Securite(1, 3);
                if ((n - choix) < 0)
                {
                    do
                    {
                        CentrerLeTexte("Il ne reste plus que " + n + " allumettes ");
                        choix = Securite(1, n);
                    } while (choix > n);
                }
                n = n - choix;

                do
                {
                    if (nbessai == 0)
                    {
                        position = newposition + 1;
                    }

                    if (nbessai > 0)
                    {
                        position++;
                    }

                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);

                    nbessai++;
                } while (nbessai != choix);

                newposition = position;

                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CentrerLeTexte("WINNER : Ordi ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    CentrerLeTexte("LOSER : " + joueur1+ "  ");
                }

                else // au tour de l'ordinateur de jouer
                {
                    choix = 0;
                    nbessai = 0;
                    position = 0;
                    nbessai = 0;
                    while (choix < 1 || choix > 3 || choix > n) // l'ordinateur chosit un nombre aléatoire d'allumettes à retirer
                    {
                        choix = NombreAleaAllumette(n); // dans cette version, l'ordinateur joue au hasard
                        Console.WriteLine();
                    }
                    n = n - choix; // nombre d'allumettes restant
                    CentrerLeTexte("Ordinateur : je vais prendre " + choix + " allumettes");
                    do
                    {
                        if (nbessai == 0)
                        {
                            position = newposition + 1;
                        }

                        if (nbessai > 0)
                        {
                            position++;
                        }

                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);

                        nbessai++;
                    } while (nbessai != choix);

                    newposition = position;

                    if (n == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        CentrerLeTexte("WINNER : " +joueur1+ "  ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        CentrerLeTexte("LOSER : Ordi ");
                    }
                }
            }

            Console.ResetColor();
            Console.WriteLine(" ");
            CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
            Console.WriteLine(" ");
            CentrerLeTexte("1- oui");
            CentrerLeTexte("2- non");
            int choix1 = Securite(1, 2);
            if (choix1 == 1)
            {
                Console.Clear();
                MoyenConsecutif(ChoixNbAllu(), joueur1);
            }
            else
            {
                CentrerLeTexte("Où voulez vous retourner ? ");
                Console.WriteLine(" ");
                CentrerLeTexte("1- Menu partie 4 ");
                CentrerLeTexte("2- Menu principal");
                int choix2 = Securite(1, 2);
                if (choix2 == 1)
                {
                    Console.Clear();
                    Partie_4(); ;
                }
                else
                {
                    Console.Clear();
                    Menu();
                }
            }
        }

        static void DifficileConsecutif(int n, string joueur1) // l'ordinateur joue intelligemment en utilisant des techniques de jeu
        {
            int nballu = n;
            // déclaration des tableaux
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);

            int position = 0;
            int newposition = 0;

            while (n > 0)
            {

                int choix = 0;
                int nbessai = 0;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                CentrerLeTexte(joueur1);
                Console.ResetColor();
                CentrerLeTexte("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                choix = Securite(1, 3);
                if ((n - choix) < 0)
                {
                    do
                    {
                        CentrerLeTexte("Il ne reste plus que " + n + " allumettes ");
                        choix = Securite(1, n);
                    } while (choix > n);
                }
                n = n - choix;

                do
                {
                    if (nbessai == 0)
                    {
                        position = newposition + 1;
                    }

                    if (nbessai > 0)
                    {
                        position++;
                    }

                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);

                    nbessai++;
                } while (nbessai != choix);

                newposition = position;

                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CentrerLeTexte("WINNER : Ordi ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    CentrerLeTexte("LOSER : " + joueur1+ "  ");
                }

                else
                {
                    choix = 0;
                    nbessai = 0;
                    position = 0;
                    nbessai = 0;
                    if (n <= 3)   // l'ordinateur retire les allumettes de manière intelligente
                    {
                        if (n == 3)
                        {
                            choix = 2;
                        }
                        if (n == 2)
                        {
                            choix = 1;
                        }
                        if (n == 1)
                        {
                            choix = 1;
                        }
                    } 
                    else // l'ordi utilise une stratégie développée avec l'expérience de jeu
                    {
                        if (n % 4 == 3)
                        {
                            choix = 2;
                        }
                        if ((n % 4 == 2) || (n % 4 == 1))
                        {
                            choix = 1;
                        }
                        if (n % 4 == 0)
                        {
                            choix = 3;
                        }
                    }
                    CentrerLeTexte("Ordinateur : je vais prendre " + choix + " allumettes");
                    n = n - choix; // nombre d'allumettes restant

                    do
                    {
                        if (nbessai == 0)
                        {
                            position = newposition + 1;
                        }

                        if (nbessai > 0)
                        {
                            position++;
                        }

                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);

                        nbessai++;
                    } while (nbessai != choix);

                    newposition = position;

                    if (n == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        CentrerLeTexte("WINNER : " + joueur1 + "  ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        CentrerLeTexte("LOSER : Ordi ");
                    }
                }
            }

            Console.ResetColor();
            Console.WriteLine(" ");
            CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
            Console.WriteLine(" ");
            CentrerLeTexte("1- oui");
            CentrerLeTexte("2- non");
            int choix1 = Securite(1, 2);
            if (choix1 == 1)
            {
                Console.Clear();
                DifficileConsecutif(ChoixNbAllu(), joueur1);
            }
            else
            {
                CentrerLeTexte("Où voulez vous retourner ? ");
                Console.WriteLine(" ");
                CentrerLeTexte("1- Menu partie 4 ");
                CentrerLeTexte("2- Menu principal");
                int choix2 = Securite(1, 2);
                if (choix2 == 1)
                {
                    Console.Clear();
                    Partie_4(); ;
                }
                else
                {
                    Console.Clear();
                    Menu();
                }
            }

        }

        static void IAConsecutif(int n, string joueur1) // apporte de l'aide au joueur (en option)
        {
            int ia = 0; // variable servant à indiquer au joueur le nombre d'allumettes à retirer pour gagner contre l'ordi
            int nballu = n;
            // déclaration des tableaux
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);

            int position = 0;
            int newposition = 0;

            while (n > 0)
            {

                int choix = 0;
                int nbessai = 0;
                CentrerLeTexte(joueur1);
                if (n <= 3)
                {
                    if (n == 3)
                    {
                        ia = 2;
                    }
                    if (n == 2)
                    {
                        ia = 1;
                    }
                    if (n == 1)
                    {
                        ia = 1;
                    }
                }
                else
                {
                    if (n % 4 == 3)
                    {
                        ia = 2;
                    }
                    if ((n % 4 == 2) || (n % 4 == 1))
                    {
                        ia = 1;
                    }
                    if (n % 4 == 0)
                    {
                        ia = 3;
                    }
                }
                Console.Write("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "AIDE :");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" " + ia);
                Console.ResetColor();
                Console.WriteLine();
                CentrerLeTexte("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                choix = Securite(1, 3);
                if ((n - choix) < 0) // vérifie si le nombre choisi par le joueur n'est pas supérieur au nombre d'allumettes restant
                {
                    do
                    {
                        CentrerLeTexte("Il ne reste plus que " + n + " allumettes ");
                        choix = Securite(1, n); 
                    } while (choix > n);
                }
                n = n - choix; // nombre d'allumettes restant

                do
                {
                    if (nbessai == 0)
                    {
                        position = newposition + 1;
                    }

                    if (nbessai > 0)
                    {
                        position++;
                    }

                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);

                    nbessai++;
                } while (nbessai != choix);

                newposition = position;

                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CentrerLeTexte("WINNER : Ordi ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    CentrerLeTexte("LOSER : " + joueur1 + "  ");
                }

                else // au tour de l'ordinateur de jouer
                {
                    choix = 0;
                    nbessai = 0;
                    position = 0;
                    nbessai = 0;
                    if (n <= 2)
                    {
                        if (n == 2)
                        {
                            choix = 2;
                        }
                        if (n == 1)
                        {
                            choix = 1;
                        }
                    }
                    else
                    {
                        if (n % 4 == 3)
                        {
                            choix = 1;
                        }
                        if (n % 4 == 2)
                        {
                            choix = 2;
                        }
                        if (n % 4 == 1)
                        {
                            choix = 1;
                        }
                        if (n % 4 == 0)
                        {
                            choix = 1;
                        }

                    }
                    CentrerLeTexte("Ordinateur : je vais prendre " + choix + " allumettes");
                    n = n - choix;

                    do
                    {
                        if (nbessai == 0)
                        {
                            position = newposition + 1;
                        }

                        if (nbessai > 0)
                        {
                            position++;
                        }

                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);

                        nbessai++;
                    } while (nbessai != choix);

                    newposition = position;

                    if (n == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        CentrerLeTexte("WINNER : " + joueur1 + "  ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        CentrerLeTexte("LOSER : Ordi ");
                    }
                }
            }    
            Console.ResetColor();
            Console.WriteLine(" ");
            CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
            Console.WriteLine(" ");
            CentrerLeTexte("1- oui");
            CentrerLeTexte("2- non");
            int choix1 = Securite(1, 2);
            if (choix1 == 1)
            {
                Console.Clear();
                IAConsecutif(ChoixNbAllu(), joueur1);
            }
            else
            {
                CentrerLeTexte("Où voulez vous retourner ? ");
                Console.WriteLine(" ");
                CentrerLeTexte("1- Menu partie 4 ");
                CentrerLeTexte("2- Menu principal");
                int choix2 = Securite(1, 2);
                if (choix2 == 1)
                {
                    Console.Clear();
                    Partie_4(); ;
                }
                else
                {
                    Console.Clear();
                    Menu();
                }
            }
        }

        #endregion consecutif

        #region libre choix 

        // mêmes commentaires que pour les versions Consécutif
        static void Facile(int n)  
        {
            string joueur1 = "";
            Console.WriteLine(" ");
            CentrerLeTexte("Quel est ton prénom ? ");
            joueur1 = Console.ReadLine();
            Console.Clear();
            int nballu = n;
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            Console.WriteLine("\n");
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);

            while (n > 0)
            {
                int choix = 0;
                int position = 0;
                int nbessai = 0;
                if (n == 1 )
                {
                    CentrerLeTexte(joueur1+ ", vous avez perdu ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("1- oui");
                    CentrerLeTexte("2- non");
                    int choix1 = Securite(1, 2);
                    if (choix1 == 1)
                    {
                        Console.Clear();
                        Moyen(ChoixNbAllu());
                    }
                    else
                    {
                        Console.Clear();
                        Partie_4();
                    }
                    n = 0;
                }
                else
                {
                    while (choix < 1 || choix > 3 || choix > n)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        CentrerLeTexte(joueur1);
                        Console.ResetColor();
                        CentrerLeTexte("Combien d'allumettes voulez vous prendre ? ");
                        choix = Securite(1, 3);
                        Console.WriteLine();
                    }
                    n = n - choix; // nombre d'allumettes restant

                    CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");
                    do
                    {
                        Console.Write("Allumettes n° ");
                        position = SecuritePosition(0, nballu+1, tabAllumettes);
                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);
                        nbessai++;
                    } while (nbessai != choix);
                    if(n==0)
                    {
                        CentrerLeTexte(joueur1+" vous avez perdu ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("1- oui");
                        CentrerLeTexte("2- non");
                        int choix1 = Securite(1, 2);
                        if (choix1 == 1)
                        {
                            Console.Clear();
                            Moyen(ChoixNbAllu());
                        }
                        else
                        {
                            Console.Clear();
                            Partie_4();
                        }
                    }

                }

                // au tour de l'ordinateur de jouer

                choix = 0;
                position = 0;
                nbessai = 0;
                if (n <= 2)
                {
                    if (n == 2)
                    {
                        choix = 2;
                    }
                    if (n == 1)
                    {
                        choix = 1;
                    }

                }
                else
                {
                    if (n % 4 == 3)
                    {
                        choix = 1;
                    }
                    if (n % 4 == 2)
                    {
                        choix = 2;
                    }
                    if (n % 4 == 1)
                    {
                        choix = 1;
                    }
                    if (n % 4 == 0)
                    {
                        choix = 1;
                    }

                }
                n = n - choix;

                CentrerLeTexte("Ordinateur : je vais enlever " + choix + " allumettes");
                while (nbessai != choix)
                {
                    position = NombreAleaVerif(nballu+1, tabAllumettes);
                    CentrerLeTexte("Ordinateur : j'ai pris de la position " + position);
                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);
                    nbessai++;
                }
                if (n == 0)
                {
                    CentrerLeTexte(joueur1 + " vous avez gagné :P ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("1- oui");
                    CentrerLeTexte("2- non");
                    int choix1 = Securite(1, 2);
                    if (choix1 == 1)
                    {
                        Console.Clear();
                        Facile(ChoixNbAllu());
                    }
                    else
                    {
                        Console.Clear();
                        Partie_4();
                    }
                }

            } 
            if(n==0||n==1)
            {
                CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                Console.WriteLine(" ");
                CentrerLeTexte("1- oui");
                CentrerLeTexte("2- non");
                int choix1 = Securite(1, 2);
                if (choix1 == 1)
                {
                    Console.Clear();
                    Moyen(ChoixNbAllu());
                }
                else
                {
                    Console.Clear();
                    Partie_4();
                }
            }
        }
        static void Moyen(int n) 
        {
            string joueur1 = "";
            Console.WriteLine(" ");
            CentrerLeTexte("Quel est ton prénom ? ");
            joueur1 = Console.ReadLine();
            Console.Clear();
            int nballu = n;
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            Console.WriteLine("\n");
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);

            while (n > 0)
            {
                int choix = 0;
                int position = 0;
                int nbessai = 0;
                if (n == 1 )
                {
                    CentrerLeTexte(joueur1+ ", vous avez perdu ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("1- oui");
                    CentrerLeTexte("2- non");
                    int choix1 = Securite(1, 2);
                    if (choix1 == 1)
                    {
                        Console.Clear();
                        Moyen(ChoixNbAllu());
                    }
                    else
                    {
                        CentrerLeTexte("Où voulez vous retourner ? ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("1- Menu partie 4 ");
                        CentrerLeTexte("2- Menu principal");
                        int choix2 = Securite(1, 2);
                        if(choix2==1)
                        {
                            Partie_4();
                        }
                        else
                        {
                            Menu();
                        }
                    }
                    n = 0;
                }
                else
                {
                    while (choix < 1 || choix > 3 || choix > n)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        CentrerLeTexte(joueur1);
                        Console.ResetColor();
                        CentrerLeTexte("Combien d'allumettes voulez vous prendre ? ");
                        choix = Securite(1, 3);
                        Console.WriteLine();
                    }
                    n = n - choix;

                    CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");
                    do
                    {
                        Console.Write("Allumettes n° ");
                        position = SecuritePosition(0, nballu+1, tabAllumettes);
                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);
                        nbessai++;
                    } while (nbessai != choix);
                    if(n==0)
                    {
                        CentrerLeTexte(joueur1+" vous avez perdu ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("1- oui");
                        CentrerLeTexte("2- non");
                        int choix1 = Securite(1, 2);
                        if (choix1 == 1)
                        {
                            Console.Clear();
                            Moyen(ChoixNbAllu());
                        }
                        else
                        {
                            CentrerLeTexte("Où voulez vous retourner ? ");
                            Console.WriteLine(" ");
                            CentrerLeTexte("1- Menu partie 4 ");
                            CentrerLeTexte("2- Menu principal");
                            int choix2 = Securite(1, 2);
                            if (choix2 == 1)
                            {
                                Partie_4();
                            }
                            else
                            {
                                Menu();
                            }
                        }
                    }
                }

                // au tour de l'ordinateur de jouer

                choix = 0;
                position = 0;
                nbessai = 0;
                while (choix < 1 || choix > 3 || choix > n)
                {
                    choix = NombreAleaAllumette(n);
                    Console.WriteLine();
                }
                n = n - choix;

                CentrerLeTexte("Ordinateur : je vais enlever " + choix + " allumettes");
                while (nbessai != choix)
                {
                    position = NombreAleaVerif(nballu+1, tabAllumettes);
                    CentrerLeTexte("Ordinateur : j'ai pris de la position " + position);
                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);
                    nbessai++;
                }
                if (n == 0)
                {
                    CentrerLeTexte(joueur1 + " vous avez gagné :P ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("1- oui");
                    CentrerLeTexte("2- non");
                    int choix1 = Securite(1, 2);
                    if (choix1 == 1)
                    {
                        Console.Clear();
                        Moyen(ChoixNbAllu());
                    }
                    else
                    {
                        CentrerLeTexte("Où voulez vous retourner ? ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("1- Menu partie 4 ");
                        CentrerLeTexte("2- Menu principal");
                        int choix2 = Securite(1, 2);
                        if (choix2 == 1)
                        {
                            Partie_4();
                        }
                        else
                        {
                            Menu();
                        }
                    }
                }
            } 
            if(n==0||n==1)
            {
                CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                Console.WriteLine(" ");
                CentrerLeTexte("1- oui");
                CentrerLeTexte("2- non");
                int choix1 = Securite(1, 2);
                if (choix1 == 1)
                {
                    Console.Clear();
                    Moyen(ChoixNbAllu());
                }
                else
                {
                    CentrerLeTexte("Où voulez vous retourner ? ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("1- Menu partie 4 ");
                    CentrerLeTexte("2- Menu principal");
                    int choix2 = Securite(1, 2);
                    if (choix2 == 1)
                    {
                        Partie_4();
                    }
                    else
                    {
                        Menu();
                    }
                }

            }

            
        }
        static void Difficile(int n) // IA
        {
            string joueur1 = "";
            CentrerLeTexte("Quel est ton prénom ? ");
            joueur1 = Console.ReadLine();
            Console.Clear();
            int nballu = n;
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            Console.WriteLine("\n");
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);

            while (n > 0)
            {
                int choix = 0;
                int position = 0;
                int nbessai = 0;

                while (choix < 1 || choix > 3 || choix > n)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CentrerLeTexte(joueur1);
                    Console.ResetColor();
                    CentrerLeTexte("Combien d'allumettes voulez vous prendre ? ");
                    choix = Securite(1, 3); // améliorer visuel sur console
                    if (choix < 1 || choix > 3)
                    {
                        CentrerLeTexte("Tu peux enlever 1, 2 ou 3 allumettes ");
                    }
                }
                n = n - choix;

                CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");
                do
                {
                    Console.Write("Allumettes n° ");
                    position = SecuritePosition(0, nballu+1, tabAllumettes);
                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);
                    nbessai++;
                } while (nbessai != choix);

                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CentrerLeTexte("WINNER : ORDI   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    CentrerLeTexte("LOSER : "+joueur1);
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("1- oui");
                    CentrerLeTexte("2- non");
                    int choix1 = Securite(1, 2);
                    if (choix1 == 1)
                    {
                        Console.Clear();
                        Difficile(ChoixNbAllu());
                    }
                    else
                    {
                        Console.Clear();
                        Partie_4();
                    }
                }
                else // au tour de l'ordinateur de jouer
                {
                    choix = -1;
                    position = 0;
                    nbessai = 0;
                    if (n <= 3)
                    {
                        if (n == 3)
                        {
                            choix = 2;
                        }
                        if (n == 2)
                        {
                            choix = 1;
                        }
                        if (n == 1)
                        {
                            choix = 1;
                        }
                    }
                    else
                    {
                        if (n % 4 == 3)
                        {
                            choix = 2;
                        }
                        if ((n % 4 == 2) || (n % 4 == 1))
                        {
                            choix = 1;
                        }
                        if (n % 4 == 0)
                        {
                            choix = 3;
                        }
                    }

                    n = n - choix;
                    CentrerLeTexte("Ordinateur : je vais enlever " + choix + " allumettes");
                    while (nbessai != choix)
                    {
                        position = NombreAleaVerif(nballu+1, tabAllumettes); // vérifie si la case du tableau contient une allumette
                        CentrerLeTexte("Ordinateur : j'ai pris de la position " + position);
                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);
                        nbessai++;
                    }
                    if (n == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        CentrerLeTexte("WINNER :" + joueur1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        CentrerLeTexte("LOSER : ORDINATEUR");
                        Console.ResetColor();
                        CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("1- oui");
                        CentrerLeTexte("2- non");
                        int choix1 = Securite(1, 2);
                        if (choix1 == 1)
                        {
                            Console.Clear();
                            Difficile(ChoixNbAllu());
                        }
                        else
                        {
                            CentrerLeTexte("Où voulez vous retourner ? ");
                            Console.WriteLine(" ");
                            CentrerLeTexte("1- Menu partie 4");
                            CentrerLeTexte("2- Menu principal");
                            int choix2 = Securite(1, 2);
                            if (choix2 == 1)
                            {
                                Partie_4();
                            }
                            else
                            {
                                Menu();
                            }
                        }
                    }
                }
            }
        }
        static void IntelligenceArtificielle(int n) // libre choix // apporte de l'aide au joueur (en option)
        {
            int ia = 0; // aide apportée au joueur
            string joueur1 = "";
            CentrerLeTexte("Quel est ton prénom ? ");
            joueur1 = Console.ReadLine();
            Console.Clear();
            int nballu = n;
            // déclaration des tabelaux
            char[] tabAllumettes = new char[n];
            string[] tabPosition = new string[n];
            Console.WriteLine("\n");
            AffichageJeu(tabAllumettes, tabPosition);
            EcritTableau(tabAllumettes, tabPosition);

            while (n > 0)
            {
                int choix = 0;
                int position = 0;
                int nbessai = 0;

                if (n <= 3)
                {
                    if (n == 3)
                    {
                        ia = 2;
                    }
                    if (n == 2)
                    {
                        ia = 1;
                    }
                    if (n == 1)
                    {
                        ia = 1;
                    }
                }
                else
                {
                    if (n % 4 == 3)
                    {
                        ia = 2;
                    }
                    if ((n % 4 == 2) || (n % 4 == 1))
                    {
                        ia = 1;
                    }
                    if (n % 4 == 0)
                    {
                        ia = 3;
                    }
                }
                Console.Write("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "AIDE :");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" " + ia);
                Console.ResetColor();
                Console.WriteLine();

                while (choix < 1 || choix > 3 || choix > n)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CentrerLeTexte(joueur1);
                    Console.ResetColor();
                    CentrerLeTexte("Combien d'allumettes voulez vous prendre ? ");
                    choix = Convert.ToInt32(Console.ReadLine());
                    if (choix < 1 || choix > 3)
                    {
                        CentrerLeTexte("Tu peux enlever 1, 2 ou 3 allumettes ");
                    }
                    Console.WriteLine();
                }
                n = n - choix; // nombre d'allumettes restant

                CentrerLeTexte("Quelle(s) allumette(s) voulez vous enlever ? ");
                do
                {
                    Console.Write("Allumettes n° ");
                    position = SecuritePosition(0, nballu+1, tabAllumettes);
                    EnleverAllu(tabAllumettes, tabPosition, position);
                    EcritTableau(tabAllumettes, tabPosition);
                    nbessai++;
                } while (nbessai != choix);

                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    CentrerLeTexte(joueur1+" vous avez perdu ");
                    Console.ResetColor();
                    CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                    Console.WriteLine(" ");
                    CentrerLeTexte("1- oui");
                    CentrerLeTexte("2- non");
                    int choix1 = Securite(1, 2);
                    if (choix1 == 1)
                    {
                        Console.Clear();
                        IntelligenceArtificielle(ChoixNbAllu());
                    }
                    else
                    {
                        CentrerLeTexte("Où voulez vous retourner ? ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("1- Menu partie 4");
                        CentrerLeTexte("2- Menu principal");
                        int choix2 = Securite(1, 2);
                        if (choix2 == 1)
                        {
                            Partie_4();
                        }
                        else
                        {
                            Menu();
                        }
                    }
                }
                else
                {
                    choix = -1;
                    position = 0;
                    nbessai = 0;
                    while (choix < 1 || choix > 3 || choix > n)
                    {
                        choix = NombreAleaAllumette(n);  // nombre aléatoire d'allumettes à retirer
                        Console.WriteLine();
                    }
                    n = n - choix;
                    CentrerLeTexte("Ordinateur : je vais enlever " + choix + " allumettes");
                    Console.WriteLine(" ");
                    while (nbessai != choix)
                    {
                        position = NombreAleaVerif(nballu+1, tabAllumettes);
                        CentrerLeTexte("Ordinateur : j'ai pris de la position " + position);
                        Console.WriteLine(" ");
                        EnleverAllu(tabAllumettes, tabPosition, position);
                        EcritTableau(tabAllumettes, tabPosition);
                        nbessai++;
                    }

                    if (n == 0)
                    {
                        CentrerLeTexte("Bravo "+joueur1 + " vous avez gagné ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("Voulez vous rejouer à ce jeu ? ");
                        Console.WriteLine(" ");
                        CentrerLeTexte("1- oui");
                        CentrerLeTexte("2- non");
                        int choix1 = Securite(1, 2);
                        if (choix1 == 1)
                        {
                            Console.Clear();
                            IntelligenceArtificielle(ChoixNbAllu());
                        }
                        else
                        {
                            CentrerLeTexte("Où voulez vous retourner ? ");
                            Console.WriteLine(" ");
                            CentrerLeTexte("1- Menu partie 4");
                            CentrerLeTexte("2- Menu principal");
                            int choix2 = Securite(1, 2);
                            if (choix2 == 1)
                            {
                                Partie_4();
                            }
                            else
                            {
                                Menu();
                            }
                        }
                    }
                }
            }
        }

        #endregion libre choix

        #endregion joueur VS Ordi 

        #endregion Partie 4                                           

        #region Securite

        #region sécurité Centre
        /// <summary>
        /// c'est la sécurité pour la saisie d'un nombre ou un chiffre (pour le centre)
        /// réutilisation du code de mon binôme et modifier pour convenir à mon code
        /// </summary>
        /// <param name="min"></param> le minimum de la saisie
        /// <param name="max"></param> le maximum de la saisie
        /// <returns></returns> le chiffre ou nombre valide saisi par l'utilisateur
        static int SecuriteCentre(int min, int max)
        {
            int a = 0;
            bool test = true;
            string choix = null;
            do
            {
                choix = Console.ReadLine();
                try
                {
                    a = Int32.Parse(choix);
                    test = true;
                }
                catch
                {
                    test = false;
                }
                if (a < min || a > max || test == false)
                {
                    Console.WriteLine();
                    CentrerLeTexte("Cette option n'existe pas, veuillez saisir une option proposée ");
                    CentrerLeTexteL("Nouvelle saisie : ");
                }

            } while (a < min || a > max || test == false);
            return a;
        }
        #endregion
        #region Securité Nombre d'allumettes
        /// <summary>
        /// c'est la sécurité pour la saisie d'un nombre ou un chiffre en fonction du reste d'allumettes
        /// réutilisation du code de mon binôme et modifier pour convenir à mon code
        /// </summary>
        /// <param name="min"></param> le minimum de la saisie
        /// <param name="max"></param> le maximum de la saisie
        /// <param name="nb"></param>  le nombre d'allumette(s) restante(s) 
        /// <returns></returns> le chiffre ou nombre valide saisi par l'utilisateur
        static int SecuriteNbAllu(int min, int max, int nb)
        {
            int a = 0;
            bool test = true;
            string choix = null;
            do
            {
                choix = Console.ReadLine();
                try
                {
                    a = Int32.Parse(choix);
                    test = true;
                }
                catch
                {
                    test = false;
                }
                if (nb == 2)
                {
                    if (a < min || a > max)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Choix impossible ");
                        Console.Write("Voulez vous prendre 1 ou 2 allumette(s) ?  ");
                    }
                }
                if (nb > 2)
                {
                    if (a < min || a > max)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Choix impossible ");
                        Console.Write("Combien d'allumettes, comprises entre 1 à 3, voulez vous prendre ? ");
                    }
                }

            } while (a < min || a > max || test == false);
            return a;
        }
        #endregion
        #region securité allumette
        /// <summary>
        /// c'est la sécurité pour la saisie d'un nombre ou un chiffre en fonction du numéro de l'allumette qui se calcul en fonction du nombre d'allumette au départ
        /// réutilisation du code de mon binôme et modifier pour convenir à mon code
        /// </summary>
        /// <param name="min"></param> le minimum de la saisie
        /// <param name="nbA"></param> le nombre d'allumette de départ
        /// <returns></returns> le numéro de l'allumette valide, saisie par l'utilisateur
        static int SecuriteAllu(int min, int nbA)
        {
            int a = 0;
            bool test = true;
            string choix = null;
            do
            {
                choix = Console.ReadLine();
                try
                {
                    a = Int32.Parse(choix);
                    test = true;
                }
                catch
                {
                    test = false;
                }
                if (a < min || a > nbA || test == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ce numéro d'allumette n'existe pas, veuillez saisir un numéro valide ");
                    Console.Write("Allumette n° ");
                }
            } while (a < min || a > nbA || test == false);
            return a;
        }
        #endregion
        static int Securite(int min, int max) //saisie utilisateur doit être comprise entre min et max
        {
            int a = 0;
            bool test = true;
            string choix = "";
            do
            {
                Console.WriteLine("Saisir un chiffre entre "+ min + " et " + max);
                choix = Console.ReadLine();
                try
                {
                    a = Int32.Parse(choix);
                    test = true;
                }
                catch
                {
                    test = false;
                }

                if (a < min || a > max)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Choix incorrect ");
                }

            } while (a < min || a > max || test == false);
            return a;

        }

        static int ChoixNbAllu() 
        {
            int a = 0;
            bool test = true;
            string choix = "";
            
            do
            {
                CentrerLeTexte("Combien d'allumettes ? (20 max) ");
                choix = Console.ReadLine();
                try
                {
                    a = Int32.Parse(choix);
                    test = true;
                }
                catch
                {
                    test = false;
                }
                if (test == false)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Choix incorrect ");
                }

            } while (test == false || a > 20 || a < 0 );
            return a;
        }

        static int SecuritePosition(int min, int max, char[] tabAllu) //saisie utilisateur doit être comprise entre min et max
        {
            int a = 0;
            bool test = true;
            string choix = "";
            do
            {
                //Console.WriteLine("Saisir un chiffre entre " + min + " et " + max);
                choix = Console.ReadLine();
                try
                {
                    a = Int32.Parse(choix);
                    test = true;
                }
                catch
                {
                    test = false;
                }

                if (a < min || a > max)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Choix incorrect ");
                }
                if(a> min && a < max && tabAllu[a - 1] == ' ')
                {
                    CentrerLeTexte("La position ne contient pas d'allumettes ");
                    test = false;
                }

            } while (a < min || a > max || test == false);
            return a;
        }

        #endregion Securite                                                         

        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }
    }
}