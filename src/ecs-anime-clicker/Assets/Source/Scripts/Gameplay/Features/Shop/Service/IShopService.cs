namespace Source.Scripts.Gameplay.Features.Shop.Service
{
  public interface IShopService
  {
    int GetPrice(string purchaseId);
    void TryBuy(string purchaseId);
  }
}