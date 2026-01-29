using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        // Créer le garage
        Garage g = new Garage();

        // Scénario Camion 
        Camion c1 = new Camion();
        g.Reparer(c1); // Appelle la méthode du Garage 
        Console.WriteLine("Camion réparé");	
        g.Ajouter(c1); // On ajoute le camion aussi

        // --- Scénario Voiture 1 ---
        Voiture v1 = new Voiture();
        v1.Couleur = EnumCouleur.Rouge;
        v1.Marque = "Peugeot";
        v1.Reparation = true; 
        g.Ajouter(v1);
        Console.WriteLine("Voiture v1 réparée");
        
        // --- Scénario Voiture 2 ---
        Voiture v2 = new Voiture();
        v2.Couleur = EnumCouleur.Vert;
        v2.Marque = "Ferrari";
        v2.Reparation = true; 
        v2.BesoinEntretien = true;

        g.Ajouter(v2);

        // On vérifie le besoin d'entretien
        if (v2.BesoinEntretien == true)
        {
            // 1. On répare le véhicule
            v2.Reparation = true;
            
            // 2. On utilise NOW (la date actuelle)
            v2.DateReparation = DateTime.Now;
            
            // 3. Affichage
            Console.WriteLine("Voiture v2 réparée le : " + v2.DateReparation);
        } 
    }
}

// Stockage des variables (Vocabulaire)
public enum EnumCouleur { Rouge, Vert, Bleu }

// Le garage accueille les véhicules 
public class Garage 
{
    public List<Vehicule> _mesVehicules = new List<Vehicule>();

    public void Ajouter(Vehicule v)
    {
        _mesVehicules.Add(v);
    }

    // CORRECTION : Ajout de la méthode manquante
    public void Reparer(Vehicule v)
    {
        v.Reparation = true;
        Console.WriteLine("Le véhicule a été marqué comme réparé.");
    }
}

// La classe mère 
public class Vehicule 
{
    public bool Reparation { get; set; }
       public bool BesoinEntretien { get; set; } 
    public DateTime DateReparation { get; set; } 
}

// La classe fille (Spécifique)
public class Voiture : Vehicule
{

    
    public EnumCouleur Couleur { get; set; } 
    public string Marque { get; set; }      
    
    public void Repeindre(EnumCouleur nouvelleCouleur)
    {
        this.Couleur = nouvelleCouleur;
    }
}

public class Camion : Vehicule
{

}