using Just_Game_Remaster.Models;

namespace Just_Game_Remaster.Events;

internal class GameObjectShotEvent : IGameEvent {

    public GameObject Target { get; }
    public Projectile Projectile { get; }

    public GameObjectShotEvent(Projectile projectile, GameObject target)
    {
        this.Projectile = projectile;
        this.Target = target;
    }

}
