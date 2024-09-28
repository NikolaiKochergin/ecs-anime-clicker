using Entitas;
using Source.Scripts.Infrastructure.View;

namespace Source.Scripts.Common
{
  [Input, Game, Meta] public class Destructed : IComponent { }
  [Game] public class SelfDestructTimer : IComponent { public float Value; }
  [Game] public class View : IComponent { public IEntityView Value; }
  [Game] public class ViewPath : IComponent { public string Value; }
  [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
}