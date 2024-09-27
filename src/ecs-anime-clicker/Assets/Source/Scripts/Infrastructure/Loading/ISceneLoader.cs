using Cysharp.Threading.Tasks;

namespace Source.Scripts.Infrastructure.Loading
{
  public interface ISceneLoader
  {
    UniTask LoadSceneAsync(string nextScene);
  }
}