public class Building

{
    public Building(string name, int constructioncost,ConsoleColor color= ConsoleColor.White)
    {
        Name = name;
        Constructioncost = constructioncost;
        Color = color;
    }   
    public ConsoleColor Color { get; set; }
    
    
    
   
    public string Name { get;set;}/*nom du bâtiment*/
    public int Constructioncost { get;set;}/*coût de construction*/


    public virtual char getsymbol()//
    {
        return 'B';
    }
    public Building(string name, int constructioncost)//
    {
        Name = name;
        Constructioncost = constructioncost;

    }
   
}