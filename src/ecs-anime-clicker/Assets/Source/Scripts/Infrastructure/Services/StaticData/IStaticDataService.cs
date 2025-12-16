using Source.Scripts.Gameplay.Features.Characters.Configs;
using Source.Scripts.Gameplay.Features.Purchases.Configs;
using Source.Scripts.Gameplay.Features.Room.Configs;

namespace Source.Scripts.Infrastructure.Services.StaticData
{
  public interface IStaticDataService
  {
    RoomData ForRoom(string nameId);
    CharacterData ForCharacter(string nameId);
    PurchaseData ForPurchase(string nameId);
  }
}