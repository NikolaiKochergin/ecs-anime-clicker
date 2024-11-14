using Cysharp.Threading.Tasks;
using Reflex.Core;
using Reflex.Injectors;
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
      InstantiateAndInject(entity.ViewPrefab)
        .SetEntity(entity);

    public async UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity) =>
      InstantiateAndInject(await _assetProvider
          .LoadAsync<EntityBehaviour>(entity.ViewAssetReference))
        .SetEntity(entity);

    private EntityBehaviour InstantiateAndInject(EntityBehaviour prefab)
    {
      EntityBehaviour newEntity = Object.Instantiate(prefab);
      GameObjectInjector.InjectObject(newEntity.gameObject, _container);
      return newEntity;
    }
  }
}