public class Battleship : Navires
{
    public Battleship() : base("Croiseur", 4, 400)
    {
        Color = ConsoleColor.Cyan;
    }

    public override char GetSymbol()
    {
        return 'C';
    }
}