using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Source.Scripts.Configs;
using Source.Scripts.Gameplay.Features.Room.Configs;
using UnityEngine.AddressableAssets;

namespace Source.Scripts.Infrastructure.Services.StaticData
{
  public class StaticDataService : IStaticDataService, IStaticDataLoader 
  {
    private const string GameConfig = "GameConfig";
    private const string RoomsConfig = "RoomsConfig";
    
    private GameConfig _gameConfig;
    private RoomsConfig _roomsConfig;
    
    private Dictionary<string, RoomData> _roomsMap;

    public async UniTask Load()
    {
      _gameConfig = await Addressables.LoadAssetAsync<GameConfig>(GameConfig);
      _roomsConfig = await Addressables.LoadAssetAsync<RoomsConfig>(RoomsConfig);
      
      _roomsMap = _roomsConfig.RoomData
        .ToDictionary(x => x.NameId, x => x);
    }
    
    public RoomData ForRoom(string nameId) => _roomsMap.GetValueOrDefault(nameId);
  }
}