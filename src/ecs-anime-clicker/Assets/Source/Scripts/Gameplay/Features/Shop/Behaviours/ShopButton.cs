using Reflex.Attributes;
using Source.Scripts.Gameplay.Features.Shop.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.Gameplay.Features.Shop.Behaviours
{
  public class ShopButton : MonoBehaviour
  {
    [SerializeField] private Button _buyButton;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private string _purchaseId;
    
    private IShopService _shops;

    [Inject]
    private void Construct(IShopService shops) =>
      _shops = shops;

    private void Start()
    {
      _priceText.SetText("{0}", _shops.GetPrice(_purchaseId));
      _buyButton.onClick.AddListener(OnBuyButtonClicked);
    }

    private void OnDestroy() =>
      
      _buyButton.onClick.RemoveListener(OnBuyButtonClicked);

    private void OnBuyButtonClicked() =>
      _shops.TryBuy(_purchaseId);
  }
}