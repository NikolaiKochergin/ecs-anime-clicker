namespace Source.Scripts.Gameplay.Features.Room.Factory
{
  public interface IRoomFactory
  {
    GameEntity CreateRoom(string currentRoomName);
  }
}