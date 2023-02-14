using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster.Drawing;

internal interface IPrinter
{
    public void DrawGameOverFrame();
    public void PrintFrame(GameObjects gameObjects);
}
