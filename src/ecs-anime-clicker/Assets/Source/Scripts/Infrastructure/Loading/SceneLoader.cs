using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Infrastructure.Loading
{
  public class SceneLoader : ISceneLoader
  {
    public async UniTask LoadSceneAsync(string nextScene)
    {
      if(SceneManager.GetActiveScene().name == nextScene)
        return;

      await SceneManager.LoadSceneAsync(nextScene).ToUniTask();
    }
  }
}