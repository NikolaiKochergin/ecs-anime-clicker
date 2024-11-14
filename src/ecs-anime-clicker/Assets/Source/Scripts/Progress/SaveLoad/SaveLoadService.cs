using System.Collections.Generic;
using System.Linq;
using Source.Scripts.Infrastructure.Serialization;
using Source.Scripts.Progress.Data;
using UnityEngine;

namespace Source.Scripts.Progress.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string ProgressKey = "PlayerProgress";
    
    private readonly MetaContext _meta;
    private readonly GameContext _game;

    private ProgressData _progressData;

    public SaveLoadService(MetaContext meta, GameContext game)
    {
      _meta = meta;
      _game = game;
    }
    
    public bool HasSavedProgress => PlayerPrefs.HasKey(ProgressKey);

    public void CreateProgress() =>
      _progressData = new ProgressData();

    public void SaveProgress()
    {
      PreserveMetaEntities();
      PreserveGameEntities();
      PlayerPrefs.SetString(ProgressKey, _progressData.ToJson());
      PlayerPrefs.Save();
    }

    public void LoadMetaProgress() =>
      HydrateProgress(PlayerPrefs.GetString(ProgressKey));

    public void LoadGameProgress() => 
      HydrateGameEntities();

    private void HydrateProgress(string serializedProgress)
    {
      _progressData = serializedProgress.FromJson<ProgressData>();
      HydrateMetaEntities();
    }

    private void HydrateMetaEntities()
    {
      List<EntitySnapshot> snapshots = _progressData.EntityData.MetaEntitySnapshots;
      foreach (EntitySnapshot snapshot in snapshots)
        _meta
          .CreateEntity()
          .HydrateWith(snapshot);
    }
    
    private void HydrateGameEntities()
    {
      List<EntitySnapshot> snapshots = _progressData.EntityData.GameEntitySnapshots;
      foreach (EntitySnapshot snapshot in snapshots)
        _meta
          .CreateEntity()
          .HydrateWith(snapshot);
    }

    private void PreserveMetaEntities() =>
      _progressData.EntityData.MetaEntitySnapshots = _meta
        .GetEntities()
        .Where(RequiresSave)
        .Select(e => e.AsSavedEntity())
        .ToList();
    
    private void PreserveGameEntities() =>
      _progressData.EntityData.GameEntitySnapshots = _game
        .GetEntities()
        .Where(RequiresSave)
        .Select(e => e.AsSavedEntity())
        .ToList();

    private static bool RequiresSave(MetaEntity e) =>
      e.GetComponents().Any(c => c is ISavedComponent);
    
    private static bool RequiresSave(GameEntity e) =>
      e.GetComponents().Any(c => c is ISavedComponent);
  }
}