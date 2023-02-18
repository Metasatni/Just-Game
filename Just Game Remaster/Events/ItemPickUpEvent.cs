using Just_Game_Remaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster.Events;

internal class ItemPickUpEvent : IGameEvent
{
    public GameObject GameObject { get; }
    public GameItem Item { get; }

    public ItemPickUpEvent(GameObject gameObject, GameItem item)
    {
        this.GameObject = gameObject;
        this.Item = item;
    }

}
