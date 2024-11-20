using Entitas;
using Source.Scripts.Common.Entity;
using Source.Scripts.Common.Extensions;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Income.Systems
{
  [Preserve]
  public class AutoIncomeInitializeSystem : IInitializeSystem
  {
    public void Initialize()
    {
      CreateGameEntity.Empty()
        .AddPeriod(1)
        .AddTimeSinceLastTick(1)
        .With(x => x.isAutoIncomeEmitter = true);
    }
  }
}