namespace Just_Game_Remaster;

public enum Direction
{
    Down,
    Up,
    Left,
    Right,
}

public enum GameObjectType
{
    Player,
    Enemy,
    Bullet,
    Projectile,
    Bandage,
    Mine,
}

public static class Enums {

    public static Direction GetDirectionByConsoleKey(ConsoleKey consoleKey) {
        return consoleKey switch
        {
            ConsoleKey.A or ConsoleKey.LeftArrow => Direction.Left,
            ConsoleKey.D or ConsoleKey.RightArrow => Direction.Right,
            ConsoleKey.W or ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.S or ConsoleKey.DownArrow => Direction.Down,
            _ => throw new ArgumentException()
        };
    }

}
