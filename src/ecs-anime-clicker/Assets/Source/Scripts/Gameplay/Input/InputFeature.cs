using Source.Scripts.Gameplay.Input.Systems;
using Source.Scripts.Infrastructure.Systems;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Input
{
  [Preserve]
  public sealed class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeInputSystem>());
      Add(systems.Create<EmitInputSystem>());
    }
  }
}