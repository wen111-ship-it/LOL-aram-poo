public class Navires 

{
    public Navires(string Name, int Size,int Cost,ConsoleColor color)
    {
        Name = Name;
        Size = Size;
        Cost = Cost;
        Color = color;
    }   
    public ConsoleColor Color { get; set; }
    public string Name { get;set;}/*nom du bâtiment*/
    public int Size { get;set;}/*taille du batiment */
    public int Cost { get;set;}/*coût du bâtiment*/
    public int Hits { get; set; } = 0;/*nombre de fois que le bâtiment a été touché*/
    public bool IsSunk => Hits >= Size; //indique si le bâtiment est cou


    public virtual char getsymbol()//
    {
        return 'S';
    }
}
    