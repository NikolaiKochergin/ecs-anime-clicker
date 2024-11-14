using System.Collections.Generic;
using Newtonsoft.Json;

namespace Source.Scripts.Progress
{
  public class EntitySnapshot
  {
    [JsonProperty("c")] public List<ISavedComponent> Components;
  }
}