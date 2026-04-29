public class Submarine : Navires
{
    public Submarine() : base("Sous-marin", 2, 200)
    {
        Color = ConsoleColor.Magenta;
    }

    public override char GetSymbol()
    {
        return 'S';
    }
}