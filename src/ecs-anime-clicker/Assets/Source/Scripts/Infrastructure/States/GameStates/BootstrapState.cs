using Source.Scripts.Infrastructure.States.StateInfrastructure;
using Source.Scripts.Infrastructure.States.StateMachine;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;

    public BootstrapState(IGameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }
    
    public override void Enter()
    {
      Debug.Log("Bootstrap state entered");
      _stateMachine.Enter<LoadProgressState>();
    }
  }
}