using Source.Scripts.Gameplay.Input;
using Source.Scripts.Infrastructure.Systems;
using Source.Scripts.Infrastructure.View;

namespace Source.Scripts.Gameplay
{
  public sealed class GameplayFeature : Feature
  {
    public GameplayFeature(ISystemFactory systems)
    {
      Add(systems.Create<InputFeature>());
      Add(systems.Create<BindViewFeature>());
    }
  }
}