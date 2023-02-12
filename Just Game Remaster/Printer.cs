using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal class Printer {

    public void PrintFrame(IEnumerable<GameObject> gameObjects)
    {

        var player = gameObjects.FirstOrDefault();

        var frame = BuildBaseFrame();

        frame[player.Y][player.X] = player.Character;

        var frameAsText = ParseFrameToConsoleSize(frame);

        FastPrint(frameAsText);

    }

    private void AddPaddings(ref string frameAsText) {
      if (Map.HEIGHT >= Console.WindowHeight) return;
      int diff_y = Console.WindowHeight - Map.HEIGHT;
      int padding_bottom = diff_y / 2;
      int padding_top = diff_y - padding_bottom;
      frameAsText = frameAsText.Insert(0, new string('\n', padding_top) + '\n');
      frameAsText += new string('\n', padding_bottom) + '\n';
    }

    private string ParseFrameToConsoleSize(char[][] frame) {
      var rows = frame.Select(row => new string(row));
      string text = string.Join('\n', rows);
      return text;
    }

    private void FastPrint(string text) {
      using var stdout = Console.OpenStandardOutput(Console.WindowHeight * Console.WindowWidth);
      var buffer = Encoding.UTF8.GetBytes(text);
      stdout.Write(buffer, 0, buffer.Length);
    }

    private char[][] BuildBaseFrame() {

      char[][] map = new char[Map.HEIGHT][];

        map[0] = ("+" + new string('-', Map.WIDTH - 2) + "+").ToCharArray();
        map[Map.HEIGHT - 1] = ("+" + new string('-', Map.WIDTH - 2) + "+").ToCharArray();

      for (int i = 1; i < map.Length - 1; i++) {
          map[i] = ("|" + new string(' ', Map.WIDTH - 2) + "|").ToCharArray();
      }

      return map;

    }

}
