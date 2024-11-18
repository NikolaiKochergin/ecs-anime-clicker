using Reflex.Attributes;
using Source.Scripts.Gameplay.Features.Room.Factory;
using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Room.Providers
{
  public class RoomRootProvider : MonoBehaviour
  {
    [Inject]
    private void SetDependency(IRoomFactory roomFactory) =>
      roomFactory.SetRoomsRoot(transform);
  }
}