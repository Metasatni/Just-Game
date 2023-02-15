using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster.Models
{
    internal class Bandage : GameObject
    {
        private Random random = new Random();
        public override char Character => '%';
        public override GameObjectType Type => GameObjectType.Bandage;

        public int HealValue = 20;
        public Bandage(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override void Tick(GameObjects gameObjects)
        {

        }
    }
}
