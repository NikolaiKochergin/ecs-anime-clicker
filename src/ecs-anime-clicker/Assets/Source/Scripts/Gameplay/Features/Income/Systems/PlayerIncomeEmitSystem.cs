using Entitas;
using Source.Scripts.Gameplay.Features.Income.Factory;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Income.Systems
{
  [Preserve]
  public class PlayerIncomeEmitSystem : IExecuteSystem
  {
    private readonly IIncomeFactory _factory;
    private readonly IGroup<InputEntity> _clicks;

    public PlayerIncomeEmitSystem(InputContext input, IIncomeFactory factory)
    {
      _factory = factory;
      _clicks = input.GetGroup(InputMatcher.MouseButtonDownInput);
    }
    
    public void Execute()
    {
      foreach (InputEntity click in _clicks)
        _factory.CreateIncome().ReplaceGold(100);
    }
  }
}