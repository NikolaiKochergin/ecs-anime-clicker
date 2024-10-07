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
    [TestCaseSource(nameof(AllScenePaths))]
    public void AllGameObjectsShouldNotHaveMissingScripts(string scenePath)
    {
      Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);

      List<string> gameObjectsWithMissingScripts =
        GetAllGameObject(scene)
          .Where(HasMissingScripts)
          .Select(gameObject => gameObject.name)
          .ToList();
      
      EditorSceneManager.CloseScene(scene, removeScene: true);

      gameObjectsWithMissingScripts.Should().BeEmpty();
    }

    private static bool HasMissingScripts(GameObject gameObject) =>
      GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(gameObject) > 0;

    private static IEnumerable<string> AllScenePaths() =>
      AssetDatabase
        .FindAssets("t:Scene", new[] {"Assets"})
        .Select(AssetDatabase.GUIDToAssetPath);

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