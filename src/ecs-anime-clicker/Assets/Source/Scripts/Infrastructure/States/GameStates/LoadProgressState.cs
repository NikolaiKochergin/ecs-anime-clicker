using Source.Scripts.Common.Entity;
using Source.Scripts.Common.Extensions;
using Source.Scripts.Infrastructure.States.StateInfrastructure;
using Source.Scripts.Infrastructure.States.StateMachine;
using Source.Scripts.Progress.SaveLoad;

namespace Source.Scripts.Infrastructure.States.GameStates
{
  public class LoadProgressState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISaveLoadService _saveLoad;

    public LoadProgressState(
      IGameStateMachine stateMachine,
      ISaveLoadService saveLoad)
    {
      _stateMachine = stateMachine;
      _saveLoad = saveLoad;
    }
    
    public override void Enter()
    {
      InitializeProgress();
      
      _stateMachine.Enter<GameLoopState>();
    }

    private void InitializeProgress()
    {
      if (_saveLoad.HasSavedProgress)
        _saveLoad.LoadMetaProgress();
      else
        CreateNewProgress();
    }

    private void CreateNewProgress()
    {
      _saveLoad.CreateProgress();

      CreateMetaEntity.Empty()
        .With(x => x.isWallet = true)
        .AddGold(10);
    }
  }
}