using System;
using Source.Scripts.Infrastructure.AssetManagement;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Build.DataBuilders;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;

namespace Source.Editor.AddressablesTools.Build
{
  [CreateAssetMenu(fileName = "MarkRemoteGroupsBuildScriptPacked.asset", menuName = "Addressables/Build/MarkRemoteGroupsBuildScriptPacked")]
  public class MarkRemoteGroupsBuildScript : BuildScriptPackedMode
  {
    public override string Name => "Mark Remote Groups Build Script";
    private static AddressableAssetSettings Settings => AddressableAssetSettingsDefaultObject.Settings;

    protected override TResult BuildDataImplementation<TResult>(AddressablesDataBuilderInput builderInput)
    {
      TResult result = base.BuildDataImplementation<TResult>(builderInput);

      MarkRemoteAssetsInGroups();
      
      return result;
    }

    private static void MarkRemoteAssetsInGroups()
    {
      AddRemoteLabelIfNeeded();
      foreach (AddressableAssetGroup group in Settings.groups)
      {
        foreach (AddressableAssetEntry entry in group.entries)
        {
          entry.SetLabel(LabeledAssetDownloadService.RemoteLabel, enable: entry.MainAsset is GameObject);
          
          // if (entry.MainAsset is GameObject go)
          // {
          //   Settings.AddLabel(go.name);
          //   entry.SetLabel(go.name, true);
          //   Debug.Log(">>>>>>>" + go.name);
          // }
        }
        
        SetTimeoutForRemoteGroup(group);
        
        EditorUtility.SetDirty(group);
      }
    }

    private static void SetTimeoutForRemoteGroup(AddressableAssetGroup group)
    {
      if (group.IsRemote())
        group.GetSchema<BundledAssetGroupSchema>().Timeout = (int) TimeSpan.FromMinutes(1).TotalSeconds;
    }

    private static void AddRemoteLabelIfNeeded()
    {
      if(!Settings.GetLabels().Contains(LabeledAssetDownloadService.RemoteLabel))
        Settings.AddLabel(LabeledAssetDownloadService.RemoteLabel);
    }
  }
}