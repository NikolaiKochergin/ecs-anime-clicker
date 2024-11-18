using Source.Scripts.Gameplay.Features.Characters.Systems;
using Source.Scripts.Infrastructure.Systems;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Characters
{
  [Preserve]
  public sealed class CharactersFeature : Feature
  {
    public CharactersFeature(ISystemFactory systems)
    {
      Add(systems.Create<SwapCharactersWhenNewCharacterViewSpawnedSystem>());

      Add(systems.Create<ReleaseDestructedCharactersAssetReferenceSystem>());
    }
  }
}