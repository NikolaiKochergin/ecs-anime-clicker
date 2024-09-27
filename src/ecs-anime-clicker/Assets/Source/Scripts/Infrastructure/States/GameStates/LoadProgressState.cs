using Source.Scripts.Infrastructure.States.StateInfrastructure;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States.GameStates
{
  public class LoadProgressState : SimpleState, IUpdateable
  {
    public override void Enter()
    {
      Debug.Log("Load Progress State Enter");
    }

    public void Update()
    {
      Debug.Log("Load Progress State Update");
    }
  }
}