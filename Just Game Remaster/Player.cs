using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal class Player : Shooter
{

    public override char Character => 'X';
    public override GameObjectType Type => GameObjectType.Player;
    public int Hp { get; set; }
    public const int ShootDamage = 20;

    protected override int _shootingCooldownInMs => 100;

    public Player()
    {
        this.X = 1;
        this.Y = 1;
        this.Hp = 100;
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
        CheckIfAlive(gameObjects);
    }
    public override OnShotAction OnShot(Projectile projectile)
    {
        if (projectile.Shooter != GameObjectType.Player) return OnShotAction.DealDamage;
        return OnShotAction.None;
    }
    private void CheckIfAlive(GameObjects gameObjects)
    {
        if (this.Hp <= 0)
        {
            Thread.Sleep(10000); // tu bedzie kurcze koniec
        }
    }

}
