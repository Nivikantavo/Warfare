using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class SaveLoadSystem : ISaveLoadDataService
{
    public PlayerData PlayerData => _playerData;

    private const string PlayerDataKey = "PlayerData";
    private PlayerData _playerData;

    public SaveLoadSystem()
    {
        LoadOrCreatePlayerData();
    }

    private void LoadOrCreatePlayerData()
    {
        if(PlayerPrefs.HasKey(PlayerDataKey))
        {
            _playerData = LoadPlayerData();
        }
        else
        {
            _playerData = LoadDefaultData();
            SavePlayerData();
        }
    }

    private PlayerData LoadPlayerData()
    {
        return JsonConvert.DeserializeObject<PlayerData>(PlayerPrefs.GetString(PlayerDataKey));
    }

    private void SavePlayerData()
    {
        string json = JsonConvert.SerializeObject(_playerData, Formatting.Indented);
        Debug.Log(json);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, PlayerDataKey), json);
        PlayerPrefs.SetString(PlayerDataKey, json);
        PlayerPrefs.Save();
    }

    private PlayerData LoadDefaultData()
    {
        return new PlayerData();
    }
}
