public class Carrier : Navires
{
    public Carrier() : base("Porte-avions", 5, 500)
    {
        Color = ConsoleColor.Yellow;
    }

    public override char GetSymbol()
    {
        return 'P';
    }
}