using System.Runtime.InteropServices;

CityMap carte= new CityMap(10, 10);
while (true)
{
    Console.Clear();
    GameManager.DisplayStats();
    carte.Display();
    Console.WriteLine("quel types de bâtiment voulez-vous placer ?");
    string choice = Console.ReadLine();
    Building building;  

    if (choice.ToLower() == "m")
    {
        building = new House();
    }

    else if (choice.ToLower() == "p")
    {
        building = new Park();
    }

    else if (choice.ToLower() == "c")
    {
        building = new PowerPlant  ();
    }
    else if (choice.ToLower() == "w")
    {
        building = new WaterTower();
    }

    else if (choice.ToLower() == "ps")
    {
        carte.EndTurn();
        continue;
    }
    else if (choice.ToLower() == "r")
    {
        building = new Road();
    }   

    else
    {
        Console.WriteLine("Type de bâtiment invalide. Veuillez entrer 'm','r','p','c','w' ou PS.");
        Console.ReadKey();
        continue;
    }

    Console.WriteLine("Entrez les coordonnées pour placer un bâtiment (x y) ou 'q' pour quitter:");
    string input = Console.ReadLine();

    if (input.ToLower() == "q")
        break;  
    string[] parts = input.Split(' ');

    if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
    {
        carte.PlaceBuilding(building, x, y);
    }

    else
    {
        Console.WriteLine("Entrée invalide. Veuillez entrer des coordonnées valides.");
        Console.ReadKey();
    }




}

