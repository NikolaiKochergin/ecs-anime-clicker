using Reflex.Attributes;
using Source.Scripts.Gameplay.Features.Characters.Factory;
using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Characters.Providers
{
  public class CharactersRootProvider : MonoBehaviour
  {
    [Inject]
    private void SetDependency(ICharacterFactory characterFactory) =>
      characterFactory.SetCharactersRoot(transform);
  }
}