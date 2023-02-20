using Just_Game_Remaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster; 

internal class GameObjectsSpawner {

    private readonly GameObjectsFactory _gameObjectsFactory;
    private readonly GameObjects _gameObjects;

    public GameObjectsSpawner(GameObjectsFactory gameObjectFactory, GameObjects gameObjects) {
        _gameObjectsFactory = gameObjectFactory;
        _gameObjects = gameObjects;
    }

    public void SpawnPlayer() {
        if (!_gameObjects.Get<Player>().IsNullOrEmpty()) return;
        Spawn(GameObjectType.Player);
    }

    public void SpawnEnemy() => Spawn(GameObjectType.Enemy);

    public void SpawnMine() => Spawn(GameObjectType.Mine);
    
    public void SpawnBandage() => Spawn(GameObjectType.Bandage);

    public void SpawnBullet(GameObject gameObject, Direction direction)
    {
        var bullet = new Bullet(gameObject, direction);
        _gameObjects.Add(bullet);
    }

    private void Spawn(GameObjectType gameObjectType) {
        var gameObject = _gameObjectsFactory.Create(gameObjectType);
        _gameObjects.Add(gameObject);
    }



}
