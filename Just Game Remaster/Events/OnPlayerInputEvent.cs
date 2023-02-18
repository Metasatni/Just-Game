using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster.Events
{
    internal class OnPlayerInputEvent : IGameEvent {

        internal ConsoleKey Key { get; }

        public OnPlayerInputEvent(ConsoleKey key)
        {
            this.Key = key;
        }

    }
}
