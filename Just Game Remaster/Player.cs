using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal class Player : GameObject {
    public override void Tick()
    {
        
    }

    public override char Character => 'X';

    public Player()
    {
        this.X = 1;
        this.Y = 1;
    }
}
