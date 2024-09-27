using Reflex.Core;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Installers
{
  public class BootstrapInstaller : MonoBehaviour, IInstaller
  {
    public void InstallBindings(ContainerBuilder builder) =>
      builder
        .BindInputService()
        .BindInfrastructureServices()
        .BindAssetManagementServices()
        .BindCommonServices()
        .BindSystemFactory()
        .BindUIFactories()
        .BindContexts()
        .BindGameplayServices()
        .BindUIServices()
        .BindCameraProvider()
        .BindGameplayFactories()
        .BindEntityIndices()
        .BindStateMachine()
        .BindStateFactory()
        .BindGameStates()
        .BindProgressServices()
        .StartGame();
  }
}