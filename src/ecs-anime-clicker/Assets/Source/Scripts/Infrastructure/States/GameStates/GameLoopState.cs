using Source.Scripts.Gameplay.Input;
using Source.Scripts.Infrastructure.States.StateInfrastructure;
using Source.Scripts.Infrastructure.Systems;
using Source.Scripts.Progress.SaveLoad;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States.GameStates
{
  public class GameLoopState : EndOfFrameExitState
  {
    private readonly ISystemFactory _systems;
    private readonly ISaveLoadService _saveLoad;
    private InputFeature _inputFeature;

    public GameLoopState(
      ISystemFactory systems,
      ISaveLoadService saveLoad)
    {
      _systems = systems;
      _saveLoad = saveLoad;
    }
    
    public override void Enter()
    {
      _saveLoad.LoadGameProgress();
      
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