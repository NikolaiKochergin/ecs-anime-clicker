using UnityEngine;

namespace Source.Scripts.UI
{
  public class HUD : MonoBehaviour
  {
    private void Awake() =>
      Hide();

    public void Show() =>
      gameObject.SetActive(true);

    public void Hide() =>
      gameObject.SetActive(false);
  }
}