using System;
using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Purchases.Configs
{
  [Serializable]
  public class PurchaseData
  {
    [field: SerializeField] public string Id { get; private set; }
    [field: SerializeField] public string Price { get; private set; }
  }
}