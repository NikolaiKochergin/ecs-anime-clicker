using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Source.Scripts.Infrastructure.Serialization;
using Source.Scripts.Infrastructure.Services.GameSettings.Data;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Services.GameSettings
{
    public class GameSettingsService : IGameSettingsService
    {
        private const string SettingsKey = "Settings";
        
        private readonly IEnumerable<IGameSettingsWriter> _settingsWriters;
        private readonly IEnumerable<IGameSettingsReader> _settingsReaders;

        private GameSettingsData _data;

        public GameSettingsService(
            IEnumerable<IGameSettingsWriter> settingsWriters,
            IEnumerable<IGameSettingsReader> settingsReaders)
        {
            _settingsWriters = settingsWriters;
            _settingsReaders = settingsReaders;
        }

        public UniTask Load(Action onSuccessCallback = null)
        {
            _data = PlayerPrefs.HasKey(SettingsKey) 
                ? PlayerPrefs.GetString(SettingsKey).FromJson<GameSettingsData>() 
                : new GameSettingsData();

            foreach (IGameSettingsReader reader in _settingsReaders) 
                reader.LoadSettings(_data);
            
            onSuccessCallback?.Invoke();
            return UniTask.CompletedTask;
        }
        
        public UniTask Save(Action onSuccessCallback = null)
        {
            foreach (IGameSettingsWriter writer in _settingsWriters) 
                writer.UpdateSettings(_data);
            
            PlayerPrefs.SetString(SettingsKey, _data.ToJson());
            
            onSuccessCallback?.Invoke();
            return UniTask.CompletedTask;
        }
    }
}