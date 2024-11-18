using Reflex.Attributes;
using Source.Scripts.Gameplay.Features.Characters.Service;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts._ForDebug
{
  public class SetNextCharacterButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    
    [Inject]
    private void Construct(ICharacterService characterService) =>
      _button.onClick.AddListener(characterService.SetNextCharacter);
  }
}