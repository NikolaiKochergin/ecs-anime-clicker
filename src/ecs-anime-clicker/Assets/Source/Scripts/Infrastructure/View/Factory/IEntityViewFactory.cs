using Cysharp.Threading.Tasks;

namespace Source.Scripts.Infrastructure.View.Factory
{
  public interface IEntityViewFactory
  {
    EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity);
    UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity);
    UniTask<EntityBehaviour> CreateViewForEntityFromAssetName(GameEntity entity);
  }
}