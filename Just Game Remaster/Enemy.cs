using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Just_Game_Remaster;

internal class Enemy : Shooter {

    public override char Character => 'O';

    public override GameObjectType Type => GameObjectType.Enemy;

    protected override int _shootingCooldownInMs => 1000;

    public Enemy(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override OnShotAction OnShot(Projectile projectile) {
        if(projectile.Shooter != GameObjectType.Enemy) return OnShotAction.Respawn;
        return OnShotAction.None;
    }

    public override bool TryShoot(Direction direction, out Projectile projectile)
    {
        bool canShoot = CanShoot();

        projectile = null;

        if (canShoot) projectile = new Bullet(this.X, this.Y, direction, this.Type);

        return canShoot;

    }

    public override void Tick(GameObjects gameObjects)
    {
        Shoot(gameObjects);
    }

    public void Shoot(GameObjects gameObjects)
    {
        Direction direction;
        Player player = gameObjects.Player;

        if (player.X < this.X) direction = Direction.Left;
        else if (player.X > this.X) direction = Direction.Right;
        else if (player.Y < this.Y) direction = Direction.Up;
        else direction = Direction.Down;

        if (!TryShoot(direction, out var projectile)) return;

        
        gameObjects.Add(projectile);

    }

}
