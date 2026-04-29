using System;
using System.Collections.Generic;
using System.Linq;

public class SeaMap 
{
    private Navires[,] _grid;
    private bool[,] _shotsFired;
    private bool[,] _enemyShotsFired; // Tirs adverses sur cette carte
    private int _Width;
    private int _Height;
    private List<Navires> _ships = new List<Navires>();

    public int Width => _Width;
    public int Height => _Height;
    public List<Navires> Ships => _ships;

    public SeaMap(int width, int height)
    {
        _Width = width;
        _Height = height;
        _grid = new Navires[width, height];
        _shotsFired = new bool[width, height];
        _enemyShotsFired = new bool[width, height];
    }

    public void Display()
    {
        DisplayPlayerMap();
    }

    // Affiche la carte du joueur (ses bateaux + tirs ennemis)
    public void DisplayPlayerMap()
    {
        Console.WriteLine("=== VOS BATEAUX ===");
        Console.Write("    ");
        for (int x = 0; x < _Width; x++)
        {
            Console.Write((char)('A' + x) + " ");
        }
        Console.WriteLine();

        for (int y = 0; y < _Height; y++)
        {
            Console.Write(y + "   ");
            for (int x = 0; x < _Width; x++)
            {
                // Afficher les tirs adverses (pour la carte du joueur)
                if (_enemyShotsFired[x, y])
                {
                    if (_grid[x, y] != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('X'); // Touché par l'ennemi
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write('O'); // Raté de l'ennemi
                    }
                }
                else if (_grid[x, y] != null)
                {
                    Console.ForegroundColor = _grid[x, y].Color;
                    Console.Write(_grid[x, y].GetSymbol());
                    Console.ResetColor();
                }
                else
                {
                    Console.Write('.');
                }
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }

    // Affiche le radar (où le joueur a tiré sur l'ennemi)
    public void DisplayRadar()
    {
        Console.WriteLine("=== RADAR (vos tirs) ===");
        Console.Write("    ");
        for (int x = 0; x < _Width; x++)
        {
            Console.Write((char)('A' + x) + " ");
        }
        Console.WriteLine();

        for (int y = 0; y < _Height; y++)
        {
            Console.Write(y + "   ");
            for (int x = 0; x < _Width; x++)
            {
                if (_shotsFired[x, y])
                {
                    if (_grid[x, y] != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('X'); // Touché un bateau ennemi
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write('O'); // À l'eau
                    }
                }
                else
                {
                    Console.Write('.'); // Pas encore tiré
                }
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }

    // Convertit une lettre (A-J) en coordonnée x (0-9)
    public static int LetterToX(char letter)
    {
        return char.ToUpper(letter) - 'A';
    }

    // Convertit une coordonnée x (0-9) en lettre (A-J)
    public static char XToLetter(int x)
    {
        return (char)('A' + x);
    }

    public bool PlaceShip(Navires ship, int x, int y, bool horizontal)
    {
        if (!CanPlaceShip(ship, x, y, horizontal))
        {
            Console.WriteLine("Impossible de placer le bateau à cet endroit.");
            return false;
        }

        for (int i = 0; i < ship.Size; i++)
        {
            int posX = horizontal ? x + i : x;
            int posY = horizontal ? y : y + i;
            _grid[posX, posY] = ship;
        }

        _ships.Add(ship);
        return true;
    }

    public bool CanPlaceShip(Navires ship, int x, int y, bool horizontal)
    {
        for (int i = 0; i < ship.Size; i++)
        {
            int posX = horizontal ? x + i : x;
            int posY = horizontal ? y : y + i;

            if (posX >= _Width || posY >= _Height)
                return false;

            if (_grid[posX, posY] != null)
                return false;
        }
        return true;
    }

    public bool Fire(int x, int y)
    {
        if (x < 0 || x >= _Width || y < 0 || y >= _Height)
        {
            Console.WriteLine("Coordonnées hors limites!");
            return false;
        }

        if (_shotsFired[x, y])
        {
            Console.WriteLine("Vous avez déjà tiré ici!");
            return false;
        }

        _shotsFired[x, y] = true;

        if (_grid[x, y] != null)
        {
            _grid[x, y].Hit();
            Console.WriteLine("TOUCHÉ!");

            if (_grid[x, y].IsSunk)
            {
                int reward = _grid[x, y].Cost;
                GameManager.points += reward;
                Console.WriteLine($"Le {_grid[x, y].Name} a été coulé! Vous gagnez {reward} points!");
            }
            return true;
        }
        else
        {
            Console.WriteLine("À l'eau!");
            return false;
        }
    }

    public int ShipCount => _ships.Count;

    public bool AllShipsSunk()
    {
        return _ships.All(ship => ship.IsSunk);
    }

    // Méthode pour l'ordinateur pour tirer sur cette carte
    public bool EnemyFire(int x, int y)
    {
        if (x < 0 || x >= _Width || y < 0 || y >= _Height)
            return false;

        if (_enemyShotsFired[x, y])
            return false;

        _enemyShotsFired[x, y] = true;

        if (_grid[x, y] != null)
        {
            _grid[x, y].Hit();
            Console.WriteLine("L'ordinateur vous a Touché!");
            if (_grid[x, y].IsSunk)
            {
                Console.WriteLine($"Votre {_grid[x, y].Name} a été coulé!");
            }
            return true;
        }
        else
        {
            Console.WriteLine("L'ordinateur a tiré dans l'eau!");
            return false;
        }
    }

    // Place les bateaux de manière aléatoire
    public void PlaceShipsRandomly(Navires[] ships)
    {
        Random random = new Random();
        
        foreach (Navires ship in ships)
        {
            bool placed = false;
            int attempts = 0;
            
            while (!placed && attempts < 100)
            {
                int x = random.Next(_Width);
                int y = random.Next(_Height);
                bool horizontal = random.Next(2) == 0;
                
                if (CanPlaceShip(ship, x, y, horizontal))
                {
                    PlaceShip(ship, x, y, horizontal);
                    placed = true;
                }
                attempts++;
            }
        }
    }

    
}