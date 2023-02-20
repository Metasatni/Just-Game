using Just_Game_Remaster.Drawing;

namespace Just_Game_Remaster.Engine;

internal class Game
{
    private const int TICK_RATE = 64;

    private readonly GameTimer _gameTimer = GameTimer.CreateByTickRate(TICK_RATE);
    private readonly IPrinter _printer = new ConsolePrinter();
    private GameObjects _gameObjects => ServiceProvider.GetService<GameObjects>();
    private GameObjectsSpawner _gameObjectsSpawner => ServiceProvider.GetService<GameObjectsSpawner>();

    public Game() {
        _gameObjects.Clear();
    }

    private void CreateStartModels()
    {
        _gameObjectsSpawner.SpawnPlayer();
        _gameObjectsSpawner.SpawnEnemy();
        _gameObjectsSpawner.SpawnEnemy();
        _gameObjectsSpawner.SpawnEnemy();
        _gameObjectsSpawner.SpawnBandage();
        _gameObjectsSpawner.SpawnMine();

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
            gameObject.Tick();
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