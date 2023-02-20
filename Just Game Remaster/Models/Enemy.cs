using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Just_Game_Remaster.Engine;
using Just_Game_Remaster.Events;

namespace Just_Game_Remaster.Models;

internal class Enemy : Shooter
{
    private Random _random = new Random();
    protected override int _shootingCooldownInMs => 1000;

    public override char Character => 'O';
    public override GameObjectType Type => GameObjectType.Enemy;

    public Enemy(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override bool TryShoot(Direction direction, out Projectile projectile)
    {
        bool canShoot = CanShoot();

        projectile = null;

        if (canShoot) projectile = new Bullet(X, Y, direction, Type);

        return canShoot;

    }

    public override List<IGameEvent> Tick(GameObjects gameObjects) {
        Shoot(gameObjects);
        TryMoveTowardsObject(gameObjects.Player, gameObjects);
        return base.Tick(gameObjects);
    }

    private void Shoot(GameObjects gameObjects)
    {
        var direction = PathFinder.FindClosestDirection(this, gameObjects.Player);

        if (!TryShoot(direction, out var projectile)) return;

        gameObjects.Add(projectile);
    }

    private void TryMoveTowardsObject(GameObject gameObject, GameObjects gameObjects)
    {
        var direction = PathFinder.FindClosestDirection(this, gameObject);

        if (CanMove(direction,gameObjects)) Move(direction);
    }

    protected bool CanMove(Direction direction, GameObjects gameObjects)
    {
        if (this.WillBeOnObject(gameObjects.Get(), direction, out var hitResult)) {
            if (hitResult is Player) return false;
        }
        return _random.Next(1, 25) == 3;
    }

}
