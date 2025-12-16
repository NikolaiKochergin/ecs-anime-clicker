using Source.Scripts.Gameplay.Features.Characters.Configs;
using Source.Scripts.Gameplay.Features.Room.Configs;
using Source.Scripts.Gameplay.Features.Shop.Configs;

namespace Source.Scripts.Infrastructure.Services.StaticData
{
  public interface IStaticDataService
  {
    RoomData ForRoom(string nameId);
    CharacterData ForCharacter(string nameId);
    PurchaseData ForPurchase(string nameId);
  }
}