using Source.Scripts.Infrastructure.View.Registrars;
using UnityEngine;

namespace Source.Scripts.Infrastructure.View
{
  public class EntityBehaviour : MonoBehaviour, IEntityView
  {
    public GameEntity Entity { get; private set; }

    public EntityBehaviour SetEntity(GameEntity entity)
    {
      Entity = entity;
      Entity.AddView(this);
      Entity.Retain(this);

      foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>()) 
        registrar.RegisterComponents();

      return this;
    }

    public void ReleaseEntity()
    {
      foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>()) 
        registrar.UnregisterComponents();
      
      Entity.Release(this);
      Entity = null;
    }
  }
}