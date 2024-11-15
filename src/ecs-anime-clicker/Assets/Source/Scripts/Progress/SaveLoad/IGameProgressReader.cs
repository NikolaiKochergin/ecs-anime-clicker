using Source.Scripts.Progress.Data;

namespace Source.Scripts.Progress.SaveLoad
{
  public interface IGameProgressReader
  {
    void LoadProgress(ProgressData data);
  }
}