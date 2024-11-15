using Entitas;
using Source.Scripts.Common.Entity;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Input.Systems
{
  [Preserve]
  public class InitializeInputSystem : IInitializeSystem
  {
    public void Initialize()
    {
      CreateInputEntity.Empty()
        .isInput = true;
    }
  }
}