using System;

namespace Source.Scripts.Gameplay.Common.Time
{
  public class UnityTimeService : ITimeService
  {
    private bool _isPaused;
    
    public float DeltaTime => !_isPaused ? UnityEngine.Time.deltaTime : 0f;
    
    public DateTime UtcNow => DateTime.UtcNow;

    public void StopTime() => _isPaused = true;
    public void StartTime() => _isPaused = false;
  }
}