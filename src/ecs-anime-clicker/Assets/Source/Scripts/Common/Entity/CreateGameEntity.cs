namespace Source.Scripts.Common.Entity
{
  public static class CreateGameEntity
  {
    public static GameEntity Empty() =>
      Contexts.sharedInstance.game.CreateEntity();
  }
}