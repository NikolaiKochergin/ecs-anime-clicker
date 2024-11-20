using Entitas;
using Source.Scripts.Meta.UI.WalletHolder.Service;
using UnityEngine.Scripting;

namespace Source.Scripts.Meta.UI.WalletHolder.Systems
{
  [Preserve]
  public class RefreshGoldSystem : IExecuteSystem
  {
    private readonly IWalletUIService _wallet;
    private readonly IGroup<GameEntity> _wallets;

    public RefreshGoldSystem(GameContext game, IWalletUIService wallet)
    {
      _wallet = wallet;
      _wallets = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Wallet,
          GameMatcher.Gold));
    }
    
    public void Execute()
    {
      foreach (GameEntity wallet in _wallets)
        _wallet.UpdateCurrentGold(wallet.Gold);
    }
  }
}