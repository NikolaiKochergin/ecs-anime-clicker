using Source.Scripts.Gameplay;
using Source.Scripts.Gameplay.Features.Room.Factory;
using Source.Scripts.Infrastructure.States.StateInfrastructure;
using Source.Scripts.Infrastructure.Systems;
using Source.Scripts.Progress.SaveLoad;

namespace Source.Scripts.Infrastructure.States.GameStates
{
  public sealed class GameLoopState : EndOfFrameExitState
  {
    private readonly ISystemFactory _systems;
    private readonly ISaveLoadService _saveLoad;
    private readonly GameContext _game;

    private GameplayFeature _gameplayFeature;

    public GameLoopState(
      ISystemFactory systems,
      ISaveLoadService saveLoad,
      GameContext game)
    {
      _systems = systems;
      _saveLoad = saveLoad;
      _game = game;
    }
    
    public override void Enter()
    {
      _gameplayFeature = _systems.Create<GameplayFeature>();
      _gameplayFeature.Initialize();
      
      _saveLoad.LoadGameProgress();
    }
    
    protected override void OnUpdate()
    {
      _gameplayFeature.Execute();
      _gameplayFeature.Cleanup();
    }

    protected override void ExitOnEndOfFrame()
    {
      _gameplayFeature.DeactivateReactiveSystems();
      _gameplayFeature.ClearReactiveSystems();
    
      DestructEntities();
      
      _gameplayFeature.Cleanup();
      _gameplayFeature.TearDown();
      _gameplayFeature = null;
    }

    private void DestructEntities()
    {
      foreach (GameEntity entity in _game.GetEntities())
        entity.isDestructed = true;
    }
  }
}