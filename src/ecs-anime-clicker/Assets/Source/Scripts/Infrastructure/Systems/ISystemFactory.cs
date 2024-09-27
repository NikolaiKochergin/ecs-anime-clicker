using Entitas;

namespace Source.Scripts.Infrastructure.Systems
{
  public interface ISystemFactory
  {
    T Create<T>() where T : ISystem;
  }
}