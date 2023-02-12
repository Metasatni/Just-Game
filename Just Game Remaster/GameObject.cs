﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal abstract class GameObject {

    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public abstract char Character { get; }
   
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

    public virtual void Tick() {
      
    }

}
