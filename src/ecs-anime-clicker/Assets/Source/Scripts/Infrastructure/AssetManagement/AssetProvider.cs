using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Source.Scripts.Infrastructure.AssetManagement
{
  public class AssetProvider : IAssetProvider
  {
    public async UniTask<GameObject> LoadAssetAsync(string path) => 
      await Addressables.LoadAssetAsync<GameObject>(path).ToUniTask();
  }
}