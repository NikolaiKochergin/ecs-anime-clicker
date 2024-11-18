using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Characters.Factory
{
  public interface ICharacterFactory
  {
    void SetCharactersRoot(Transform charactersRoot);
    GameEntity CreateCharacter(string nameId);
  }
}