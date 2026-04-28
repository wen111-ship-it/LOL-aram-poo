public class Road : Building
    {
        public Road(): base("route", 5)
        {
        }
        public override char getsymbol()
        {
            return 'R';
        }
    } 