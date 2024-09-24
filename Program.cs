class Program
{
    static void Main()
    {
        // Création d'une bibliothèque
        Library library = new Library();

        // Ajout de médias
        Livre livre1 = new Livre("Le Petit Prince", 101, 5, "Antoine de Saint-Exupéry");
        Livre livre2 = new Livre("1984", 102, 3, "George Orwell");
        DVD dvd1 = new DVD("Inception", 201, 2, 148);
        DVD dvd2 = new DVD("Interstellar", 202, 1, 169);
        CD cd1 = new CD("Thriller", 301, 10, "Michael Jackson");

        // Ajout des médias à la bibliothèque
        library.AjouterMedia(livre1);
        library.AjouterMedia(livre2);
        library.AjouterMedia(dvd1);
        library.AjouterMedia(dvd2);
        library.AjouterMedia(cd1);

        // Affichage de tous les médias
        library.AfficherTousLesMedias();

        // Utilisation de l'indexeur pour rechercher un média
        Console.WriteLine("Recherche d'un média avec la référence 101 (Le Petit Prince) :");
        Media mediaTrouve = library[101];
        if (mediaTrouve != null)
        {
            mediaTrouve.AfficherInfos();
        }

        // Retirer un média par sa référence
        Console.WriteLine("\nRetrait du DVD 'Inception' (référence 201) :");
        library.RetirerMedia(201);

        // Afficher les médias après le retrait
        library.AfficherTousLesMedias();

        // Test de l'ajout d'exemplaires avec l'opérateur +
        Console.WriteLine("\nAjout de 3 exemplaires supplémentaires pour 'Le Petit Prince' :");
        library[101] += 3;
        library[101].AfficherInfos();

        // Test de la suppression d'exemplaires avec l'opérateur -
        Console.WriteLine("\nRetrait de 2 exemplaires de '1984' :");
        library[102] -= 2;
        library[102].AfficherInfos();

        // Test de la tentative de retrait trop d'exemplaires
        Console.WriteLine("\nTentative de retrait de trop d'exemplaires de 'Interstellar' :");
        try
        {
            library[202] -= 2;  // Il y a seulement 1 exemplaire, cela devrait lancer une exception
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }

        // Affichage final de tous les médias
        Console.WriteLine("\nListe finale des médias dans la bibliothèque :");
        library.AfficherTousLesMedias();
    }
}
