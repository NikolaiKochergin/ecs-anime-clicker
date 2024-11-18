using System.Collections.Generic;
using Entitas;
using Source.Scripts.Gameplay.Features.Characters.Service;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Characters.Systems
{
  [Preserve]
  public sealed class SwapCharactersWhenNewCharacterViewSpawnedSystem : ReactiveSystem<GameEntity>
  {
    private readonly ICharacterService _characterService;
    
    public SwapCharactersWhenNewCharacterViewSpawnedSystem(GameContext game, ICharacterService characterService) : base(game) =>
      _characterService = characterService;

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.View.Added());

    protected override bool Filter(GameEntity characters) => characters.isCharacter && characters.hasView;

    protected override void Execute(List<GameEntity> characters)
    {
      foreach (GameEntity character in characters)
        _characterService.SwapCharacters();
    }
  }
}