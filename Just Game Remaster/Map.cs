using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster
{
    internal class Map
    {
        public const int WIDTH = 80;
        public const int HEIGHT = 20;
        public bool[][] MapStructure { get; private set; }
        
        public Map()
        {
            GenerateMap();
        }

        private void GenerateMap()
        {

            this.MapStructure = new bool[WIDTH][];

            for (int row = 0; row < HEIGHT; row++)
            {
                this.MapStructure[row] = new bool[WIDTH];
                for (int col = 0; col < WIDTH; col++)
                {

                }
            }
                    //if (i == 0) MapStructure[i, j] = true;
                    //if (i == Height - 1) MapStructure[i, j] = true;
                    //if ((i != 0 && i != Height - 1) && (j == 0 || j == Width - 1)) MapStructure[i, j] = true;
        }
    }
}
