using Cysharp.Threading.Tasks;
using Reflex.Core;
using Reflex.Injectors;
using Source.Scripts.Common.Extensions;
using Source.Scripts.Infrastructure.AssetManagement;
using UnityEngine;

namespace Source.Scripts.Infrastructure.View.Factory
{
  public class EntityViewFactory : IEntityViewFactory 
  {
    private readonly Container _container;
    private readonly IAssetProvider _assetProvider;

    public EntityViewFactory(Container container, IAssetProvider assetProvider)
    {
      _container = container;
      _assetProvider = assetProvider;
    }
    
    public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity) =>
      InstantiateAndInject(entity.ViewPrefab, entity.hasParent ? entity.Parent : null)
        .SetEntity(entity);

    public async UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity) =>
      InstantiateAndInject((await _assetProvider
          .LoadAsync<GameObject>(entity.ViewAssetReference))
          .GetComponent<EntityBehaviour>(),
          entity.hasParent ? entity.Parent : null)
        .SetEntity(entity)
        .With(x => x.Entity.isViewSpawning = false);
    
    public async UniTask<EntityBehaviour> CreateViewForEntityFromAssetName(GameEntity entity) =>
      InstantiateAndInject((await _assetProvider
          .LoadAsync<GameObject>(entity.ViewAssetName))
          .GetComponent<EntityBehaviour>(),
          entity.hasParent ? entity.Parent : null)
        .SetEntity(entity)
        .With(x => x.Entity.isViewSpawning = false);

    private EntityBehaviour InstantiateAndInject(EntityBehaviour prefab, Transform parent = null)
    {
      EntityBehaviour newEntity = Object.Instantiate(prefab, parent);
      GameObjectInjector.InjectObject(newEntity.gameObject, _container);
      return newEntity;
    }
  }
}