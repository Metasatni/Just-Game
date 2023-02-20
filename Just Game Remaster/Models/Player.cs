using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Just_Game_Remaster.Engine;
using Just_Game_Remaster.Events;

namespace Just_Game_Remaster.Models;

internal class Player : Shooter
{
    private int _hp;
    private const int MAX_HP = 100;
    private const int MOVING_COOLDOWN_IN_MS = 100;
    private readonly GameTimer _movingCooldownTimer = GameTimer.CreateByMs(MOVING_COOLDOWN_IN_MS);

    public override char Character => 'X';
    public override GameObjectType Type => GameObjectType.Player;
    public int Hp { get => _hp; set => _hp = Math.Min(value, MAX_HP); }
    protected override int _shootingCooldownInMs => 100;

    public Player()
    {
        this.X = 1;
        this.Y = 1;
        this.Hp = 100;
        _movingCooldownTimer.Start();
    }

    public override bool TryShoot(Direction direction, out Projectile projectile)
    {
        bool canShoot = CanShoot();

        projectile = null;

        if (canShoot) projectile = new Bullet(X, Y, direction, Type);

        return canShoot;

    }

    public override List<IGameEvent> Tick(GameObjects gameObjects) {
        ProcessInputs(gameObjects);
        return base.Tick(gameObjects);
    }

    public override bool TryMove(Direction direction) {

        if (!_movingCooldownTimer.TickReady()) return false;

        return base.TryMove(direction);

    }

    private void ProcessInputs(GameObjects gameObjects) {

        Projectile? projectile = null;

        if (Keyboard.IsKeyDown(ConsoleKey.W)) TryShoot(Direction.Up, out projectile);
        if (Keyboard.IsKeyDown(ConsoleKey.S)) TryShoot(Direction.Down, out projectile);
        if (Keyboard.IsKeyDown(ConsoleKey.A)) TryShoot(Direction.Left, out projectile);
        if (Keyboard.IsKeyDown(ConsoleKey.D)) TryShoot(Direction.Right, out projectile);

        if (projectile is not null) gameObjects.Add(projectile);

        if (Keyboard.IsKeyDown(ConsoleKey.UpArrow)) TryMove(Direction.Up);
        if (Keyboard.IsKeyDown(ConsoleKey.DownArrow)) TryMove(Direction.Down);
        if (Keyboard.IsKeyDown(ConsoleKey.LeftArrow)) TryMove(Direction.Left);
        if (Keyboard.IsKeyDown(ConsoleKey.RightArrow)) TryMove(Direction.Right);

    }

}
