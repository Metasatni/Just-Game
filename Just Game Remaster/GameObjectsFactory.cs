using Just_Game_Remaster.Models;

namespace Just_Game_Remaster;

internal class GameObjectsFactory {

      private readonly Random _random = new Random();

    private readonly GameObjects _gameObjects;

    public GameObjectsFactory(GameObjects gameObjects) {

        _gameObjects = gameObjects;

    }

      public GameObject Create(GameObjectType gameObjectType)
      {

          GameObject gameObject = gameObjectType switch
          {
              GameObjectType.Player => new Player(),
              GameObjectType.Enemy => new Enemy(0, 0),
              GameObjectType.Bandage => new Bandage(0, 0),
              GameObjectType.Mine => new Mine(0, 0),
              _ => null
          };

          if (gameObject is not null) RandomizePosition(gameObject);

          return gameObject;
          
      }

      private void RandomizePosition(GameObject gameObject) {
        gameObject.X = _random.Next(1, Map.WIDTH - 1);
        gameObject.Y = _random.Next(1, Map.HEIGHT - 1);
      }

}
