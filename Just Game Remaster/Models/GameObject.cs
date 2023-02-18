﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Just_Game_Remaster.Engine;
using Just_Game_Remaster.Events;

namespace Just_Game_Remaster.Models;
internal abstract class GameObject
{

    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public abstract char Character { get; }
    public abstract GameObjectType Type { get; }
    public bool IsDead { get; set; }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Down:
                Y++;
                break;
            case Direction.Up:
                Y--;
                break;
            case Direction.Left:
                X--;
                break;
            case Direction.Right:
                X++;
                break;
        }
    }

    public bool TryMove(Direction direction)
    {
        var canMove = BorderChecker.WillBeInBounds(this, direction);
        if (canMove) Move(direction);
        return canMove;
    }

    public virtual List<IGameEvent> Tick(GameObjects gameObjects) {
        return new List<IGameEvent>();
    }

}
