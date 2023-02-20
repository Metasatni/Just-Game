using Just_Game_Remaster.Models;

namespace Just_Game_Remaster.Engine;

internal static class CollisionDetector
{


    public static bool IsOnObject(this GameObject root, GameObjects gameObjects, out GameObject gameObject)
    {
        return IsOnObject(root, gameObjects.Get(), out gameObject);
    }

    private static bool IsOnObject(GameObject root, IReadOnlyList<GameObject> gameObjects, out GameObject gameObjectResult)
    {
        gameObjectResult = null;
        foreach (var gameObject in gameObjects) {
            if (gameObject == root) continue;
            if (root.X == gameObject.X && root.Y == gameObject.Y) {
                gameObjectResult = gameObject;
                return true;
            }
        }
        return false;
    }

    public static bool WillBeOnObject(this GameObject root, IReadOnlyList<GameObject> gameObjects, Direction direction, out GameObject gameObjectResult) {

        int oldX = root.X;
        int oldY = root.Y;
        int newX = oldX;
        int newY = oldY;
        
        switch (direction)
        {
            case Direction.Down: newY++; break;
            case Direction.Up: newY--; break;
            case Direction.Left: newX--; break;
            case Direction.Right: newX++; break;
        }

        root.X = newX;
        root.Y = newY;

        var isOnObject = IsOnObject(root, gameObjects, out gameObjectResult);

        root.X = oldX;
        root.Y = oldY;

        return isOnObject;

    }


}
