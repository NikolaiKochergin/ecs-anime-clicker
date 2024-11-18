using Entitas;
using Source.Scripts.Infrastructure.AssetManagement;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Characters.Systems
{
  [Preserve]
  public class ReleaseDestructedCharactersAssetReferenceSystem : IExecuteSystem
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IGroup<GameEntity> _characters;

    public ReleaseDestructedCharactersAssetReferenceSystem(GameContext game, IAssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
      _characters = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Character,
          GameMatcher.ViewAssetReference,
          GameMatcher.Destructed));
    }

    public void Execute()
    {
      foreach (GameEntity character in _characters)
        _assetProvider.Release(character.ViewAssetReference);
    }
  }
}