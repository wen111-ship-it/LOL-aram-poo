public class House : Building,IUpdatable
    {
        public House(): base("maison", 10)
        {
        }
       public void OnNextTurn()
       {
        if (GameManager.energy > 0 && GameManager.water > 0)
        {  
            GameManager.energy -= 1;
            GameManager.Money += 50;
        }
        }
        public override char getsymbol()
        {
            return 'H';
        }

    }