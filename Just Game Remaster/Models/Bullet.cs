namespace Just_Game_Remaster.Models;

internal class Bullet : Projectile
{
    public override char Character => GetCharacter();
    public override GameObjectType Type => GameObjectType.Bullet;

    public Bullet(GameObject gameObject, Direction direction)
        : base(gameObject, direction) {

        _damage = 20;

    }

    private char GetCharacter()
    {
        return _direction switch
        {
            Direction.Down or Direction.Up => '|',
            Direction.Left or Direction.Right => '-',
            _ => throw new NotImplementedException(),
        };
    }
}
