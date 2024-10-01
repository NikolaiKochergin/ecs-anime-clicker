using System;

namespace Source.Scripts.Infrastructure.AssetManagement
{
  public interface IAssetDownloadReporter : IProgress<float>
  {
    float Progress { get; }
    event Action ProgressUpdated;
    void Reset();
  }
}