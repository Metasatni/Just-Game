using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal class Bullet : Projectile { 

    public override char Character => GetCharacter();
    public override GameObjectType Type => GameObjectType.Bullet;
    public Bullet(int x, int y, Direction direction, GameObjectType shooter)
        : base(x, y, direction, shooter)
    {

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
