using RSG;

namespace Source.Scripts.Infrastructure.States.StateInfrastructure
{
  public class EndOfFrameExitState : IState, IUpdateable
  {
    private Promise _exitPromise;

    private bool ExitWasRequested => _exitPromise != null;

    public void Enter() { }

    IPromise IExitableState.BeginExit()
    {
      _exitPromise = new Promise();
      return _exitPromise;
    }

    void IExitableState.EndExit()
    {
      ExitOnEndOfFrame();
      ClearExitPromise();
    }

    public void Update()
    {
      if (!ExitWasRequested)
        OnUpdate();

      if (ExitWasRequested)
        ResolveExitPromise();
    }
    
    protected virtual void ExitOnEndOfFrame() { }
    
    protected virtual void OnUpdate() { }
    
    private void ClearExitPromise() => 
      _exitPromise = null;
    
    private void ResolveExitPromise() =>
      _exitPromise?.Resolve();
  }
}