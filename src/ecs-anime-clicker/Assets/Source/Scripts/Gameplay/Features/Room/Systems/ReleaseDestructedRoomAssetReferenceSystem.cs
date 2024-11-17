using Entitas;
using Source.Scripts.Infrastructure.AssetManagement;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Room.Systems
{
  [Preserve]
  public class ReleaseDestructedRoomAssetReferenceSystem : IExecuteSystem
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IGroup<GameEntity> _rooms;

    public ReleaseDestructedRoomAssetReferenceSystem(GameContext game, IAssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
      _rooms = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Room,
          GameMatcher.ViewAssetReference,
          GameMatcher.Destructed));
    }

    public void Execute()
    {
      foreach (GameEntity room in _rooms)
        _assetProvider.Release(room.ViewAssetReference);
    }
  }
}