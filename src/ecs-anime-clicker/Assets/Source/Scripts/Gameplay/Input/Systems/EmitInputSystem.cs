using Entitas;
using Source.Scripts.Gameplay.Input.Service;
using UnityEngine;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Input.Systems
{
  [Preserve]
  public class EmitInputSystem : IExecuteSystem
  {
    private readonly IInputService _inputService;
    private readonly IGroup<InputEntity> _inputs;

    public EmitInputSystem(InputContext input, IInputService inputService)
    {
      _inputService = inputService;
      _inputs = input.GetGroup(InputMatcher.Input);
    }
    
    public void Execute()
    {
      foreach (InputEntity input in _inputs)
      {
        input.isMouseButtonDownInput = _inputService.GetLeftMouseButtonDown();
      }
    }
  }
}