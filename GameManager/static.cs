public static class GameManager
{
public static int Money { get; set; } = 2000;

public static int energy { get; set; } = 0;
public static int water { get; set; } = 0;
public static void DisplayStats()
{
    Console.WriteLine($"Money: {Money}");
    Console.WriteLine($"Energy: {energy}");
    Console.WriteLine($"Water: {water}");
}
}
