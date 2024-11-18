using Source.Scripts.Common.Entity;
using Source.Scripts.Common.Extensions;
using Source.Scripts.Infrastructure.Identifiers;
using Source.Scripts.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Characters.Factory
{
  public class CharacterFactory : ICharacterFactory
  {
    private readonly IIdentifierService _identifiers;
    private readonly IStaticDataService _staticData;
    
    private Transform _charactersRoot;

    public CharacterFactory(IIdentifierService identifiers, IStaticDataService staticData)
    {
      _identifiers = identifiers;
      _staticData = staticData;
    }
    
    public void SetCharactersRoot(Transform charactersRoot) => _charactersRoot = charactersRoot;

    public GameEntity CreateCharacter(string nameId) =>
      CreateGameEntity.Empty()
        .AddId(_identifiers.Next())
        .AddCharacterNameId(nameId)
        .AddParent(_charactersRoot)
        .AddViewAssetReference(_staticData.ForCharacter(nameId).CharacterReference)
        .With(x => x.isCharacter = true);
  }
}