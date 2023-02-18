using Just_Game_Remaster.Engine;
using Just_Game_Remaster.Events;

namespace Just_Game_Remaster.Models;

internal abstract class Projectile : GameObject
{
    protected readonly Direction _direction;
    protected readonly GameObjectType _shooter;
    protected int _damage;

    public int Damage => _damage;
    public override char Character => '.';
    public GameObjectType Shooter => _shooter;

    public Projectile(int x, int y, Direction direction, GameObjectType shooter)
    {
        this.X = x;
        this.Y = y;
        _direction = direction;
        _shooter = shooter;
        _damage = 0;
    }

    public override List<IGameEvent> Tick(GameObjects gameObjects)
    {
        var gameEvents = new List<IGameEvent>();
        Move(_direction);
        if (IsOutOfBounds(gameObjects)) return null;
        TryAddObjectShotEvent(gameEvents, gameObjects);
        return gameEvents;
    }

    private bool IsOutOfBounds(GameObjects gameObjects) {
        if (BorderChecker.IsInBounds(this)) return false;
        base.IsDead = true;
        return true;
    }

    private void TryAddObjectShotEvent(List<IGameEvent> gameEvents, GameObjects gameObjects) {
        if (!this.IsOnObject(gameObjects, out var target)) return;
        gameEvents.Add(new GameObjectShotEvent(this, target));
    }

}
