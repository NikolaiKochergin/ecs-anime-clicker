using System;
using Source.Scripts.Configs.References;
using Source.Scripts.Infrastructure.View;
using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Room.Configs
{
  [Serializable]
  public class RoomData
  {
    [field: SerializeField] public string NameId { get; private set; }
    [field: SerializeField] public ComponentReference<EntityBehaviour> RoomReference { get; private set; }
  }
}