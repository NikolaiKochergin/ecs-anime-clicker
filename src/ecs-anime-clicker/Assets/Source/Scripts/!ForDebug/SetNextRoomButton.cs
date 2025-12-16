using Reflex.Attributes;
using Source.Scripts.Gameplay.Features.Room.Service;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts._ForDebug
{
  public class SetNextRoomButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    [Inject]
    private void Construct(IRoomService roomService)
    {
      _button.onClick.AddListener(roomService.SetNextRoom);
    }
  }
}