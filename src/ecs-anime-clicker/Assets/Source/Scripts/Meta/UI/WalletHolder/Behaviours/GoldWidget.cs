using Reflex.Attributes;
using Source.Scripts.Meta.UI.WalletHolder.Service;
using TMPro;
using UnityEngine;

namespace Source.Scripts.Meta.UI.WalletHolder.Behaviours
{
  public class GoldWidget : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _goldAmount;
    
    private IWalletUIService _wallet;

    [Inject]
    private void Construct(IWalletUIService wallet) =>
      _wallet = wallet;

    private void Start()
    {
      UpdateGold();
      _wallet.GoldChanged += UpdateGold;
    }

    private void OnDestroy() =>
      
      _wallet.GoldChanged -= UpdateGold;

    private void UpdateGold() =>
      _goldAmount.SetText(_wallet.CurrentGold.ToString());
  }
}