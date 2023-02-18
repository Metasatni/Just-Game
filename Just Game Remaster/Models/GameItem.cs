using Just_Game_Remaster.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster.Models;

internal abstract class GameItem : GameObject
{
    
  public virtual void OnPickUp(GameObject gameObject) {

  }

}
