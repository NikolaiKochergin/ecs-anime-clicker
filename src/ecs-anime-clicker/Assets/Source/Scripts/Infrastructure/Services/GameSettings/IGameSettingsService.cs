using System;
using Cysharp.Threading.Tasks;

namespace Source.Scripts.Infrastructure.Services.GameSettings
{
    public interface IGameSettingsService
    {
        UniTask Load(Action onSuccessCallback = null);
        UniTask Save(Action onSuccessCallback = null);
    }
}