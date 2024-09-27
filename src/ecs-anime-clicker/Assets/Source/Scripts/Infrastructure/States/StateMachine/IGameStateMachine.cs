using Source.Scripts.Infrastructure.States.StateInfrastructure;

namespace Source.Scripts.Infrastructure.States.StateMachine
{
  public interface IGameStateMachine
  {
    void Enter<TState>() where TState : class, IState;
    void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
  }
}