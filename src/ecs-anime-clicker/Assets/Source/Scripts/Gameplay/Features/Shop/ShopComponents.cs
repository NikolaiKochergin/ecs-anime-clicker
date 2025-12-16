using Entitas;

namespace Source.Scripts.Gameplay.Features.Shop
{
  public class ShopComponents
  {
    [Game] public class ShopItemIdComponent : IComponent { public string Value; }
    [Game] public class BuyRequestComponent : IComponent { }
    [Game] public class PurchasedComponent : IComponent { }
  }
}