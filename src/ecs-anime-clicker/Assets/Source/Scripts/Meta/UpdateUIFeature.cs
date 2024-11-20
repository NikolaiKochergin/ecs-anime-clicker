using Source.Scripts.Infrastructure.Systems;
using Source.Scripts.Meta.UI.WalletHolder.Systems;
using UnityEngine.Scripting;

namespace Source.Scripts.Meta
{
  [Preserve]
  public sealed class UpdateUIFeature : Feature
  {
    public UpdateUIFeature(ISystemFactory systems)
    {
      Add(systems.Create<RefreshGoldSystem>());
    }
  }
}