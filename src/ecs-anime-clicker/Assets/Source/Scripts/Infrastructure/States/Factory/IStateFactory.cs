using Source.Scripts.Infrastructure.States.StateInfrastructure;

namespace Source.Scripts.Infrastructure.States.Factory
{
  public interface IStateFactory
  {
    TState GetState<TState>() where TState : class, IExitableState;
  }
}