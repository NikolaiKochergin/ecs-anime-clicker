using Source.Scripts.Infrastructure.Systems;
using Source.Scripts.Infrastructure.View.Systems;
using UnityEngine.Scripting;

namespace Source.Scripts.Infrastructure.View
{
  [Preserve]
  public sealed class BindViewFeature : Feature
  {
    public BindViewFeature(ISystemFactory systems)
    {
      Add(systems.Create<BindEntityViewFromPrefabSystem>());
      Add(systems.Create<BindEntityViewFromAssetReferenceSystem>());
    }
  }
}