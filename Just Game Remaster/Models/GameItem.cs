using Just_Game_Remaster.Engine;

namespace Just_Game_Remaster.Models;

internal abstract class GameItem : GameObject
{
    public override void Tick() {
        TryPickUp();
        base.Tick();
    }

    protected bool TryPickUp()
    {
        bool isOnObject = this.IsOnObject(_gameObjects, out var gameObject);
        if (isOnObject) gameObject.OnItemPickUp(this);
        return isOnObject;
    }

}
