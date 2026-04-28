public class CityMap
{
  private Building[,] map;
  private int _Width;//largeur de la carte
  private int _Height;//hauteur de la carte
  private List<Building> _buildings = new List<Building>();

  public void Display()
    {
        for (int X =0; X < _Width; X++)
        {
            for (int Y = 0; Y < _Height; Y++)
            {
                if (map[X, Y] != null)
                {
                    Console.Write(map[X, Y].getsymbol());
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
        
    }
    public List<Building> ConstructBuilding(int x, int y, Building building)
    {
        if (x >= 0 && x < _Width && y >= 0 && y < _Height)
        {
            if (map[x, y] == null)
            {
               if (GameManager.Money >= building.Constructioncost)
                {
                    GameManager.Money -= building.Constructioncost;
                    map[x, y] = building;
                    _buildings.Add(building);
                    return _buildings;
                }
                else
                {
                Console.WriteLine("Vous n'avez pas assez d'argent pour construire ce bâtiment.");
                
                } 
            }
            
            else 
            {
                Console.WriteLine("Il y a déjà un bâtiment à cet emplacement.");
               
            }
        }
        
    }


  public CityMap(int width, int height)
    {
        _Width = width;
        _Height = height;
        map = new Building[width, height];
        
    }
    public void EndTurn(List<Building> buildings)
    {
        for (int X = 0; X < _Width; X++)
        {
            for (int Y = 0; Y < _Height; Y++)
            {
                if (map[X, Y] is IUpdatable updatable)
                {
                    updatable.OnNextTurn();
                }
            }
        }
    }
}