using Source.Scripts.Infrastructure.States.StateInfrastructure;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States.GameStates
{
  public class GameLoopState : EndOfFrameExitState
  {
    protected override void OnUpdate()
    {
      Debug.Log("Game Loop State Updated");
    }
  }
}