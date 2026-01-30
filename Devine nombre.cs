using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        // 1. Sélection du niveau
        int niveau = Utilisateur.SelectNiveau();
        int nombreMaxDEssais;

        switch (niveau)
        {
            case 1: nombreMaxDEssais = 10; break;
            case 2: nombreMaxDEssais = 5; break;
            case 3: nombreMaxDEssais = 3; break;
            default: nombreMaxDEssais = 10; break;
        }

        Console.WriteLine("Niveau choisi (" + niveau + ") : Tu as " + nombreMaxDEssais + " essais potentiels.");

        // 2. Génération du nombre secret
        int secret = Nombre.Generer(10);

        // 3. Préparation des variables de jeu
        int essai;
        bool aGagne = false;
        List<int> historique = new List<int>();

        // 4. DÉBUT DE LA BOUCLE
        while (!aGagne && nombreMaxDEssais > 0)
        {
            // Demander un nombre
            essai = Utilisateur.NombreUtilisateur();

            // Vérifier si on quitte (Touche 'q' ou nombre négatif)
            if (essai == -1)
            {
                Console.WriteLine("Sortie du jeu...");
                Environment.Exit(0);
            }

            // Ajouter à l'historique
            historique.Add(essai);

            // Vérifier le résultat
            aGagne = Resultat.Verifier(secret, essai);

            // Décompter les essais
            nombreMaxDEssais--;
        }
        // 5. FIN DE LA BOUCLE

        // 6. Afficher l'historique
        Console.Write("Vos essais : ");
        foreach (int nombre in historique)
        {
            Console.Write(nombre + " ");
        }
        Console.WriteLine();

        // 7. Message final si on a perdu
        if (!aGagne)
        {
            Console.WriteLine("Perdu ! Le nombre secret était : " + secret);
        }

        // Pause avant fermeture
        Console.ReadLine();
    }
}

class Nombre
{
    public static int Generer(int borne)
    {
        return Random.Shared.Next(0, borne + 1);
    }
}

class Utilisateur
{
    public static int SelectNiveau()
    {
        Console.WriteLine("Saisir le niveau 1 facile 2 moyen 3 difficile");
        Console.WriteLine("Tentative par niveau  facile 10 essai moyen 5 essai difficile 3 essai ");
        string NiveauTexte = Console.ReadLine();
        int niveau = int.Parse(NiveauTexte);
        return (niveau);
    }

    public static int NombreUtilisateur()
    {
        Console.WriteLine("ENTRER le nombre a deviner (ou tapez 'q' pour quitter)");

        string texte = Console.ReadLine();

        // Vérification si l'utilisateur tape "q" ou "Q"
        if (texte == "q" || texte == "Q")
        {
            return -1; // Code de sortie
        }
        
        int nombre = int.Parse(texte);

        if (nombre < 0)
        {
            Console.WriteLine("Impossible a jouer le nombre ne peut pas etre plus petit que zero");
            return -1;
        }
        else
        {
            Console.WriteLine("Valeur prise en compte");
            return nombre;
        }
    }
}

class Resultat
{
    public static bool Verifier(int secret, int essai)
    {
        if (secret == essai)
        {
            Console.WriteLine("Gagné !");
            return true;
        }
        else
        {
            Console.WriteLine("Perdu !");
            return false;
        }
    }
}
