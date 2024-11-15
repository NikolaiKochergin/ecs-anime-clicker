using Source.Scripts.Gameplay.Features.Room.Factory;
using Source.Scripts.Progress.Data;
using Source.Scripts.Progress.SaveLoad;

namespace Source.Scripts.Gameplay.Features.Room.Service
{
  public class RoomService : IRoomService , IGameProgressWriter
  {
    private readonly IRoomFactory _factory;

    public RoomService(IRoomFactory factory) =>
      _factory = factory;

    private string CurrentRoomName { get; set; }

    public void LoadProgress(ProgressData data)
    {
      CurrentRoomName = data.CurrentRoom;

      _factory.CreateRoom(CurrentRoomName);
    }

    public void UpdateProgress(ProgressData data)
    {
      data.CurrentRoom = CurrentRoomName;
    }
  }
}