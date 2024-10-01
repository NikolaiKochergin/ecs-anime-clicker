using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Source.Scripts.Common.Extensions;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Source.Scripts.Infrastructure.AssetManagement
{
  public class LabeledAssetDownloadService : IAssetDownloadService
  {
    public const string RemoteLabel = "remote";
    
    private readonly IAssetDownloadReporter _downloadReporter;
    private long _downloadSize;

    public LabeledAssetDownloadService(IAssetDownloadReporter downloadReporter)
    {
      _downloadReporter = downloadReporter;
    }

    public async UniTask InitializeDownloadDataAsync()
    {
      await Addressables.InitializeAsync().ToUniTask();
      await UpdateCatalogsAsync();
      await UpdateDownloadSizeAsync();
    }

    public float GetDownloadSizeMb() => 
      SizeToMb(_downloadSize);

    public async UniTask UpdateContentAsync()
    {
      try
      {
        AsyncOperationHandle downloadHandle = Addressables.DownloadDependenciesAsync(RemoteLabel);
      
        while (!downloadHandle.IsDone && downloadHandle.IsValid())
        {
          await UniTask.Delay(100);
          _downloadReporter.Report(downloadHandle.GetDownloadStatus().Percent);
        }
      
        _downloadReporter.Report(1f);
        if (downloadHandle.Status == AsyncOperationStatus.Failed) 
          Debug.LogError("Error while downloading catalog dependencies");
      
        if(downloadHandle.IsValid())
          Addressables.Release(downloadHandle);
      
        _downloadReporter.Reset();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }

    private async UniTask UpdateCatalogsAsync()
    {
      List<string> catalogsToUpdate = await Addressables.CheckForCatalogUpdates().ToUniTask();
      if (catalogsToUpdate.IsNullOrEmpty())
        return;

      await Addressables.UpdateCatalogs(catalogsToUpdate).ToUniTask();
    }

    private async UniTask UpdateDownloadSizeAsync()
    {
      try
      {
        _downloadSize = await Addressables
          .GetDownloadSizeAsync(RemoteLabel)
          .ToUniTask();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }

    private static float SizeToMb(long downloadSize) => downloadSize * 1f / 1048576;
  }
}