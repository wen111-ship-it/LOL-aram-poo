public class PowerPlant : Building, IUpdatable
{
    public PowerPlant(ConsoleColor color= ConsoleColor.White) : base("Centrale", 500, color)
    {}  
   public void OnNextTurn()
    {
        GameManager.energy += 10;
        GameManager.Money -= 50;

    }
    public override char getsymbol()
    {
        return 'E';
    }

   
}