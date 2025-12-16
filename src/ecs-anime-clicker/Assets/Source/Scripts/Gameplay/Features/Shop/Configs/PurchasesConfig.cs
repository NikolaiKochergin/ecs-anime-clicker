using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Shop.Configs
{
  [CreateAssetMenu(menuName = "ECS Anime Clicker/Purchases Config", fileName = "PurchasesConfig", order = 0)]
  public class PurchasesConfig : ScriptableObject
  {
    [SerializeField] private PurchaseData[] _purchasesData;
    
    public PurchaseData[] PurchasesData => _purchasesData;
  }
}