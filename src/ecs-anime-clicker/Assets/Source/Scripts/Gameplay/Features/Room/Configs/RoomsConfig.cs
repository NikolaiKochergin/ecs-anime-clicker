using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Room.Configs
{
  [CreateAssetMenu(menuName = "ECS Anime Clicker/Rooms Config", fileName = "RoomsConfig", order = 0)]
  public class RoomsConfig : ScriptableObject
  {
    [field: SerializeField] public List<RoomData> RoomData { get; private set; }
  }
}