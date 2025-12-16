using System;
using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Scripting;

namespace Source.Scripts._ForDebug
{
  public class GetFlagsConfigurationButton : MonoBehaviour
  {
    public void GetFlagsWithParameters()
    {
      string json = JsonUtility.ToJson(new FlagsRequest()
      {
        clientFeatures = new List<ClientFeature>()
        {
          new() { name = "elf", value = 10.ToString()},
          new() { name = "orc", value = 5.ToString()},
        },
      });
      
      Debug.Log(json);
      
      FlagsConfiguration.GetFlags(json, OnGetFlagsConfiguration);
    }
    
    public void GetOrcFlagsWithParameters()
    {
      string json = JsonUtility.ToJson(new FlagsRequest()
      {
        clientFeatures = new List<ClientFeature>()
        {
          new() { name = "orc", value = 5.ToString()},
        },
      });
      
      Debug.Log(json);
      
      FlagsConfiguration.GetFlags(json, OnGetFlagsConfiguration);
    }
    
    public void GetElfFlagsWithParameters()
    {
      string json = JsonUtility.ToJson(new FlagsRequest()
      {
        clientFeatures = new List<ClientFeature>()
        {
          new() { name = "elf", value = 10.ToString()},
        },
      });
      
      Debug.Log(json);
      
      FlagsConfiguration.GetFlags(json, OnGetFlagsConfiguration);
    }
    
    
    public void GetFlagsConfigurationData()
    {
      FlagsConfiguration.GetFlags("", OnGetFlagsConfiguration);
    }

    private void OnGetFlagsConfiguration(string dataJson)
    {
      Debug.Log(dataJson);
      FlagsConfigurationData data = JsonUtility.FromJson<FlagsConfigurationData>(dataJson);
      
      Debug.Log(data.ToString());
    }
  }

  [Serializable]
  public class FlagsRequest
  {
    [field: Preserve] 
    public FlagsConfigurationData defaultFlags;

    [field: Preserve] 
    public List<ClientFeature> clientFeatures = new();
  }

  [Serializable]
  public class FlagsConfigurationData
  {
    [field: Preserve] 
    public string difficult;

    [field: Preserve] 
    public int smart;

    public override string ToString() =>
      $"difficult: {difficult}, smart: {smart}";
  }

  [Serializable]
  public class ClientFeature
  {
    [field: Preserve] 
    public string name;
    [field: Preserve]
    public string value;
  }
}