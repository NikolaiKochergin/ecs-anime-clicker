using Reflex.Attributes;
using Source.Scripts.Common.Entity;
using Source.Scripts.Infrastructure.Identifiers;
using UnityEngine;

namespace Source.Scripts.Infrastructure.View
{
  public class SelfInitializedEntityView : MonoBehaviour
  {
    [SerializeField] private EntityBehaviour _entityBehaviour;
    
    private IIdentifierService _identifiers;
    
    [Inject]
    private void Construct(IIdentifierService identifiers) =>
      _identifiers = identifiers;

    private void Awake()
    {
      GameEntity entity = CreateEntity.Empty()
        .AddId(_identifiers.Next());
      
      _entityBehaviour.SetEntity(entity);
    }

#if UNITY_EDITOR
    private void Reset() =>
      _entityBehaviour = GetComponent<EntityBehaviour>();
#endif
  }
}