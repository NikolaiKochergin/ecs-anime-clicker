using Source.Scripts.Gameplay.Input;
using Source.Scripts.Infrastructure.States.StateInfrastructure;
using Source.Scripts.Infrastructure.Systems;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States.GameStates
{
  public class LoadProgressState : EndOfFrameExitState
  {
    private readonly ISystemFactory _systems;
    private InputFeature _inputFeature;

    public LoadProgressState(ISystemFactory systems)
    {
      _systems = systems;
    }
    
    public override void Enter()
    {
      _inputFeature = _systems.Create<InputFeature>();
      _inputFeature.Initialize();
    }

    protected override void OnUpdate()
    {
      _inputFeature.Execute();
      _inputFeature.Cleanup();
    }
  }
}