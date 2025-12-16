using Entitas;
using Source.Scripts.Common.Entity;
using Source.Scripts.Gameplay.Features.Shop.Service;

namespace Source.Scripts.Gameplay.Features.Shop.Systems
{
  public sealed class BuyItemOnRequestSystem : IExecuteSystem
  {
    private readonly IShopService _shop;
    private readonly IGroup<GameEntity> _wallets;
    private readonly IGroup<GameEntity> _shopItemPurchaseRequests;

    public BuyItemOnRequestSystem(GameContext game, IShopService shop)
    {
      _shop = shop;
      _wallets = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Wallet,
          GameMatcher.Gold));

      _shopItemPurchaseRequests = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.BuyRequest,
          GameMatcher.ShopItemId));
    }
    
    public void Execute()
    {
      foreach(GameEntity wallet in _wallets)
      foreach (GameEntity request in _shopItemPurchaseRequests)
      {
        int price = _shop.GetPrice(request.ShopItemId);

        if (wallet.Gold >= price)
        {
          wallet.ReplaceGold(wallet.Gold - price);

          CreateGameEntity.Empty()
            .AddShopItemId(request.ShopItemId)
            .isPurchased = true;

          _shop.ApplyPurchaseReward(request.ShopItemId);
        }

        request.isDestructed = true;
      }
    }
  }
}