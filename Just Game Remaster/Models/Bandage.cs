using Just_Game_Remaster.Engine;
using Just_Game_Remaster.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster.Models;

internal class Bandage : GameItem
{
    public override char Character => '%';
    public override GameObjectType Type => GameObjectType.Bandage;
    public int HealValue => 20;

    public Bandage(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

}
