using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Linq;
using System;

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
    private readonly GameObjects _gameObjects = new GameObjects();
    private readonly Printer _printer = new Printer();
    private readonly BulletFactory _bulletFactory = new BulletFactory();
    private readonly GameObjectFactory _gameObjectFactory = new GameObjectFactory();

    private const int DamageFromEnemy = 49;  // do wyrzucenia potem do enemy

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
        _gameObjects.Add(_gameObjectFactory.Create(GameObjectType.Player));
        _gameObjects.Add(_gameObjectFactory.Create(GameObjectType.Enemy));

        while (true) {

            Thread.Sleep(20);

            if (_gameTimer.TickReady()) Tick();

            _printer.PrintFrame(_gameObjects.Get());

        }

    }

    private void Tick() {

        ProcessInputs();

        foreach (var gameObject in _gameObjects.Get().ToList()) gameObject.Tick(_gameObjects);

        TickBullets();
    }

    private void ProcessInputs()
    {
        Projectile projectile;
        Direction direction;

        if (!Console.KeyAvailable) return;

        var key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.DownArrow:
            case ConsoleKey.UpArrow:
            case ConsoleKey.LeftArrow:
            case ConsoleKey.RightArrow:
                direction = GetDirectionByConsoleKey(key.Key);
                _gameObjects.Player.TryMove(direction);
                break;
            case ConsoleKey.W:
            case ConsoleKey.S:
            case ConsoleKey.A:
            case ConsoleKey.D:
                direction = GetDirectionByConsoleKey(key.Key);
                if (!_gameObjects.Player.TryShoot(direction, out projectile)) return;
                _gameObjects.Add(projectile);
                break;
        }
    }

    private Direction GetDirectionByConsoleKey(ConsoleKey consoleKey) {
        return consoleKey switch
        {
            ConsoleKey.A or ConsoleKey.LeftArrow => Direction.Left,
            ConsoleKey.D or ConsoleKey.RightArrow => Direction.Right,
            ConsoleKey.W or ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.S or ConsoleKey.DownArrow => Direction.Down,
            _ => throw new ArgumentException()
        };
    }
  
    private void TickBullets()
    {
        var projectiles = _gameObjects.Get<Projectile>();
        var enemies = _gameObjects.Get<Enemy>();
        var player = _gameObjects.Player;
        if (projectiles?.Any() != true) return;

        foreach (var projectile in projectiles) {
            if (!BorderChecker.IsInBounds(projectile)) _gameObjects.Remove(projectile);
            foreach(var gameObject in enemies) {
                if(gameObject.X == projectile.X && gameObject.Y == projectile.Y) {
                    var action = gameObject.OnShot(projectile);
                    ProcessGameObjectShot(gameObject, action);
                }
            }
            if (player.X == projectile.X && player.Y == projectile.Y)
            {
                var action = player.OnShot(projectile);
                ProcessGameObjectShot(player, action);
            }
        }
    }
    private void ProcessGameObjectShot(GameObject gameObject, OnShotAction action)
    {
        switch (action)
        {
            case OnShotAction.RemoveFromGame:
                _gameObjects.Remove(gameObject);
                break;
            case OnShotAction.Respawn:
                var newGameObject = _gameObjectFactory.Create(gameObject.Type);
                _gameObjects.Remove(gameObject);
                _gameObjects.Add(newGameObject);
                break;
            case OnShotAction.DealDamage:
                _gameObjects.Player.Hp -= DamageFromEnemy;
                break;
        }
    }
}