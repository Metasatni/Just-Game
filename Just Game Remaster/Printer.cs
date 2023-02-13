using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal class Printer {

    public void PrintFrame(IEnumerable<GameObject> gameObjects)
    {

        ClearMap();

        foreach(var gameObject in gameObjects) {
            WriteGameObject(gameObject);
        }

    }

    private void WriteGameObject(GameObject gameObject) {
        Console.SetCursorPosition(gameObject.X, gameObject.Y);
        Console.Write(gameObject.Character);
    }

    private void ClearMap() {

      string[] map = new string[Map.HEIGHT];

        map[0] = ("+" + new string('-', Map.WIDTH - 2) + "+");
        map[Map.HEIGHT - 1] = ("+" + new string('-', Map.WIDTH - 2) + "+");

      for (int i = 1; i < map.Length - 1; i++) {
          map[i] = ("|" + new string(' ', Map.WIDTH - 2) + "|"); 
      }

      for(int i = 0; i < Map.HEIGHT; i++) {
          Console.SetCursorPosition(0, i);
          Console.Write(map[i]);
      }

    }

}
