public class Enemy
{
    private SeaMap _seaMap;
    private Navires[] _ships;
    private Random _random;
    private List<(int x, int y)> _potentialTargets;
    private List<(int x, int y)> _alreadyShot;

    public Enemy(int width, int height)
    {
        _random = new Random();
        _seaMap = new SeaMap(width, height);
        _potentialTargets = new List<(int x, int y)>();
        _alreadyShot = new List<(int x, int y)>();
        
        // Créer les bateaux de l'ennemi
        _ships = new Navires[]
        {
            new Carrier(),
            new Battleship(),
            new Destroyer(),
            new Submarine(),
            new Submarine()
        };
        
        // Placer les bateaux aléatoirement
        PlaceShipsRandomly();
    }

    public SeaMap SeaMap => _seaMap;

    private void PlaceShipsRandomly()
    {
        foreach (Navires ship in _ships)
        {
            bool placed = false;
            int attempts = 0;
            
            while (!placed && attempts < 100)
            {
                int x = _random.Next(_seaMap.Width);
                int y = _random.Next(_seaMap.Height);
                bool horizontal = _random.Next(2) == 0;
                
                if (_seaMap.CanPlaceShip(ship, x, y, horizontal))
                {
                    _seaMap.PlaceShip(ship, x, y, horizontal);
                    placed = true;
                }
                attempts++;
            }
        }
    }

    // L'ennemi tire sur la carte du joueur
    public void Shoot(SeaMap playerMap)
    {
        int x, y;
        bool validShot = false;
        
        // Essayer de trouver une case non encore tirée
        while (!validShot)
        {
            x = _random.Next(_seaMap.Width);
            y = _random.Next(_seaMap.Height);
            
            // Vérifier si on n'a pas déjà tiré ici
            bool alreadyShot = false;
            foreach (var shot in _alreadyShot)
            {
                if (shot.x == x && shot.y == y)
                {
                    alreadyShot = true;
                    break;
                }
            }
            
            if (!alreadyShot)
            {
                _alreadyShot.Add((x, y));
                validShot = true;
                
                // Effectuer le tir
                playerMap.EnemyFire(x, y);
                Console.WriteLine($"L'ordinateur tire en {SeaMap.XToLetter(x)} {y}!");
            }
        }
    }

    public bool HasLost => _seaMap.AllShipsSunk();
    
}