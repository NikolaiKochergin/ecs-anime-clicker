using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Source.Scripts.Infrastructure.AssetManagement
{
  public class AssetProvider : IAssetProvider, ICleanable
  {
    private readonly IAssetLoadReporter _reporter;
    private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new();
    private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new();
    
    public AssetProvider(IAssetLoadReporter reporter) => 
      _reporter = reporter;
    
    public async UniTask<TObject> LoadAsync<TObject>(AssetReference assetReference) where TObject : class
    {
      if (_completedCache.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
        return completedHandle.Result as TObject;

      return await RunWithCacheOnComplete(
        Addressables.LoadAssetAsync<TObject>(assetReference), 
        cacheKey: assetReference.AssetGUID);
    }

    public async UniTask<TObject> LoadAsync<TObject>(string address) where TObject : class
    {
      if (_completedCache.TryGetValue(address, out AsyncOperationHandle completedHandle))
        return completedHandle.Result as TObject;

      return await RunWithCacheOnComplete(
        Addressables.LoadAssetAsync<TObject>(address), 
        cacheKey: address);
    }

    public void Release(AssetReference assetReference)
    {
      foreach (AsyncOperationHandle handle in _handles[assetReference.AssetGUID])
        handle.Release();
      
      _completedCache.Remove(assetReference.AssetGUID);
      _handles.Remove(assetReference.AssetGUID);
    }
    
    public void Release(string address)
    {
      foreach (AsyncOperationHandle handle in _handles[address])
        handle.Release();
      
      _completedCache.Remove(address);
      _handles.Remove(address);
    }

    public void Cleanup()
    {
      foreach (List<AsyncOperationHandle> resourceHandles in _handles.Values)
      foreach (AsyncOperationHandle handle in resourceHandles)
        Addressables.Release(handle);
            
      _completedCache.Clear();
      _handles.Clear();
    }
    
    private async UniTask<T> RunWithCacheOnComplete<T>(AsyncOperationHandle<T> handle, string cacheKey) 
      where T : class
    {
      handle.Completed += completeHandle => _completedCache[cacheKey] = completeHandle;
      AddHandle(cacheKey, handle);
      return await handle.ToUniTask(_reporter);
    }

    private void AddHandle<T>(string key, AsyncOperationHandle<T> handle) where T : class
    {
      if (!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandles))
      {
        resourceHandles = new List<AsyncOperationHandle>();
        _handles[key] = resourceHandles;
      }
      resourceHandles.Add(handle);
    }
  }
}