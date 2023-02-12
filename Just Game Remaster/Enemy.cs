using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Just_Game_Remaster
{

    internal class Enemy : GameObject
    {

        public override char Character => 'O';
        
        public Enemy(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
