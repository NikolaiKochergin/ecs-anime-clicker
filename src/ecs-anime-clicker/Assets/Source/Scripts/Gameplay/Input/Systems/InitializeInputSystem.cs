using Entitas;
using Source.Scripts.Common.Entity;

namespace Source.Scripts.Gameplay.Input.Systems
{
  public class InitializeInputSystem : IInitializeSystem
  {
    public void Initialize()
    {
      CreateInputEntity.Empty()
        .isInput = true;
    }
  }
}