using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Reflex.Core;
using RSG;
using Source.Scripts.Infrastructure.States.Factory;
using Source.Scripts.Infrastructure.States.GameStates;
using Source.Scripts.Infrastructure.States.StateMachine;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Installers
{
  public static class ReflexContainerExtensions
  {
    public static ContainerBuilder BindInputService(this ContainerBuilder builder) => 
      builder;

    public static ContainerBuilder BindInfrastructureServices(this ContainerBuilder builder) =>
      builder;
    
    public static ContainerBuilder BindAssetManagementServices(this ContainerBuilder builder) =>
      builder;
    
    public static ContainerBuilder BindCommonServices(this ContainerBuilder builder) =>
      builder;
    
    public static ContainerBuilder BindSystemFactory(this ContainerBuilder builder) => 
      builder;
    
    public static ContainerBuilder BindUIFactories(this ContainerBuilder builder) => 
      builder;
    
    public static ContainerBuilder BindContexts(this ContainerBuilder builder) => 
      builder;
    
    public static ContainerBuilder BindGameplayServices(this ContainerBuilder builder) =>
      builder;
    
    public static ContainerBuilder BindUIServices(this ContainerBuilder builder) =>
      builder;
    
    public static ContainerBuilder BindCameraProvider(this ContainerBuilder builder) => 
      builder;
    
    public static ContainerBuilder BindGameplayFactories(this ContainerBuilder builder) => 
      builder;
    
    public static ContainerBuilder BindEntityIndices(this ContainerBuilder builder) => 
      builder;

    public static ContainerBuilder BindProgressServices(this ContainerBuilder builder) => 
      builder;

    public static ContainerBuilder BindStateMachine(this ContainerBuilder builder) =>
      builder
        .AddSingleton(typeof(GameStateMachine), typeof(IGameStateMachine), typeof(ITickable));

    public static ContainerBuilder BindStateFactory(this ContainerBuilder builder) => 
      builder
        .AddSingleton(typeof(StateFactory), typeof(IStateFactory));

    public static ContainerBuilder BindGameStates(this ContainerBuilder builder) => 
      builder
        .AddSingleton(typeof(BootstrapState))
        .AddSingleton(typeof(LoadProgressState));

    public static void StartGame(this ContainerBuilder builder)
    {
      LogPromiseException();

      builder
        .Build()
        .EnterToBootstrapState()
        .StartGameLoop();
    }

    private static Container EnterToBootstrapState(this Container container)
    {
      container
        .Resolve<IGameStateMachine>()
        .Enter<BootstrapState>();

      return container;
    }

    private static async void StartGameLoop(this Container container)
    {
      IEnumerable<ITickable> tickables = container.All<ITickable>();
      while (true)
      {
        foreach (ITickable tickable in tickables)
          tickable.Tick();

        await UniTask.Yield(PlayerLoopTiming.Update);
      }
    }

    private static void LogPromiseException() => 
      Promise.UnhandledException += (_, e) => Debug.LogError(e);
  }
}