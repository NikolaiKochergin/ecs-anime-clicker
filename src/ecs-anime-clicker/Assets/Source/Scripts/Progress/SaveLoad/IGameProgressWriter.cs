using Source.Scripts.Progress.Data;

namespace Source.Scripts.Progress.SaveLoad
{
  public interface IGameProgressWriter : IGameProgressReader
  {
    void UpdateProgress(ProgressData data);
  }
}