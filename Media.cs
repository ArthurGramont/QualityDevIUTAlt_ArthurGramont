using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class Media
{
    public string Titre;
    public int NumeroReference;
    public int ExemplairesDisponibles;

    public Media(string titre, int numeroReference, int exemplairesDisponibles)
    {
        Titre = titre;
        NumeroReference = numeroReference;
        ExemplairesDisponibles = exemplairesDisponibles;
    }

    public virtual void AfficherInfos()
    {
        Console.WriteLine($"Titre: {Titre}, Référence: {NumeroReference}, Exemplaires disponibles: {ExemplairesDisponibles}");
    }

    public static Media operator +(Media media, int nombreExemplaires)
    {
        media.ExemplairesDisponibles += nombreExemplaires;
        return media;
    }

    public static Media operator -(Media media, int nombreExemplaires)
    {
        if (media.ExemplairesDisponibles - nombreExemplaires < 0)
        {
            throw new InvalidOperationException($"Impossible de retirer {nombreExemplaires} exemplaires. Exemplaires disponibles: {media.ExemplairesDisponibles}.");
        }
        media.ExemplairesDisponibles -= nombreExemplaires;
        return media;
    }
}

public class Livre : Media
{
    public string Auteur;

    public Livre(string titre, int numeroReference, int exemplairesDisponibles, string auteur)
        : base(titre, numeroReference, exemplairesDisponibles)
    {
        Auteur = auteur;
    }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Auteur: {Auteur}");
    }
}

public class DVD : Media
{
    public int Duree;

    public DVD(string titre, int numeroReference, int exemplairesDisponibles, int duree)
        : base(titre, numeroReference, exemplairesDisponibles)
    {
        Duree = duree;
    }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Durée: {Duree} minutes");
    }
}

public class CD : Media
{
    public string Artiste;

    public CD(string titre, int numeroReference, int exemplairesDisponibles, string artiste)
        : base(titre, numeroReference, exemplairesDisponibles)
    {
        Artiste = artiste;
    }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Artiste: {Artiste}");
    }
}

public class Library
{
    private List<Media> _medias = new List<Media>();

    public Media this[int numeroReference]
    {
        get
        {
            return _medias.FirstOrDefault(m => m.NumeroReference == numeroReference);
        }
    }

    public void AjouterMedia(Media media)
    {
        _medias.Add(media);
        Console.WriteLine($"Le média '{media.Titre}' a été ajouté à la bibliothèque.");
    }

    public void RetirerMedia(int numeroReference)
    {
        var media = this[numeroReference];
        if (media != null)
        {
            _medias.Remove(media);
            Console.WriteLine($"Le média '{media.Titre}' a été retiré de la bibliothèque.");
        }
        else
        {
            Console.WriteLine($"Aucun média avec la référence {numeroReference} n'a été trouvé.");
        }
    }
}