using Source.Scripts.Gameplay.Features.Shop.Systems;
using Source.Scripts.Infrastructure.Systems;

namespace Source.Scripts.Gameplay.Features.Shop
{
  public sealed class ShopFeature : Feature
  {
    public ShopFeature(ISystemFactory systems)
    {
      Add(systems.Create<BuyItemOnRequestSystem>());
    }
  }
}