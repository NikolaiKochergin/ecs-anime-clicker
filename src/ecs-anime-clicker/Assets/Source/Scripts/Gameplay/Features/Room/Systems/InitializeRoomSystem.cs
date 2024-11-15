using Entitas;
using UnityEngine;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Room.Systems
{
  [Preserve]
  public class InitializeRoomSystem : IInitializeSystem
  {
    public InitializeRoomSystem()
    {
      
    }
    
    public void Initialize()
    {
      Debug.LogWarning("Initialize room system >>>>>>>>>>>>>>>>");
    }
  }
}