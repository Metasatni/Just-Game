using Just_Game_Remaster;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Map map = new Map();
        Game game = new Game();
        game.Start();
        Console.Read();
    }
}