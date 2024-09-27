using Entitas;
using UnityEngine;

namespace Source.Scripts.Gameplay.Input
{
  [Input] public class Input : IComponent { }
  [Input] public class AxisInput : IComponent { public Vector2 Value; }
}