using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Source.Scripts.Infrastructure.AssetManagement
{
  public interface IAssetProvider
  {
    UniTask<GameObject> LoadAssetAsync(string path);
  }
}