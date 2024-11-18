using System.Collections.Generic;
using Newtonsoft.Json;

namespace Source.Scripts.Progress.Data
{
  public class ProgressData
  {
    [JsonProperty("e")] public EntityData EntityData = new();
    [JsonProperty("cr")] public string CurrentRoom = "Room-1";
    [JsonProperty("cch")] public string CurrentCharacter = "Captain";
    [JsonProperty("or")] public List<string> OpenedRooms = new() { "Room-1", "Room-2", "Room-3", "Room-4" };
    [JsonProperty("oc")] public List<string> OpenedCharacters = new() {"Captain", "Elf", "Kat", "Miku" };
  }
}