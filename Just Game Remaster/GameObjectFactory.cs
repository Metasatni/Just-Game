﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

  internal class GameObjectFactory {

      private readonly Random _random = new Random();

      public GameObject Create(GameObjectType gameObjectType)
      {

          GameObject? gameObject = gameObjectType switch
          {
              GameObjectType.Player => new Player(),
              GameObjectType.Enemy => new Enemy(0, 0),
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