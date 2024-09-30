using UnityEditor;
using UnityEngine;

namespace Source.Editor
{
  public class BundleCacheCleaner
  {
    [MenuItem("Tool/Clear Addressable bundles cache")]
    private static void ClearBundleCache()
    {
      Caching.ClearCache();
    }
  }
}