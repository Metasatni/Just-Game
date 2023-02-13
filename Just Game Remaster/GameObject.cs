using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

public enum OnShotAction {
  None,
  RemoveFromGame,
  Respawn,
  DealDamage
}

public enum GameObjectType {
  Player,
  Enemy,
  Bullet,
  Projectile,
}

internal abstract class GameObject {

    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public abstract char Character { get; }
    public abstract GameObjectType Type { get; }
   
    public void Move(Direction direction) {
        switch (direction)
        {
            case Direction.Down:
                this.Y++;
                break;
            case Direction.Up:
                this.Y--;
                break;
            case Direction.Left:
                this.X--;
                break;
            case Direction.Right:
                this.X++;
                break;
        }
    }

    public bool TryMove(Direction direction) {
        var canMove = BorderChecker.WillBeInBounds(this, direction);
        if (canMove) Move(direction);
        return canMove;
    }

    public virtual void Tick(GameObjects gameObjects) {
      
    }

    public virtual OnShotAction OnShot(Projectile projectile) {
        return OnShotAction.None;
    }

}
