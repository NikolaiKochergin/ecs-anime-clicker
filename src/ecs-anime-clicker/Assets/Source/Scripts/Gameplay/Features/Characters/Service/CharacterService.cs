using System.Collections.Generic;
using Source.Scripts.Gameplay.Features.Characters.Factory;
using Source.Scripts.Progress.Data;
using Source.Scripts.Progress.SaveLoad;

namespace Source.Scripts.Gameplay.Features.Characters.Service
{
  public class CharacterService : ICharacterService , IGameProgressWriter
  {
    private readonly ICharacterFactory _factory;
    private GameEntity _currentCharacter;
    private GameEntity _previousCharacter;
    private List<string> _openedCharacters;

    public CharacterService(ICharacterFactory factory) =>
      _factory = factory;

    public void LoadProgress(ProgressData data)
    {
      _openedCharacters = data.OpenedCharacters;
      _currentCharacter = _factory.CreateCharacter(data.CurrentCharacter);
    }

    public void UpdateProgress(ProgressData data) =>
      data.CurrentCharacter = _currentCharacter.CharacterNameId;

    public void SetNextCharacter()
    {
      int index = _openedCharacters.IndexOf(_currentCharacter.CharacterNameId) + 1;
      
      if(index >= _openedCharacters.Count)
        index = 0;
      
      SetNewCharacter(_openedCharacters[index]);
    }

    public void SetNewCharacter(string nameId)
    {
      _previousCharacter = _currentCharacter;
      _currentCharacter = _factory.CreateCharacter(nameId);
    }

    public void SwapCharacters()
    {
      if(_previousCharacter != null)
        _previousCharacter.isDestructed = true;

      _previousCharacter = null;
    }
  }
}