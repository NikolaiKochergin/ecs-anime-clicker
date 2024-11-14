namespace Source.Scripts.Progress.SaveLoad
{
  public interface ISaveLoadService
  {
    bool HasSavedProgress { get; }
    void CreateProgress();
    void SaveProgress();
    void LoadMetaProgress();
    void LoadGameProgress();
  }
}