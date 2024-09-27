using RSG;

namespace Source.Scripts.Infrastructure.States.StateInfrastructure
{
  public class SimplePayloadState<TPayload> : IPayloadState<TPayload>
  {
    public void Enter(TPayload payload) { }
    
    protected virtual void Exit() { }

    IPromise IExitableState.BeginExit()
    {
      Exit();
      return Promise.Resolved();
    }

    void IExitableState.EndExit() { }
  }
}