public class WaterTower : Building, IUpdatable
{
    public WaterTower(ConsoleColor color= ConsoleColor.White) : base("Château d'eau", 200, color)
    {}  
   public void OnNextTurn()
    {
        GameManager.water += 10;
        GameManager.Money -= 10;

    }
    public override char getsymbol()
    {
        return 'W';
    }

   
}