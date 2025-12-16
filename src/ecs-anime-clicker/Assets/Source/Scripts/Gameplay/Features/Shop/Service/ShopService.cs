using Source.Scripts.Infrastructure.Services.StaticData;

namespace Source.Scripts.Gameplay.Features.Shop.Service
{
  public class ShopService : IShopService 
  {
    private readonly IStaticDataService _staticData;

    public ShopService(IStaticDataService staticData) =>
      _staticData = staticData;

    public int GetPrice(string purchaseId) => _staticData.ForPurchase(purchaseId).Price;
    
    public void TryBuy(string purchaseId)
    {
      
    }
  }
}