using Source.Scripts.Common.Entity;
using Source.Scripts.Common.Extensions;
using Source.Scripts.Infrastructure.Identifiers;
using Source.Scripts.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Room.Factory
{
  public class RoomFactory : IRoomFactory 
  {
    private readonly IIdentifierService _identifiers;
    private readonly IStaticDataService _staticData;
    
    private Transform _roomsRoot;

    public RoomFactory(IIdentifierService identifiers, IStaticDataService staticData)
    {
      _identifiers = identifiers;
      _staticData = staticData;
    }
    
    public void SetRoomsRoot(Transform roomsRoot) => _roomsRoot = roomsRoot;

    public GameEntity CreateRoom(string nameId) =>
      CreateGameEntity.Empty()
        .AddId(_identifiers.Next())
        .AddNameId(nameId)
        .AddParent(_roomsRoot)
        .AddViewAssetReference(_staticData.ForRoom(nameId).RoomReference)
        .With(x => x.isRoom = true);
  }
}