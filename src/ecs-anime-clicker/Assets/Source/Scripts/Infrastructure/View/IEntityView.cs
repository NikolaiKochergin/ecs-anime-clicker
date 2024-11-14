using UnityEngine;

namespace Source.Scripts.Infrastructure.View
{
  public interface IEntityView
  {
    GameEntity Entity { get; }
    GameObject gameObject { get; }
    
    EntityBehaviour SetEntity(GameEntity entity);
    void ReleaseEntity();
  }
}