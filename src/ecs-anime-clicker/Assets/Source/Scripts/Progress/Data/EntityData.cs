using System.Collections.Generic;
using Newtonsoft.Json;

namespace Source.Scripts.Progress.Data
{
  public class EntityData
  {
    [JsonProperty("mes")] public List<EntitySnapshot> MetaEntitySnapshots = new();
    [JsonProperty("ges")] public List<EntitySnapshot> GameEntitySnapshots = new();
  }
}