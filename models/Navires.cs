using System;

public abstract class Navires 
{
    public Navires(string name, int size, int cost)
    {
        Name = name;
        Size = size;
        Cost = cost;
        Color = ConsoleColor.White; // Couleur par défaut
        IsHit = false;
    }

    public string Name { get; set; }
    public int Size { get; set; }
    public int Cost { get; set; }
    public int Hits { get; set; } = 0;
    public bool IsSunk => Hits >= Size;
    public ConsoleColor Color { get; set; }
    public bool IsHit { get; set; }

    // Méthode abstraite - chaque bateau doit définir son symbole
    public abstract char GetSymbol();

    // Méthode appelée quand le bateau est touché
    public void Hit()
    {
        Hits++;
        IsHit = true;
        Color = ConsoleColor.Red; // Passe au rouge quand touché
    }

    
}