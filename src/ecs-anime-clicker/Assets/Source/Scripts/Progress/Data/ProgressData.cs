using Newtonsoft.Json;

namespace Source.Scripts.Progress.Data
{
  public class ProgressData
  {
    [JsonProperty("e")] public EntityData EntityData = new();
    [JsonProperty("cr")] public string CurrentRoom = "Room-1";
  }
}