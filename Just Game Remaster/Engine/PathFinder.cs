using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Just_Game_Remaster.Models;

namespace Just_Game_Remaster.Engine;

internal static class PathFinder
{

    public static Direction FindClosestDirection(GameObject source, GameObject target)
    {

        var absoluteDiffX = Math.Abs(source.X - target.X);
        var absoluteDiffY = Math.Abs(source.Y - target.Y);

        return absoluteDiffX > absoluteDiffY
            ? source.X > target.X ? Direction.Left : Direction.Right
            : source.Y > target.Y ? Direction.Up : Direction.Down;

    }

}
