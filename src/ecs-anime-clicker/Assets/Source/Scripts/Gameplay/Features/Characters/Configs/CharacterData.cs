using System;
using Source.Scripts.Configs.References;
using Source.Scripts.Infrastructure.View;
using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Characters.Configs
{
  [Serializable]
  public class CharacterData
  {
    [field: SerializeField] public string NameId { get; private set; }
    [field: SerializeField] public ComponentReference<EntityBehaviour> CharacterReference { get; private set; }
  }
}