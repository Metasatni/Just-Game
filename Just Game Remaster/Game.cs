using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Just_Game_Remaster;


internal class Game
{
    private readonly GameTimer _gameTimer = new GameTimer();
    private readonly List<GameObject> _gameObjects = new List<GameObject>();
    private readonly Printer _printer = new Printer();

    public Game()
    {

    }

    private void SetupConsole () {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.CursorVisible = false;
    }

    public void Start()
    {
        SetupConsole();

        _gameTimer.Start();

        _gameObjects.Add(new Player("some"));

        while (true) {

            ProcessInputs();

            _printer.PrintFrame(_gameObjects);

        }

    }

    private void ProcessInputs()
    {
        if (!Console.KeyAvailable) return;

        var key = Console.ReadKey(true);

        var player = _gameObjects.Single(x => x is Player);

        switch (key.Key)
        {
            case ConsoleKey.DownArrow:
                player.Y += 1;
                NoWalkingOnBorder(1);
                break;
            case ConsoleKey.UpArrow:
                player.Y -= 1;
                NoWalkingOnBorder(2);
                break;
            case ConsoleKey.LeftArrow:
                NoWalkingOnBorder(3);
                player.X -= 1;
                break;
            case ConsoleKey.RightArrow:
                NoWalkingOnBorder(4);
                player.X += 1;
                break;
            default:
                break;
        }
    }
    private void NoWalkingOnBorder(int direction)
    {
        var player = _gameObjects.Single(x => x is Player);
        switch (direction)
        {
            case 1:
                break;
        }
    }
}
