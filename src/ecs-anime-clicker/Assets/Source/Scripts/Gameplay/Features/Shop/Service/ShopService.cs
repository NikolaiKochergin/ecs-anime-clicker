using Source.Scripts.Gameplay.Features.Characters.Service;
using Source.Scripts.Gameplay.Features.Room.Service;
using Source.Scripts.Infrastructure.Services.StaticData;
using Source.Scripts.Progress.SaveLoad;

namespace Source.Scripts.Gameplay.Features.Shop.Service
{
  public class ShopService : IShopService
  {
    private readonly IStaticDataService _staticData;
    private readonly IRoomService _roomService;
    private readonly ICharacterService _characterService;
    private readonly ISaveLoadService _saveLoad;

    public ShopService(
      IStaticDataService staticData, 
      IRoomService roomService,
      ICharacterService characterService,
      ISaveLoadService saveLoad)
    {
      _saveLoad = saveLoad;
      _characterService = characterService;
      _staticData = staticData;
      _roomService = roomService;
    }

    public int GetPrice(string purchaseId) => _staticData.ForPurchase(purchaseId).Price;
    
    public void ApplyPurchaseReward(string purchaseId)
    {
      switch (purchaseId)
      {
        case "buy-character":
          _characterService.SetNextCharacter();
          break;
        case "buy-room":
          _roomService.SetNextRoom();
          break;
      }
      
      _saveLoad.SaveProgress();
    }
  }
}