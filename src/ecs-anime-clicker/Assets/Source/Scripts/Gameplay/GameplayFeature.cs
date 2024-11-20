using Source.Scripts.Common.Destruct;
using Source.Scripts.Gameplay.Features.Characters;
using Source.Scripts.Gameplay.Features.Income;
using Source.Scripts.Gameplay.Features.IncomeStats;
using Source.Scripts.Gameplay.Features.Room;
using Source.Scripts.Gameplay.Input;
using Source.Scripts.Infrastructure.Systems;
using Source.Scripts.Infrastructure.View;
using Source.Scripts.Meta;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay
{
  [Preserve]
  public sealed class GameplayFeature : Feature
  {
    public GameplayFeature(ISystemFactory systems)
    {
      Add(systems.Create<InputFeature>());
      Add(systems.Create<StatsFeature>());
      Add(systems.Create<IncomeFeature>());
      
      Add(systems.Create<BindViewFeature>());

      Add(systems.Create<RoomFeature>());
      Add(systems.Create<CharactersFeature>());

      
      Add(systems.Create<UpdateUIFeature>());
      
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}