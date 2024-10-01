using Cysharp.Threading.Tasks;
using Source.Scripts.Infrastructure.AssetManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Infrastructure.Loading
{
  public class SceneLoader : ISceneLoader
  {
    private readonly IAssetLoadReporter _reporter;

    public SceneLoader(IAssetLoadReporter reporter) => 
      _reporter = reporter;

    public async UniTask LoadSceneAsync(string nextScene)
    {
      if(SceneManager.GetActiveScene().name == nextScene)
        return;

      await Addressables.LoadSceneAsync(nextScene).ToUniTask(_reporter);
    }
  }
}