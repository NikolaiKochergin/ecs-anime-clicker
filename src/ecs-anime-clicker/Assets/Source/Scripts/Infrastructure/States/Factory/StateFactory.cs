using Reflex.Core;
using Source.Scripts.Infrastructure.States.StateInfrastructure;

namespace Source.Scripts.Infrastructure.States.Factory
{
  public class StateFactory : IStateFactory
  {
    private readonly Container _container;

    public StateFactory(Container container) => 
      _container = container;

    public TState GetState<TState>() where TState : class, IExitableState => 
      _container.Resolve<TState>();
  }
}