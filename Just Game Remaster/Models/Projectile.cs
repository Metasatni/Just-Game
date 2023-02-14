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
        X = x;
        Y = y;
        _direction = direction;
        _shooter = shooter;
        _damage = 0;
    }

    public override void Tick(GameObjects gameObjects)
    {
        Move(_direction);
    }

}
