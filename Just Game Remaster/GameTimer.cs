using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal class GameTimer {

  private const int TICK_RATE = 32;
  private const int MS_IN_SECOND = 1000;
  private const int TICK_IN_MS = MS_IN_SECOND / TICK_RATE;

  private long _lastTick;

  public GameTimer() {

  }

  public void Start() {
    ResetDeltaTime();
  }

  public bool TickReady() {
    long timePassed = GetCurrentMiliseconds() - _lastTick;
    bool isTickReady = timePassed > TICK_IN_MS;
    if (isTickReady) ResetDeltaTime();
    return isTickReady;
  }

  private void ResetDeltaTime() {
    _lastTick = GetCurrentMiliseconds();
  }

  private long GetCurrentMiliseconds() {
    long currentMs = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    return currentMs;
  }

}
