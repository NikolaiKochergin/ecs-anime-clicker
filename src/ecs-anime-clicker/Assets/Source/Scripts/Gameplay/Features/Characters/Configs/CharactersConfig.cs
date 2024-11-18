using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Characters.Configs
{
  [CreateAssetMenu(menuName = "ECS Anime Clicker/Characters Config", fileName = "CharactersConfig", order = 0)]
  public class CharactersConfig : ScriptableObject
  {
    [field: SerializeField] public List<CharacterData> CharacterData { get; private set; }
  }
}