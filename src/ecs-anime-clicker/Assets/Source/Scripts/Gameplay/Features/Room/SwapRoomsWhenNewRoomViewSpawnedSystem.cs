using System.Collections.Generic;
using Entitas;
using Source.Scripts.Gameplay.Features.Room.Service;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Room
{
  [Preserve]
  public class SwapRoomsWhenNewRoomViewSpawnedSystem : ReactiveSystem<GameEntity>
  {
    private readonly IRoomService _roomService;
    
    public SwapRoomsWhenNewRoomViewSpawnedSystem(GameContext game, IRoomService roomService) : base(game) =>
      _roomService = roomService;

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.View.Added());

    protected override bool Filter(GameEntity rooms) => rooms.isRoom && rooms.hasView;

    protected override void Execute(List<GameEntity> rooms)
    {
      foreach (GameEntity room in rooms)
        _roomService.SwapRooms();
    }
  }
}