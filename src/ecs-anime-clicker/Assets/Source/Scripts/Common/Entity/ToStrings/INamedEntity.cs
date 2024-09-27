using Entitas;

namespace Source.Scripts.Common.Entity.ToStrings
{
  public interface INamedEntity : IEntity
  {
    string EntityName(IComponent[] components);
    string BaseToString();
  }
}