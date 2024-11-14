using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Source.Scripts.Gameplay.Common
{
  [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
}