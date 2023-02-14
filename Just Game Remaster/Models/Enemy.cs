using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Just_Game_Remaster.Models;

internal class Enemy : Shooter
{

    private Random random = new Random();
    private GameTimer _cooldownTimer;

    private int _movingCooldownInMs;
    protected override int _shootingCooldownInMs => 1000;
    public override char Character => 'O';

    public override GameObjectType Type => GameObjectType.Enemy;


    public Enemy(int x, int y)
    {
        X = x;
        Y = y;
        _cooldownTimer = GameTimer.CreateByMs(_movingCooldownInMs);
        _cooldownTimer.Start();
    }

    public override OnShotAction OnShot(Projectile projectile)
    {
        if (projectile.Shooter != GameObjectType.Enemy) return OnShotAction.Respawn;
        return OnShotAction.None;
    }

    public override bool TryShoot(Direction direction, out Projectile projectile)
    {
        bool canShoot = CanShoot();

        projectile = null;

        if (canShoot) projectile = new Bullet(X, Y, direction, Type);

        return canShoot;

    }

    public override void Tick(GameObjects gameObjects)
    {
        Shoot(gameObjects);
        TryMoveTowardsObject(gameObjects.Player);
    }

    public void Shoot(GameObjects gameObjects)
    {

        var direction = PathFinder.FindClosestDirection(this, gameObjects.Player);

        if (!TryShoot(direction, out var projectile)) return;

        gameObjects.Add(projectile);

    }

    public void TryMoveTowardsObject(GameObject gameObject)
    {
        var direction = PathFinder.FindClosestDirection(this, gameObject);

        if (CanMove()) Move(direction);
    }

    //protected bool CanMove() => _cooldownTimer.TickReady();
    protected bool CanMove()
    {
        return random.Next(1, 25) == 3;
    }


}
