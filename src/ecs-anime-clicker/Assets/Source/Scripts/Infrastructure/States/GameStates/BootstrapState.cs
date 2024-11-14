using System.Linq;
using Cysharp.Threading.Tasks;
using Reflex.Core;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Infrastructure.Services;
using Source.Scripts.Infrastructure.Services.GameSettings;
using Source.Scripts.Infrastructure.Services.StaticData;
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

      await LoadStaticData();
      await InitializeServices();
      await LoadGameSettings();
      
      ToLoadProgress();
    }

    private void ToLoadProgress() =>
      _container
        .Resolve<IGameStateMachine>()
        .Enter<LoadProgressState>();

    private async UniTask LoadStaticData() =>
      await UniTask
        .WhenAll(Enumerable
          .Select(_container
            .All<IStaticDataLoader>(), sd => sd
            .Load()));
    
    private async UniTask InitializeServices() =>
      await UniTask
        .WhenAll(Enumerable
          .Select(_container
            .All<IInitializable>(), i => i
            .Initialize()));
    
    private async UniTask LoadGameSettings() => 
      await _container.Resolve<IGameSettingsService>().Load();


    private async UniTask Initialize()
    {
      IAssetDownloadService downloadService = _container.Resolve<IAssetDownloadService>();
      await downloadService.InitializeDownloadDataAsync();
      float downloadSize = downloadService.GetDownloadSizeMb();
      
      Debug.Log($"Download size is {downloadSize} Mb");

      IAssetLoadReporter reporter = _container.Resolve<IAssetLoadReporter>();
      
      reporter.ProgressUpdated += DisplayDownloadProgress;
      
      // if (downloadSize > 0)
      //   await downloadService.UpdateContentAsync();

      return;

      void DisplayDownloadProgress()
      {
        Debug.Log(">>>>>>>>>>> Download Progress " + reporter.Progress);
      }
    }
  }
}