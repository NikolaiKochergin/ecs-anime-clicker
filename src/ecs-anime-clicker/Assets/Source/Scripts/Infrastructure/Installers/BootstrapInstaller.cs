using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Reflex.Core;
using RSG;
using Source.Scripts.Gameplay.Common.Random;
using Source.Scripts.Gameplay.Common.Time;
using Source.Scripts.Gameplay.Features.Room.Factory;
using Source.Scripts.Gameplay.Features.Room.Service;
using Source.Scripts.Gameplay.Input.Service;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Infrastructure.Identifiers;
using Source.Scripts.Infrastructure.Loading;
using Source.Scripts.Infrastructure.Services.GameSettings;
using Source.Scripts.Infrastructure.Services.StaticData;
using Source.Scripts.Infrastructure.States.Factory;
using Source.Scripts.Infrastructure.States.GameStates;
using Source.Scripts.Infrastructure.States.StateMachine;
using Source.Scripts.Infrastructure.Systems;
using Source.Scripts.Infrastructure.View.Factory;
using Source.Scripts.Progress.SaveLoad;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Installers
{
  public class BootstrapInstaller : MonoBehaviour, IInstaller
  {
    public void InstallBindings(ContainerBuilder builder)
    {
      BindInputService(builder);
      BindInfrastructureServices(builder);
      BindAssetManagementServices(builder);
      BindCommonServices(builder);
      BindSystemFactory(builder);
      BindUIFactories(builder);
      BindContexts(builder);
      BindGameplayServices(builder);
      BindUIServices(builder);
      BindCameraProvider(builder);
      BindGameplayFactories(builder);
      BindEntityIndices(builder);
      BindProgressServices(builder);
      BindStateMachine(builder);
      BindStateFactory(builder);
      BindGameStates(builder);
      
      LogPromiseException();

      RunGame(builder.Build());
    }

    private static void BindInputService(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(StandaloneInputService), typeof(IInputService));

    private static void BindInfrastructureServices(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(StaticDataService), typeof(IStaticDataService), typeof(IStaticDataLoader))
        .AddSingleton(typeof(IdentifierService), typeof(IIdentifierService))
        .AddSingleton(typeof(GameSettingsService), typeof(IGameSettingsService));

    private static void BindAssetManagementServices(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(AssetProvider), typeof(IAssetProvider))
        .AddSingleton(typeof(LabeledAssetDownloadService), typeof(IAssetDownloadService))
        .AddSingleton(typeof(AssetLoadReporter), typeof(IAssetLoadReporter));

    private static void BindCommonServices(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(UnityRandomService), typeof(IRandomService))
        .AddSingleton(typeof(UnityTimeService), typeof(ITimeService))
        .AddSingleton(typeof(SceneLoader), typeof(ISceneLoader));

    private static void BindSystemFactory(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(SystemFactory), typeof(ISystemFactory));

    private static void BindContexts(ContainerBuilder builder) =>
      builder
        .AddSingleton(Contexts.sharedInstance)
        .AddSingleton(Contexts.sharedInstance.input)
        .AddSingleton(Contexts.sharedInstance.game)
        .AddSingleton(Contexts.sharedInstance.meta);

    private static void BindEntityIndices(ContainerBuilder builder)
    {
    }

    private static void BindCameraProvider(ContainerBuilder builder)
    {
    }

    private static void BindUIFactories(ContainerBuilder builder)
    {
    }

    private static void BindUIServices(ContainerBuilder builder)
    {
    }

    private static void BindGameplayServices(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(RoomService), typeof(IRoomService), typeof(IGameProgressReader), typeof(IGameProgressWriter));

    private static void BindGameplayFactories(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(EntityViewFactory), typeof(IEntityViewFactory))
        .AddSingleton(typeof(RoomFactory), typeof(IRoomFactory));

    private static void BindProgressServices(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(SaveLoadService), typeof(ISaveLoadService));

    private static void BindStateMachine(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(GameStateMachine), typeof(IGameStateMachine), typeof(ITickable));

    private static void BindStateFactory(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(StateFactory), typeof(IStateFactory));

    private static void BindGameStates(ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(BootstrapState))
        .AddSingleton(typeof(LoadProgressState))
        .AddSingleton(typeof(GameLoopState));


    private static void LogPromiseException() => 
      Promise.UnhandledException += (_, e) => Debug.LogError(e);

    private static void RunGame(Container container)
    {
      EnterToBootstrapState(container);
      RunTickables(container).Forget();
    }

    private static void EnterToBootstrapState(Container container) =>
      container
        .Resolve<IGameStateMachine>()
        .Enter<BootstrapState>();

    private static async UniTaskVoid RunTickables(Container container)
    {
      List<ITickable> tickables = container.All<ITickable>().ToList();
      while (Application.isPlaying)
      {
        foreach (ITickable tickable in tickables)
          tickable.Tick();

        await UniTask.NextFrame();
      }
    }
  }
}