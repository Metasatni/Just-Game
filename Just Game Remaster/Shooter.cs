﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster
{

    internal abstract class Shooter : GameObject
    {

        private GameTimer _cooldownTimer;

        protected abstract int _shootingCooldownInMs { get; }

        public Shooter() {
            _cooldownTimer = GameTimer.CreateByMs(_shootingCooldownInMs);
            _cooldownTimer.Start();
        }

        protected bool CanShoot() => _cooldownTimer.TickReady();

        public abstract bool TryShoot(Direction direction, out Projectile projectile);


    }
}