using System;
using Cysharp.Threading.Tasks;
using Reflex.Core;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Infrastructure.States.StateInfrastructure;
using Source.Scripts.Infrastructure.States.StateMachine;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private readonly Container _container;

    public BootstrapState(Container container) => 
      _container = container;

    public override void Enter() => 
      OnEnter().Forget();

    private async UniTaskVoid OnEnter()
    {
      await Initialize();
      
      _container
        .Resolve<IGameStateMachine>()
        .Enter<LoadProgressState>();
    }

    private async UniTask Initialize()
    {
      IAssetDownloadService downloadService = _container.Resolve<IAssetDownloadService>();
      await downloadService.InitializeDownloadDataAsync();
      float downloadSize = downloadService.GetDownloadSizeMb();
      
      Debug.Log($"Download size is {downloadSize} Mb");

      if (downloadSize > 0)
        await downloadService.UpdateContentAsync();

      IAssetDownloadReporter reporter = _container.Resolve<IAssetDownloadReporter>();

      reporter.ProgressUpdated += DisplayDownloadProgress;
    }

    private void DisplayDownloadProgress(float value)
    {
      Debug.Log(">>>>>>>>>>> Download Progress " + value);
    }
  }
}