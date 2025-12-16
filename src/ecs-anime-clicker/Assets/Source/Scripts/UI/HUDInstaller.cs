using Reflex.Core;
using UnityEngine;

namespace Source.Scripts.UI
{
  public class HUDInstaller : MonoBehaviour, IInstaller
  {
    [SerializeField] private HUD _hud;
    
    public void InstallBindings(ContainerBuilder builder)
    {
      builder.OnContainerBuilt += OnContainerBuilt;
      return;

      void OnContainerBuilt(Container container)
      {
        builder.OnContainerBuilt -= OnContainerBuilt;
        
        container.Resolve<HUDProvider>().HUD = _hud;
      }
    }
  }
}