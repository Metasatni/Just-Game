using Just_Game_Remaster;
using Just_Game_Remaster.Engine;
using System.Security.Cryptography.X509Certificates;

internal class Program
{

    private static void Main(string[] args) {
        while (true) {
            Map map = new Map();
            Game game = new Game();
            game.Start();
        }
    }

}