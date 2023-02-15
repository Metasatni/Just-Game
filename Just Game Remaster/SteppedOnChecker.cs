using Just_Game_Remaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster
{
    internal class SteppedOnChecker
    {
    
        public static bool IsOnObject(GameObject gameObject,GameObjects gameObjects)
        {
            return IsOnObject(gameObject.X, gameObject.Y,gameObjects);
        }

        public static bool IsOnObject(int x, int y,GameObjects gameObjects)
        {
            var bandages = gameObjects.Get<Bandage>();
            foreach (var bandage in bandages)
            {
                    if (x == bandage.X && y == bandage.Y)
                    {
                        return true;
                    }
                }
            return false;
        }
    }
}
