using System;

public class Program
{
 static void Main()
 {
	 // 1. Générer le nombre secret
    // On invente une borne, disons 100
    int secret = Nombre.Generer(10);

    // 2. Demander à l'utilisateur son nombre
    int essai = Utilisateur.NombreUtilisateur();

    // 3. Vérifier si l'utilisateur n'a pas fait d'erreur (s'il n'a pas mis -1)
    if (essai == -1)
    {
        Console.WriteLine("Le jeu est annulé (nombre négatif).");
    }
    else
    {
        // 4. Comparer et afficher le résultat
        Resultat.Verifier(secret, essai);
    }

    // Pause pour que l'écran ne se ferme pas tout de suite
    Console.ReadLine();
}
}


class Nombre 
{
//définir un nombre
public static int Generer(int borne)
{	
	return Random.Shared.Next(0, borne + 1);
}

}


class Utilisateur 
{

    public static int NombreUtilisateur()
    {

        Console.WriteLine("ENTRER le nombre a deviner");

        // On lit et on convertit 
        string texte = Console.ReadLine();
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

public static void Verifier(int secret, int essai)
{
    if (secret == essai)
    {
        Console.WriteLine("Gagné !");
    }
    else
    {
        Console.WriteLine("Perdu !");
    }
}	
	
}
