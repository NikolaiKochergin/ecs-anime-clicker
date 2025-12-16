using System;
using UnityEngine;

namespace Source.Scripts.Gameplay.Features.Shop.Configs
{
  [Serializable]
  public class PurchaseData
  {
    [field: SerializeField] public string Id { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
  }
}