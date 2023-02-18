using Just_Game_Remaster.Drawing;
using Just_Game_Remaster.Models;

namespace Just_Game_Remaster.Engine;

internal class Game
{
    private const int TICK_RATE = 64;

    private readonly GameTimer _gameTimer = GameTimer.CreateByTickRate(TICK_RATE);
    private readonly GameObjects _gameObjects = new GameObjects();
    private readonly IPrinter _printer = new ConsolePrinter();
    private readonly BulletFactory _bulletFactory = new BulletFactory();
    private readonly GameObjectFactory _gameObjectFactory = new GameObjectFactory();
    private readonly GameEventsProcessor _gameEventsProcessor;

    public Game() {
        _gameEventsProcessor = new GameEventsProcessor(_gameObjects);
    }

    private void CreateStartModels()
    {
        _gameObjects.Add(_gameObjectFactory.Create(GameObjectType.Player));
        _gameObjects.Add(_gameObjectFactory.Create(GameObjectType.Enemy));
        _gameObjects.Add(_gameObjectFactory.Create(GameObjectType.Enemy));
        _gameObjects.Add(_gameObjectFactory.Create(GameObjectType.Enemy));
        _gameObjects.Add(_gameObjectFactory.Create(GameObjectType.Bandage));

    }

    private void SetupConsole()
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.CursorVisible = false;
    }

    public void Start()
    {
        SetupConsole();

        CreateStartModels();

        _gameTimer.Start();

        while (IsPlayerAlive()) {

            Thread.Sleep(20);

            _printer.PrintFrame(_gameObjects);

            if (_gameTimer.TickReady()) Tick();

        }

        EndGame();

    }

    private bool IsPlayerAlive() {
        bool isAlive = _gameObjects.Player.Hp > 0;
        return isAlive;
    }

    private void Tick()
    {

        foreach (var gameObject in _gameObjects.Get().ToList()) {
            var events = gameObject.Tick(_gameObjects);
            _gameEventsProcessor.HandleEvents(events);
        }

        _gameObjects.RemoveDeadObjects();

    }

    public void EndGame()
    {
        _printer.DrawGameOverFrame();
        Thread.Sleep(700);
        Console.ReadKey();
    }
}