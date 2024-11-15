using Source.Scripts.Gameplay.Features.Room.Configs;

namespace Source.Scripts.Infrastructure.Services.StaticData
{
  public interface IStaticDataService
  {
    RoomData ForRoom(string nameId);
  }
}