using Source.Scripts.Gameplay.Features.Income.Systems;
using Source.Scripts.Infrastructure.Systems;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Income
{
  [Preserve]
  public sealed class IncomeFeature : Feature
  {
    public IncomeFeature(ISystemFactory systems)
    {
      Add(systems.Create<AutoIncomeInitializeSystem>());
      
      Add(systems.Create<AutoIncomeEmitSystem>());
      Add(systems.Create<PlayerIncomeEmitSystem>());
      
      Add(systems.Create<GoldIncomeReceiveSystem>());
    }
  }
}