using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Just_Game_Remaster.Models;

namespace Just_Game_Remaster.Engine
{
    internal static class BorderChecker
    {

        public static bool IsInBounds(GameObject gameObject)
        {
            return IsInBounds(gameObject.X, gameObject.Y);
        }

        public static bool WillBeInBounds(GameObject gameObject, Direction direction)
        {
            int x = gameObject.X;
            int y = gameObject.Y;

            switch (direction)
            {
                case Direction.Down:
                    y++;
                    break;
                case Direction.Up:
                    y--;
                    break;
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
            }

            return IsInBounds(x, y);

        }


        private static bool IsInBounds(int x, int y)
        {
            if (x < Map.WIDTH - 1 && x > 0 && y > 0 && y < Map.HEIGHT - 1) return true;
            return false;
        }

    }
}
