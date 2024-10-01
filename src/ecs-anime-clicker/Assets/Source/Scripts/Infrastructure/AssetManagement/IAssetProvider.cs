using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Source.Scripts.Infrastructure.AssetManagement
{
  public interface IAssetProvider
  {
    UniTask<TObject> LoadAsync<TObject>(AssetReference assetReference) where TObject : class;
    UniTask<TObject> LoadAsync<TObject>(string address) where TObject : class;
  }
}