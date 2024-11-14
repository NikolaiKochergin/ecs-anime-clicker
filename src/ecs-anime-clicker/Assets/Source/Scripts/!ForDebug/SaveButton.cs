using Reflex.Attributes;
using Source.Scripts.Progress.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts._ForDebug
{
  public class SaveButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    [Inject]
    private void Construct(ISaveLoadService saveLoad) =>
      _button.onClick.AddListener(saveLoad.SaveProgress);
  }
}