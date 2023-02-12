using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

internal class GameTimer {

  private const int MS_IN_SECOND = 1000;
  private readonly int _delayInMs;
  private long _lastTick;

  private GameTimer(int delayInMs) {
    _delayInMs = delayInMs;
  }

  public static GameTimer CreateByTickRate(int tickRate) {
    int delayInMs = MS_IN_SECOND / tickRate;
    return new GameTimer(delayInMs);
  }

  public static GameTimer CreateByMs(int delayInMs) {
    return new GameTimer(delayInMs);
  }

  public void Start() {
    ResetDeltaTime();
  }

  public bool TickReady() {
    long timePassed = GetCurrentMiliseconds() - _lastTick;
    bool isTickReady = timePassed > _delayInMs;
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
