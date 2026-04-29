public static class QuitHelper
{
    public static void AskForQuit()
    {
        Console.WriteLine("\nAppuyez sur Q pour quitter ou entrez une autre touche pour continuer...");
        string? quitInput = Console.ReadLine();

        if (!string.IsNullOrEmpty(quitInput) && quitInput.ToLower() == "q")
        {
            Console.WriteLine("Merci d'avoir joué! À bientôt!");
            Environment.Exit(0); // stoppe complètement le programme
        }
    }
}