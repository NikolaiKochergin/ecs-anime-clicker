using Reflex.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Infrastructure.Loading
{
  // Has execution order to start before every other script
  public class SwitchToEntrySceneInEditor : MonoBehaviour
  {
#if UNITY_EDITOR
    private const int EntrySceneIndex = 1;

    private void Awake()
    {
      // Тут должно быть условие, если понадобится.
      // if(ProjectContext.HasInstance)
      //   return;

      foreach (GameObject root in gameObject.scene.GetRootGameObjects()) 
        root.SetActive(false);
      
      SceneManager.LoadScene(EntrySceneIndex);
    }
#endif
  }
}