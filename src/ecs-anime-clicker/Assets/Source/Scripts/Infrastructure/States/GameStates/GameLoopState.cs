using Source.Scripts.Gameplay.Input;
using Source.Scripts.Infrastructure.States.StateInfrastructure;
using Source.Scripts.Infrastructure.Systems;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States.GameStates
{
  public class GameLoopState : EndOfFrameExitState
  {
    private readonly ISystemFactory _systems;
    private InputFeature _inputFeature;

    public GameLoopState(ISystemFactory systems)
    {
      _systems = systems;
    }
    
    public override void Enter()
    {
      _inputFeature = _systems.Create<InputFeature>();
      _inputFeature.Initialize();
      
      Debug.Log("Load Progress State");
    }
    
    protected override void OnUpdate()
    {
      Debug.Log("Game Loop State Updated");
    }
  }
}