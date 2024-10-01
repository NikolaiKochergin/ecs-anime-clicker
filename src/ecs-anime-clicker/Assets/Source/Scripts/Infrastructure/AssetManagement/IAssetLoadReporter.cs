using System;

namespace Source.Scripts.Infrastructure.AssetManagement
{
  public interface IAssetLoadReporter : IProgress<float>
  {
    float Progress { get; }
    event Action ProgressUpdated;
    void Reset();
  }
}