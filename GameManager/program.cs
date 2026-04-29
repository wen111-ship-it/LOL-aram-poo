using System.Runtime.InteropServices;

SeaMap seaMapPlayer = new SeaMap(10, 10);

// Phase de placement des bateaux
Console.WriteLine("=== BATAILLE NAVALE ===");
Console.WriteLine("Phase de placement des bateaux\n");

// Bateaux du joueur
Navires[] playerShips = new Navires[]
{
    new Carrier(),
    new Battleship(),
    new Destroyer(),
    new Submarine(),
    new Submarine()
};
QuitHelper.AskForQuit();

        

// Créer l'ennemi (avec ses bateaux aléatoires)
Console.WriteLine("L'ordinateur place ses bateaux...");
Enemy enemy = new Enemy(10, 10);
Console.WriteLine("Bateaux de l'ordinateur placés!\n");

// Placement des bateaux du joueur
foreach (Navires ship in playerShips)
{
    while (true)
    {
        Console.Clear();
        seaMapPlayer.DisplayPlayerMap();
        Console.WriteLine($"\nPlacement: {ship.Name} (Taille: {ship.Size})");
        Console.WriteLine("Entrez les coordonnées et direction:");
        Console.WriteLine("  Format: <lettre> <chiffre> <orientation>");
        Console.WriteLine("  Orientation: h = horizontal (en LIGNE), v = vertical (en COLONNE)");
        Console.WriteLine("  Exemple: A 0 h   -> place le bateau horizontalement à partir de A0");
        string? input = Console.ReadLine();
        QuitHelper.AskForQuit();

        if (string.IsNullOrWhiteSpace(input))
            continue;

        string[] parts = input.Split(' ');

        if (parts.Length >= 3 && 
            char.TryParse(parts[0].ToUpper(), out char letterX) && 
            int.TryParse(parts[1], out int y))
        {
            int x = SeaMap.LetterToX(letterX);
            string orientation = parts[2].ToLower();
            bool horizontal = (orientation == "h" || orientation == "l");
            
            if (seaMapPlayer.PlaceShip(ship, x, y, horizontal))
            {
                Console.WriteLine("Bateau placé!");
                break;
            }
        }
        else
        {
            Console.WriteLine("Entrée invalide. Format: A 0 h/v (lettre espace chiffre espace orientation)");
            Console.ReadKey();
        }
    }

        
}

// Phase de jeu - tirer sur les bateaux
Console.Clear();
Console.WriteLine("=== DÉBUT DE LA BATAILLE ===");
Console.WriteLine("Tirez sur les bateaux ennemis!");
Console.ReadKey();

while (true)
{
    Console.Clear();
    GameManager.DisplayStats();

    // Afficher les deux cartes côte à côte
    seaMapPlayer.DisplayPlayerMap();
    Console.WriteLine();
    enemy.SeaMap.DisplayRadar();
    
    

    if (enemy.HasLost)
    {
        Console.WriteLine("\nFÉLICITATIONS! Vous avez coulé tous les bateaux!");
        break;
    }
    bool confirmation = false;
    while(confirmation == false)
    {
        Console.WriteLine("\nEntrez les coordonnées pour tirer (lettre chiffre) ou 'q' pour quitter:");
        string? input = Console.ReadLine();

        if (input == null || input.ToLower() == "q")
            break;

        string[] parts = input.Split(' ');

        if (parts.Length == 2 && char.TryParse(parts[0].ToUpper(), out char letterX) && int.TryParse(parts[1], out int y))
        {
            int x = SeaMap.LetterToX(letterX);
            GameManager.Shots++;
            enemy.SeaMap.Fire(x, y);
            Console.ReadKey();
            confirmation = true;
        }
        else
        {
            Console.WriteLine("Entrée invalide. Veuillez entrer une lettre et un chiffre (ex: A 5).");
            Console.ReadKey();
        }
    
    }

    // L'ordinateur tire à son tour
    Console.WriteLine("\nL'ordinateur tire...");
    enemy.Shoot(seaMapPlayer);
    Console.ReadKey();
    
    
    
}

