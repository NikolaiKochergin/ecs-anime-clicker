using Cysharp.Threading.Tasks;

namespace Source.Scripts.Infrastructure.AssetManagement
{
  public interface IAssetDownloadService
  {
    UniTask InitializeDownloadDataAsync();
    float GetDownloadSizeMb();
    UniTask UpdateContentAsync();
  }
}