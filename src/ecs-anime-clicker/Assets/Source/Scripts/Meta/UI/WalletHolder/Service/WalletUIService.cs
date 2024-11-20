using System;

namespace Source.Scripts.Meta.UI.WalletHolder.Service
{
  public class WalletUIService : IWalletUIService
  {
    public int CurrentGold { get; private set; }

    public event Action GoldChanged;

    public void UpdateCurrentGold(int amount)
    {
      if(CurrentGold == amount)
        return;
      
      CurrentGold = amount;
      GoldChanged?.Invoke();
    }

    public void Cleanup()
    {
      CurrentGold = 0;
      
      GoldChanged = null;
    }
  }
}