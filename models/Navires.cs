public class Navires 

{
    public Navires(string Name, int Size, int Cost, ConsoleColor color = ConsoleColor.White)
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
    public bool IsSunk => Hits >= Size; //indique si le bâtiment est coulé

    public void Hit()
    {
        Hits++;
    }

    public virtual char GetSymbol()//
    {
        return 'S';
    }
}
    