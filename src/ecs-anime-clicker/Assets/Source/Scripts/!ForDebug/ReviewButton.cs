using System;
using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts._ForDebug
{
  public class ReviewButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _buttonText;

    private void OnEnable()
    {
      ReviewPopup.CanOpen(OnCanOpenCallback);
      _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable() =>
      _button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick()
    {
      ReviewPopup.CanOpen((canOpen, reason) =>
      {
        _buttonText.text = reason;
        if(canOpen)
          ReviewPopup.Open(OnOpenCallback);
      });
    }

    private void OnOpenCallback(bool isOpened) =>
      _button.image.color = isOpened 
        ? Color.yellow 
        : Color.magenta;

    private void OnCanOpenCallback(bool canOpen, string reason)
    {
      _button.image.color = canOpen ? Color.green : Color.red;
      _buttonText.text = reason;
    }
  }
}