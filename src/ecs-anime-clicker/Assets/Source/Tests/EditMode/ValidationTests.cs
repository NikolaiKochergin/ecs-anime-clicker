using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Tests.EditMode
{
  public class ValidationTests
  {
    [Test]
    public void AllGameObjectsShouldNotHaveMissingScripts()
    {
      IEnumerable<string> errors = 
        from scene in OpenProjectScenes() 
        from gameObject in GetAllGameObject(scene) 
        where HasMissingScripts(gameObject) 
        select $"Game object {gameObject.name} from scene {scene.name} has missing component(s).";

      errors.Should().BeEmpty();
    }

    private static bool HasMissingScripts(GameObject gameObject) =>
      GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(gameObject) > 0;

    private static IEnumerable<Scene> OpenProjectScenes()
    {
      IEnumerable<string> scenePaths = AssetDatabase
        .FindAssets("t:Scene", new[] {"Assets"})
        .Select(AssetDatabase.GUIDToAssetPath);

      foreach (string scenePath in scenePaths)
      {
        Scene scene = SceneManager.GetSceneByPath(scenePath);
        if (scene.isLoaded)
        {
          yield return scene;
        }
        else
        {
          Scene openedScene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);
          yield return openedScene;
          EditorSceneManager.CloseScene(openedScene, removeScene: true);
        }
      }
    }

    private static IEnumerable<GameObject> GetAllGameObject(Scene scene)
    {
      Queue<GameObject> gameObjectQueue = new(scene.GetRootGameObjects());

      while (gameObjectQueue.Count > 0)
      {
        GameObject gameObject = gameObjectQueue.Dequeue();

        yield return gameObject;

        foreach (Transform child in gameObject.transform)
          gameObjectQueue.Enqueue(child.gameObject);
      }
    }
  }
}