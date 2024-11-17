using Source.Scripts.Gameplay.Features.Room.Systems;
using Source.Scripts.Infrastructure.Systems;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Room
{
  [Preserve]
  public sealed class RoomFeature : Feature
  {
    public RoomFeature(ISystemFactory systems)
    {
      Add(systems.Create<SwapRoomsWhenNewRoomViewSpawnedSystem>());
      
      Add(systems.Create<ReleaseDestructedRoomAssetReferenceSystem>());
    }
  }
}