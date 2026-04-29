public static class GameManager
{
    public static int points { get; set; } = 1000;
    public static int Shots { get; set; } = 0;
    public static int Hits { get; set; } = 0;

    public static void DisplayStats()
    {
        Console.WriteLine($"Points: {points}");
        Console.WriteLine($"Tirs: {Shots}");
        Console.WriteLine($"Touchés: {Hits}");
    }
}