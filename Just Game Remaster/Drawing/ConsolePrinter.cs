using Just_Game_Remaster.Models;

namespace Just_Game_Remaster.Drawing;

internal class ConsolePrinter : IPrinter
{

    private int _hp;
    private IReadOnlyList<GameObject> _gameObjects;

    public void PrintFrame(GameObjects gameObjects)
    {

        SetDrawingData(gameObjects);

        RedrawEmptyMap();

        foreach (var gameObject in _gameObjects)
        {
            WriteGameObject(gameObject);
        }

    }
    public void DrawGameOverFrame()
    {
        int width = Map.WIDTH;
        int height = Map.HEIGHT;
        CreateTheEndBorder(width, height);
    }

    private void WriteGameObject(GameObject gameObject)
    {
        switch (gameObject)
        {
            case Enemy:
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case Player:
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case Bandage:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case Mine:
                Console.ForegroundColor = ConsoleColor.Black;
                break;
        }
        Console.SetCursorPosition(gameObject.X, gameObject.Y);
        Console.Write(gameObject.Character);
    }

    private void SetDrawingData(GameObjects gameObjects)
    {

        _hp = gameObjects.Player.Hp;
        _gameObjects = gameObjects.GetAlive();

    }

    private void RedrawEmptyMap()
    {

        int width = Map.WIDTH;
        int height = Map.HEIGHT;

        string[] map = new string[height + 1];

        map[0] = CreateHorizontalBorder(width);

        for (int i = 1; i < map.Length - 1; i++)
        {
            map[i] = CreateVerticalBorder(width);
        }

        map[height - 1] = CreateHorizontalBorder(width);

        map[height] = CreateHpRow();

        for (int i = 0; i < map.Length; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write(map[i]);
        }

    }

    private string CreateVerticalBorder(int width)
    {
        return $"|{RepeatChar(' ', width - 2)}|";
    }

    private void CreateTheEndBorder(int width, int height)
    {
        string endLabel = "THE END";
        string endText = "PRESS ANY BUTTON TO PLAY AGAIN";
        Console.SetCursorPosition(width / 2 - endLabel.Length / 2, height / 2);
        Console.Write(endLabel);
        Console.SetCursorPosition(width / 2 - endText.Length / 2, height / 2 + 1);
        Console.Write(endText);
    }

    private string CreateHorizontalBorder(int width)
    {
        return $"+{RepeatChar('-', width - 2)}+";
    }

    private string CreateHpRow()
    {
        const int MAX_HP_DECIMAL = 3;
        string hpLabel = "Hp: ";
        int totalWidth = hpLabel.Length + MAX_HP_DECIMAL;
        string hpRow = (hpLabel + _hp.ToString()).PadRight(totalWidth);
        return hpRow;
    }

    private string RepeatChar(char character, int count)
    {
        return new string(character, count);
    }

}
