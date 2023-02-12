using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal class Bullet : GameObject
{
    private readonly Direction _direction;

    public string? Name { get; set; }
    public override char Character => GetCharacter();

    public Bullet(int x, int y, Direction direction)
    {
        this.X = x;
        this.Y = y;
        _direction = direction;
    }

    public override void Tick()
    {
        Move(_direction);

    }

    private char GetCharacter() {
        return _direction switch
        {
            Direction.Down or Direction.Up => '|',
            Direction.Left or Direction.Right => '-',
            _ => throw new NotImplementedException(),
        };
    }
}
