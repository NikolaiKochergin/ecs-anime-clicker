using Cysharp.Threading.Tasks;
using Source.Scripts.Infrastructure.Services.GameSettings.Data;

namespace Source.Scripts.Infrastructure.Services.GameSettings
{
    public interface IGameSettingsReader
    {
        UniTask LoadSettings(GameSettingsData data);
    }
}