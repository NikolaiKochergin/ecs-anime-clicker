using System.Collections.Generic;
using System.Linq;
using Entitas;
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
    private readonly IEnumerable<IGameProgressReader> _gameProgressReaders;
    private readonly IEnumerable<IGameProgressWriter> _gameProgressWriters;

    private ProgressData _progressData;

    public SaveLoadService(
      MetaContext meta, 
      GameContext game, 
      IEnumerable<IGameProgressReader> gameProgressReaders,
      IEnumerable<IGameProgressWriter> gameProgressWriters)
    {
      _meta = meta;
      _game = game;
      _gameProgressReaders = gameProgressReaders;
      _gameProgressWriters = gameProgressWriters;
    }
    
    public bool HasSavedProgress => PlayerPrefs.HasKey(ProgressKey);

    public void CreateProgress() =>
      _progressData = new ProgressData();

    public void SaveProgress()
    {
      foreach (IGameProgressWriter progressWriter in _gameProgressWriters)
        progressWriter.UpdateProgress(_progressData);
      
      PreserveEntities(_meta, out _progressData.EntityData.MetaEntitySnapshots);
      PreserveEntities(_game, out _progressData.EntityData.GameEntitySnapshots);
      PlayerPrefs.SetString(ProgressKey, _progressData.ToJson());
      PlayerPrefs.Save();
    }

    public void LoadMetaProgress() =>
      HydrateProgress(PlayerPrefs.GetString(ProgressKey));

    public void LoadGameProgress()
    {
      foreach (IGameProgressReader progressReader in _gameProgressReaders)
        progressReader.LoadProgress(_progressData);
      
      HydrateEntities(_game, _progressData.EntityData.GameEntitySnapshots);
    }

    private void HydrateProgress(string serializedProgress)
    {
      _progressData = serializedProgress.FromJson<ProgressData>();
      HydrateEntities(_meta, _progressData.EntityData.MetaEntitySnapshots);
    }
    
    private static void HydrateEntities<T>(Context<T> context, List<EntitySnapshot> snapshots) where T : Entity
    {
      foreach (EntitySnapshot snapshot in snapshots)
        context
          .CreateEntity()
          .HydrateWith(snapshot);
    }
    
    private static void PreserveEntities<T>(Context<T> context, out List<EntitySnapshot> snapshots) where T : Entity =>
      snapshots = context
        .GetEntities()
        .Where(RequiresSave)
        .Select(e => e.AsSavedEntity())
        .ToList();

    private static bool RequiresSave(Entity e) =>
      e.GetComponents().Any(c => c is ISavedComponent);
  }
}