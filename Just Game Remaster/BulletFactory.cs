using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal class BulletFactory {
    private const int COOLDOWN_IN_MS = 200;
    private readonly GameTimer _cooldownTimer = GameTimer.CreateByMs(COOLDOWN_IN_MS);

    public BulletFactory() {
        _cooldownTimer.Start();
    }

    public Bullet TryCreateBullet(GameObject gameObject, Direction direction)
    {

        if (_cooldownTimer.TickReady())
        {
            return new Bullet(gameObject.X, gameObject.Y, direction, gameObject.Type);
        }

        return null;
    }
}
