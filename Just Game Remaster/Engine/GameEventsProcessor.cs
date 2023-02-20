using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Just_Game_Remaster.Events;
using Just_Game_Remaster.Models;

namespace Just_Game_Remaster.Engine;

internal class GameEventsProcessor {

    private readonly GameObjects _gameObjects;
    private readonly GameObjectFactory _gameObjectFactory;

    public GameEventsProcessor(GameObjects gameObjects) {

        _gameObjects = gameObjects;
        _gameObjectFactory = new GameObjectFactory();

    }

    public void HandleEvents(IEnumerable<IGameEvent> events) {

        if (events.IsNullOrEmpty()) return;

        foreach (IGameEvent gameEvent in events) HandleEvent(gameEvent);

    }

    public void HandleEvent(IGameEvent gameEvent) {

        switch (gameEvent) {
          case GameObjectShotEvent gameObjectShotEvent: HandleEvent(gameObjectShotEvent); return;
          case ItemPickUpEvent itemPickUpEvent: HandleEvent(itemPickUpEvent); break;
        }

    }

    private void HandleEvent(ItemPickUpEvent gameEvent) {
        if (gameEvent.Item.IsDead) return;
        if (gameEvent.GameObject is Projectile) return;
        gameEvent.Item.OnPickUp(gameEvent.GameObject);
        gameEvent.Item.IsDead = true;
        _gameObjects.Add(_gameObjectFactory.Create(gameEvent.Item.Type));
        switch (gameEvent.GameObject) {
            case Player player:
                break;
            case Enemy enemy:
                enemy.IsDead = true;
                _gameObjects.Add(_gameObjectFactory.Create(enemy.Type));
                break;
        }

    }

    private void HandleEvent(GameObjectShotEvent gameEvent) {
        if (gameEvent.Target.Type == gameEvent.Projectile.Shooter) return;
        switch (gameEvent.Target) {
            case Player player:
                player.Hp -= gameEvent.Projectile.Damage;
                break;
            case Enemy enemy:
                enemy.IsDead = true;
                _gameObjects.Add(_gameObjectFactory.Create(enemy.Type));
                break;
        }
    }

}