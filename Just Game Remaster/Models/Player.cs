using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster.Models;

internal class Player : Shooter
{

    public override char Character => 'X';
    public override GameObjectType Type => GameObjectType.Player;
    public int Hp { get; set; }

    protected override int _shootingCooldownInMs => 100;

    public Player()
    {
        X = 1;
        Y = 1;
        Hp = 100;
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
    }

    public override OnShotAction OnShot(Projectile projectile)
    {
        if (projectile.Shooter != GameObjectType.Player) Hp -= projectile.Damage;
        if (Hp <= 0) return OnShotAction.GameEnded;
        return OnShotAction.None;

    }
}
