using System;

namespace Source.Scripts.Infrastructure.Services.GameSettings.Data
{
    [Serializable]
    public class AudioData
    {
        public float ThemeVolume = 0.05f;
        public float SFXVolume = 0.8f;
        public bool IsThemeEnabled = true;
        public bool IsSFXEnabled = true;
        public bool IsMuted = false;
    }
}       