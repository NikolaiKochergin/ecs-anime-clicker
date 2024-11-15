using Reflex.Attributes;
using Source.Scripts.Gameplay.Features.Room.Service;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts._ForDebug
{
  public class SetRoomButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    [SerializeField] private string _roomName;

    [Inject]
    private void Construct(IRoomService roomService) =>
      _button.onClick.AddListener(() => roomService.SetNewRoom(_roomName));
  }
}