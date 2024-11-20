using System;

namespace Source.Scripts.Meta.UI.WalletHolder.Service
{
  public interface IWalletUIService
  {
    int CurrentGold { get; }
    event Action GoldChanged;
    void UpdateCurrentGold(int amount);
    void Cleanup();
  }
}