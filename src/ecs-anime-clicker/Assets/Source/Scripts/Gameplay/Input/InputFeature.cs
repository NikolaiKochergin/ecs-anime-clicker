using Source.Scripts.Gameplay.Input.Systems;
using Source.Scripts.Infrastructure.Systems;

namespace Source.Scripts.Gameplay.Input
{
  public class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeInputSystem>());
      Add(systems.Create<EmitInputSystem>());
    }
  }
}