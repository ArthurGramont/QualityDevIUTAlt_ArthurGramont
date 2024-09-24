class Program
{
    static void Main()
    {
        // Cr�ation d'une biblioth�que
        Library library = new Library();

        // Ajout de m�dias
        Livre livre1 = new Livre("Le Petit Prince", 101, 5, "Antoine de Saint-Exup�ry");
        Livre livre2 = new Livre("1984", 102, 3, "George Orwell");
        DVD dvd1 = new DVD("Inception", 201, 2, 148);
        DVD dvd2 = new DVD("Interstellar", 202, 1, 169);
        CD cd1 = new CD("Thriller", 301, 10, "Michael Jackson");

        // Ajout des m�dias � la biblioth�que
        library.AjouterMedia(livre1);
        library.AjouterMedia(livre2);
        library.AjouterMedia(dvd1);
        library.AjouterMedia(dvd2);
        library.AjouterMedia(cd1);

        // Affichage de tous les m�dias
        library.AfficherTousLesMedias();

        // Utilisation de l'indexeur pour rechercher un m�dia
        Console.WriteLine("Recherche d'un m�dia avec la r�f�rence 101 (Le Petit Prince) :");
        Media mediaTrouve = library[101];
        if (mediaTrouve != null)
        {
            mediaTrouve.AfficherInfos();
        }

        // Retirer un m�dia par sa r�f�rence
        Console.WriteLine("\nRetrait du DVD 'Inception' (r�f�rence 201) :");
        library.RetirerMedia(201);

        // Afficher les m�dias apr�s le retrait
        library.AfficherTousLesMedias();

        // Test de l'ajout d'exemplaires avec l'op�rateur +
        Console.WriteLine("\nAjout de 3 exemplaires suppl�mentaires pour 'Le Petit Prince' :");
        library[101] += 3;
        library[101].AfficherInfos();

        // Test de la suppression d'exemplaires avec l'op�rateur -
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

        // Affichage final de tous les m�dias
        Console.WriteLine("\nListe finale des m�dias dans la biblioth�que :");
        library.AfficherTousLesMedias();
    }
}
