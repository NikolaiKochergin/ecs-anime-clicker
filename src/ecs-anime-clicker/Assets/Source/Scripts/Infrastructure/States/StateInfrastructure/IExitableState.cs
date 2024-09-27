using RSG;

namespace Source.Scripts.Infrastructure.States.StateInfrastructure
{
  public interface IExitableState
  {
    IPromise BeginExit();
    void EndExit();
  }
}