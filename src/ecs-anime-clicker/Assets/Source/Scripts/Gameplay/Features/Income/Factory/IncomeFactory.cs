using Source.Scripts.Common.Entity;
using Source.Scripts.Common.Extensions;

namespace Source.Scripts.Gameplay.Features.Income.Factory
{
  public class IncomeFactory : IIncomeFactory 
  {
    public GameEntity CreateIncome() =>
      CreateGameEntity.Empty()
        .AddGold(1)
        .With(x => x.isIncome = true);
  }
}