using System.Collections.Generic;
using Entitas;

namespace Source.Scripts.Common.Destruct.Systems
{
  public class CleanupInputDestructedSystem : ICleanupSystem
  {
    private readonly IGroup<InputEntity> _entities;
    private readonly List<InputEntity> _buffer = new(64);

    public CleanupInputDestructedSystem(InputContext input) =>
      _entities = input.GetGroup(InputMatcher.Destructed);

    public void Cleanup()
    {
      foreach (InputEntity entity in _entities.GetEntities(_buffer)) 
        entity.Destroy();
    }
  }
}