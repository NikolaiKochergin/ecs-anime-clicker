using Entitas;
using Source.Scripts.Infrastructure.View;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Source.Scripts.Common
{
  [Input, Game, Meta] public class Destructed : IComponent { }
  [Game] public class SelfDestructTimer : IComponent { public float Value; }
  [Game] public class ViewSpawning : IComponent { }
  [Game] public class View : IComponent { public IEntityView Value; }
  [Game] public class ViewAssetName : IComponent { public string Value; }
  [Game] public class ViewAssetReference : IComponent { public AssetReference Value; }
  [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
  [Game] public class Parent : IComponent { public Transform Value; }
}