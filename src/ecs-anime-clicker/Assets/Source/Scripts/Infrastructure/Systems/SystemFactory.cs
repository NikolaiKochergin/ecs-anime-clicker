using Entitas;
using Reflex.Core;

namespace Source.Scripts.Infrastructure.Systems
{
  public class SystemFactory : ISystemFactory
  {
    private readonly Container _container;

    public SystemFactory(Container container) => 
      _container = container;
    
    public T Create<T>() where T : ISystem =>
      _container.Construct<T>();
  }
}