using System.Collections.Generic;
using Entitas;
using Source.Scripts.Infrastructure.View.Factory;
using UnityEngine.Scripting;

namespace Source.Scripts.Infrastructure.View.Systems
{
  [Preserve]
  public class BindEntityViewFromAssetNameSystem : IExecuteSystem
  {
    private readonly IEntityViewFactory _entityViewFactory;
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(32);

    public BindEntityViewFromAssetNameSystem(GameContext game, IEntityViewFactory entityViewFactory)
    {
      _entityViewFactory = entityViewFactory;
      _entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.ViewAssetName)
        .NoneOf(GameMatcher.View));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
        _entityViewFactory.CreateViewForEntityFromAssetName(entity);
    }
  }
}