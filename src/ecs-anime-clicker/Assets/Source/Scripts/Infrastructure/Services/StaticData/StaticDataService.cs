using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Source.Scripts.Configs;
using Source.Scripts.Gameplay.Features.Characters.Configs;
using Source.Scripts.Gameplay.Features.Room.Configs;
using Source.Scripts.Gameplay.Features.Shop.Configs;
using UnityEngine.AddressableAssets;

namespace Source.Scripts.Infrastructure.Services.StaticData
{
  public class StaticDataService : IStaticDataService, IStaticDataLoader 
  {
    private const string GameConfig = "GameConfig";
    private const string RoomsConfig = "RoomsConfig";
    private const string CharactersConfig = "CharactersConfig";
    private const string PurchasesConfig = "PurchasesConfig";
    
    private GameConfig _gameConfig;
    private RoomsConfig _roomsConfig;
    private CharactersConfig _charactersConfig;
    private PurchasesConfig _purchasesConfig;
    
    private Dictionary<string, RoomData> _roomsMap;
    private Dictionary<string, CharacterData> _charactersMap;
    private Dictionary<string, PurchaseData> _purchasesMap;

    public async UniTask Load()
    {
      _gameConfig = await Addressables.LoadAssetAsync<GameConfig>(GameConfig);
      _roomsConfig = await Addressables.LoadAssetAsync<RoomsConfig>(RoomsConfig);
      _charactersConfig = await Addressables.LoadAssetAsync<CharactersConfig>(CharactersConfig);
      _purchasesConfig = await Addressables.LoadAssetAsync<PurchasesConfig>(PurchasesConfig);
      
      _roomsMap = _roomsConfig.RoomData
        .ToDictionary(x => x.NameId, x => x);
      
      _charactersMap = _charactersConfig.CharacterData
        .ToDictionary(x => x.NameId, x => x);
      
      _purchasesMap = _purchasesConfig.PurchasesData
        .ToDictionary(x => x.Id, x => x);
    }
    
    public RoomData ForRoom(string nameId) => _roomsMap.GetValueOrDefault(nameId);
    public CharacterData ForCharacter(string nameId) => _charactersMap.GetValueOrDefault(nameId);
    public PurchaseData ForPurchase(string nameId) => _purchasesMap.GetValueOrDefault(nameId);
  }
}