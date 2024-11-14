using System;
using System.Linq;
using Entitas;
using Source.Scripts.Common.Extensions;

namespace Source.Scripts.Progress
{
  public static class ProgressEntityExtensions
  {
    public static EntitySnapshot AsSavedEntity(this IEntity entity) => new()
      {
        Components = entity.GetComponents()
          .Where(c => c is ISavedComponent)
          .Cast<ISavedComponent>()
          .ToList(),
      };

    public static IEntity HydrateWith(this IEntity entity, EntitySnapshot entityData)
    {
      foreach (ISavedComponent component in entityData.Components)
      {
        int lookupIndex = LookupIndexOf(component, entity);
        entity.With(x => x.ReplaceComponent(lookupIndex, component), when: lookupIndex >= 0);
      }
      return entity;
    }

    private static int LookupIndexOf(ISavedComponent component, IEntity entity) =>
      Array.IndexOf(ComponentTypes(entity), component.GetType());

    private static Type[] ComponentTypes(IEntity entity) =>
      entity switch
      {
        MetaEntity => MetaComponentsLookup.componentTypes,
        GameEntity => GameComponentsLookup.componentTypes,
        _ => throw new ArgumentException($"Requested Lookup for {entity.GetType().Name} which is not implemented"),
      };
  }
}