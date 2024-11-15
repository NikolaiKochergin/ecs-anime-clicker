using System.Collections.Generic;
using Source.Scripts.Gameplay.Features.Room.Factory;
using Source.Scripts.Progress.Data;
using Source.Scripts.Progress.SaveLoad;

namespace Source.Scripts.Gameplay.Features.Room.Service
{
  public class RoomService : IRoomService , IGameProgressWriter
  {
    private readonly IRoomFactory _factory;
    private GameEntity _currentRoom;
    private List<string> _openedRooms;

    public RoomService(IRoomFactory factory) =>
      _factory = factory;

    public void LoadProgress(ProgressData data)
    {
      _openedRooms = data.OpenedRooms;
      _currentRoom = _factory.CreateRoom(data.CurrentRoom);
    }

    public void UpdateProgress(ProgressData data) =>
      data.CurrentRoom = _currentRoom.NameId;

    public void SetNewRoom(string nameId)
    {
      _currentRoom.isDestructed = true;
      
      _currentRoom = _factory.CreateRoom(nameId);
    }

    public void SetNextRoom()
    {
      int index = _openedRooms.IndexOf(_currentRoom.NameId) + 1;
      
      if(index >= _openedRooms.Count)
        index = 0;

      _currentRoom.isDestructed = true;
      _currentRoom = _factory.CreateRoom(_openedRooms[index]);
    }
  }
}