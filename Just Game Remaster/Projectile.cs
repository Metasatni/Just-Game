
namespace Just_Game_Remaster;

internal abstract class Projectile : GameObject
{
    protected readonly Direction _direction;
    protected readonly GameObjectType _shooter;

    public override char Character => '.';
    public GameObjectType Shooter => _shooter;

    public Projectile(int x, int y, Direction direction, GameObjectType shooter)
    {
        this.X = x;
        this.Y = y;
        _direction = direction;
        _shooter = shooter;
    }

    public override void Tick(GameObjects gameObjects)
    {
        Move(_direction);
    }

}
