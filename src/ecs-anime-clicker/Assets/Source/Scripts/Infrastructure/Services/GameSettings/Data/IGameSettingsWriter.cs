namespace Source.Scripts.Infrastructure.Services.GameSettings.Data
{
    public interface IGameSettingsWriter : IGameSettingsReader
    {
        void UpdateSettings(GameSettingsData data);
    }
}