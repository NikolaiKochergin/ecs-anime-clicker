namespace Source.Scripts.Gameplay.Features.Characters.Service
{
  public interface ICharacterService
  {
    void SetNextCharacter();
    void SetNewCharacter(string nameId);
    void SwapCharacters();
  }
}