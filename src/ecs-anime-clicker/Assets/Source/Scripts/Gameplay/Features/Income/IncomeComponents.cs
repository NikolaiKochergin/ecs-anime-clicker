using Entitas;

namespace Source.Scripts.Gameplay.Features.Income
{
  [Game] public class Income : IComponent { }
  [Game] public class AutoIncomeEmitter : IComponent { }
  [Game] public class Period : IComponent { public float Value; }
  [Game] public class TimeSinceLastTick : IComponent { public float Value; }
}