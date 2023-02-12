using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal class Player : GameObject {

    public string? Name { get; set; }

    public override char Character => 'X';

    public Player (string? name)
    {
        this.Name = name;
        this.X = 1;
        this.Y = 1;
    }

}
