using Reflex.Core;

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
    
    public static ContainerBuilder BindStateMachine(this ContainerBuilder builder) => 
      builder;
    
    public static ContainerBuilder BindStateFactory(this ContainerBuilder builder) => 
      builder;
    
    public static ContainerBuilder BindGameStates(this ContainerBuilder builder) => 
      builder;
    
    public static ContainerBuilder BindProgressServices(this ContainerBuilder builder) => 
      builder;

    public static void StartGame(this ContainerBuilder builder)
    {
      builder
        .Build();
      // .Resolve<IGameStateMachine>()
      // .Enter<BootstrapState();
    }
  }
}