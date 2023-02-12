using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Linq;

namespace Just_Game_Remaster;

enum Direction
{
    Down,
    Up,
    Left,
    Right,
}
internal class Game
{
    private const int TICK_RATE = 64;

    private readonly GameTimer _gameTimer = GameTimer.CreateByTickRate(TICK_RATE);
    private readonly List<GameObject> _gameObjects = new List<GameObject>();
    private readonly Printer _printer = new Printer();
    private readonly BulletFactory _bulletFactory = new BulletFactory();

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

        _gameObjects.Add(new Player());
        _gameObjects.Add(new Enemy(Map.WIDTH/2,Map.HEIGHT/2));

        while (true) {

            Thread.Sleep(20);

            if (_gameTimer.TickReady()) Tick();

            _printer.PrintFrame(_gameObjects);



        }

    }

    private void Tick() {

        ProcessInputs();

        foreach (var gameObject in _gameObjects) gameObject.Tick();

        TickBullets();

    }

    private void ProcessInputs()
    {
        if (!Console.KeyAvailable) return;

        var key = Console.ReadKey(true);

        var player = _gameObjects.Single(x => x is Player);

        switch (key.Key)
        {
            case ConsoleKey.DownArrow:
                Move(Direction.Down);
                break;
            case ConsoleKey.UpArrow:
                Move(Direction.Up);
                break;
            case ConsoleKey.LeftArrow:
                Move(Direction.Left);
                break;
            case ConsoleKey.RightArrow:
                Move(Direction.Right);
                break;
            case ConsoleKey.W:
                TryShoot(player, Direction.Up);
                break;
            case ConsoleKey.S:
                TryShoot(player, Direction.Down);
                break;
            case ConsoleKey.A:
                TryShoot(player, Direction.Left);
                break;
            case ConsoleKey.D:
                TryShoot(player, Direction.Right);
                break;
        }
    }

    private void TryShoot(GameObject gameObject, Direction direction) {

        var bullet = _bulletFactory.TryCreateBullet(gameObject, direction);

        if (bullet is null) return;
        
        _gameObjects.Add(bullet);

    }

    private void Move(Direction direction)
    {
        var player = _gameObjects.Single(x => x is Player);
        if (BorderChecker.WillBeInBounds(player, direction)) {
            player.Move(direction);
        }
    }
  
    private void TickBullets()
    {
        var bullets = _gameObjects.OfType<Bullet>().ToList();
        var enemies = _gameObjects.OfType<Enemy>().ToList();

        if (bullets?.Any() != true) return;

        foreach (var bullet in bullets) {
            if (!BorderChecker.IsInBounds(bullet)) _gameObjects.Remove(bullet);
            foreach(var enemy in enemies) {
                if(enemy.X == bullet.X && enemy.Y == bullet.Y) {
                _gameObjects.Remove(enemy); SpawnEnemyRandomPos();
                }
            }
        }
    }
    private void SpawnEnemyRandomPos()
    {
        Random random = new Random();
        int x = random.Next(1,Map.WIDTH - 1);
        int y = random.Next(1, Map.HEIGHT - 1);
        _gameObjects.Add(new Enemy(x, y));
    }
}