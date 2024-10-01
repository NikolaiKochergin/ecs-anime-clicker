using Entitas;
using Source.Scripts.Gameplay.Input.Service;
using UnityEngine;

namespace Source.Scripts.Gameplay.Input.Systems
{
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
        if(_inputService.HasAxisInput())
          input.ReplaceAxisInput(new Vector2(_inputService.GetHorizontalAxis(), _inputService.GetVerticalAxis()));
        else if(input.hasAxisInput)
          input.RemoveAxisInput();

        input.isMouseButtonDownInput = _inputService.GetLeftMouseButton();
      }
    }
  }
}