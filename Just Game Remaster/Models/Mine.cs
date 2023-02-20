using Just_Game_Remaster.Engine;
using Just_Game_Remaster.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster.Models
{
    internal class Mine : GameItem
    {

        private GameObjects _gameObjects => ServiceProvider.GetService<GameObjects>();

        private const int DAMAGE_VALUE = 20;
        public override char Character => '@';
        public override GameObjectType Type => GameObjectType.Mine;

        public Mine(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override List<IGameEvent> Tick(GameObjects gameObjects)
        {
            var gameEvents = new List<IGameEvent>();
            TryAddItemPickedUpEvent(gameEvents, gameObjects);
            return gameEvents;
        }

        private void TryAddItemPickedUpEvent(List<IGameEvent> gameEvents, GameObjects gameObjects)
        {
            if (!this.IsOnObject(gameObjects, out var gameObject)) return;
            gameEvents.Add(new ItemPickUpEvent(gameObject, this));
        }

        public override void OnPickUp(GameObject gameObject)
        {
            if (gameObject is Player player) player.Hp -= DAMAGE_VALUE;
            _gameObjects.Add(gameObject);
           
        }
    }
}
