using Source.Scripts.Common.Destruct.Systems;
using Source.Scripts.Infrastructure.Systems;

namespace Source.Scripts.Common.Destruct
{
  public class ProcessDestructedFeature : Feature
  {
    public ProcessDestructedFeature(ISystemFactory systems)
    {
      Add(systems.Create<SelfDestructTimerSystem>());

      Add(systems.Create<CleanupInputDestructedSystem>());
      Add(systems.Create<CleanupMetaDestructedSystem>());
      
      Add(systems.Create<CleanupGameDestructedViewSystem>());
      Add(systems.Create<CleanupGameDestructedSystem>());
    }
  }
}