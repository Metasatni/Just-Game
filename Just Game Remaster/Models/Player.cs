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

    public override char Character => 'X';
    public override GameObjectType Type => GameObjectType.Player;
    public int Hp { get => _hp; set => _hp = Math.Min(value, MAX_HP); }
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

        if (canShoot) projectile = new Bullet(X, Y, direction, Type);

        return canShoot;

    }

    public override List<IGameEvent> Tick(GameObjects gameObjects) {
        var gameEvents = new List<IGameEvent>();
        TryAddOnPlayerInputEvent(gameEvents);
        return gameEvents;
    }

    private void TryAddOnPlayerInputEvent(List<IGameEvent> gameEvents) {
        if (!Console.KeyAvailable) return;
        var consoleKeyInfo = Console.ReadKey(true);
        var gameEvent = new OnPlayerInputEvent(consoleKeyInfo.Key);
        gameEvents.Add(gameEvent);
    }

}
