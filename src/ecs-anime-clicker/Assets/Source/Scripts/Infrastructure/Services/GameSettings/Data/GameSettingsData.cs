using System;

namespace Source.Scripts.Infrastructure.Services.GameSettings.Data
{
    [Serializable]
    public class GameSettingsData
    {
        public AudioData Audio = new();
    }
}