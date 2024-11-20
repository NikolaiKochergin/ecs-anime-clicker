using Entitas;
using UnityEngine.Scripting;

namespace Source.Scripts.Gameplay.Features.Income.Systems
{
  [Preserve]
  public class GoldIncomeReceiveSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _incomes;
    private readonly IGroup<GameEntity> _wallets;

    public GoldIncomeReceiveSystem(GameContext game)
    {
      _wallets = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Wallet,
          GameMatcher.Gold));
      
      _incomes = game.GetGroup(GameMatcher.
        AllOf(
          GameMatcher.Income,
          GameMatcher.Gold));
    }

    public void Execute()
    {
      foreach (GameEntity income in _incomes)
      foreach (GameEntity wallet in _wallets)
      {
        wallet.ReplaceGold(wallet.Gold + income.Gold);
        income.isDestructed = true;
      }
    }
  }
}