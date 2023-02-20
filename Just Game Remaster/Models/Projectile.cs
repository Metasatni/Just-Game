using Just_Game_Remaster.Engine;

namespace Just_Game_Remaster.Models;

internal abstract class Projectile : GameObject
{
    protected readonly Direction _direction;
    protected readonly GameObjectType _shooter;
    protected int _damage;

    public int Damage => _damage;
    public override char Character => '.';
    public GameObjectType Shooter => _shooter;

    public Projectile(GameObject gameObject, Direction direction)
        : this(gameObject.X, gameObject.Y, direction, gameObject.Type) {
    }

    private Projectile(int x, int y, Direction direction, GameObjectType shooter)
    {
        this.X = x;
        this.Y = y;
        _direction = direction;
        _shooter = shooter;
        _damage = 0;
    }

    public override void Tick()
    {
        var gameEvents = new List<IGameEvent>();
        Move(_direction);
        if (IsOutOfBounds()) base.Tick();
        TryAddObjectShotEvent(gameEvents);
    }

    private bool IsOutOfBounds() {
        if (BorderChecker.IsInBounds(this)) return false;
        base.IsDead = true;
        return true;
    }

    private void TryAddObjectShotEvent(List<IGameEvent> gameEvents) {
        if (!this.IsOnObject(_gameObjects, out var target)) return;
        target.OnShot(this);
    }
    
    

}
