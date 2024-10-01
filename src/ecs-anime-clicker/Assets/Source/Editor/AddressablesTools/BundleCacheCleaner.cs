using UnityEditor;
using UnityEngine;

namespace Source.Editor.AddressablesTools
{
  public static class BundleCacheCleaner
  {
    [MenuItem("Tools/Clear Addressable bundles cache")]
    private static void ClearBundleCache()
    {
      Caching.ClearCache();
    }
  }
}