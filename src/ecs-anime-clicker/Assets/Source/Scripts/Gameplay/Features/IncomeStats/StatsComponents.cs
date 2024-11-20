using System.Collections.Generic;
using Entitas;

namespace Source.Scripts.Gameplay.Features.IncomeStats
{
  [Game] public class BaseStats : IComponent { public Dictionary<Stats, int> Value; }
  [Game] public class StatModifiers : IComponent { public Dictionary<Stats, int> Value; }
}