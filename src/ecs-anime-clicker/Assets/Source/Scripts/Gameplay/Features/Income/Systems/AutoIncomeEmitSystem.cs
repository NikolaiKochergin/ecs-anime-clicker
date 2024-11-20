using Entitas;
using Source.Scripts.Gameplay.Common.Time;
using Source.Scripts.Gameplay.Features.Income.Factory;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Income.Systems
{
  [Preserve]
  public class AutoIncomeEmitSystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IIncomeFactory _factory;
    private readonly IGroup<GameEntity> _autoIncomeEmitters;

    public AutoIncomeEmitSystem(GameContext game, ITimeService time, IIncomeFactory factory)
    {
      _time = time;
      _factory = factory;
      _autoIncomeEmitters = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.AutoIncomeEmitter,
          GameMatcher.Period,
          GameMatcher.TimeSinceLastTick));
    }
    
    public void Execute()
    {
      foreach (GameEntity emitter in _autoIncomeEmitters)
      {
        if(emitter.TimeSinceLastTick >= 0)
          emitter.ReplaceTimeSinceLastTick(emitter.TimeSinceLastTick - _time.DeltaTime);
        else
        {
          emitter.ReplaceTimeSinceLastTick(emitter.TimeSinceLastTick + emitter.Period);
          _factory.CreateIncome();
        }
      }
    }
  }
}