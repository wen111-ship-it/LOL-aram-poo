public class Destroyer : Navires
{
    public Destroyer() : base("Destroyer", 3, 300)
    {
        Color = ConsoleColor.Green;
    }

    public override char GetSymbol()
    {
        return 'D';
    }
}