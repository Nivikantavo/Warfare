using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : ISaveLoadDataService
{
    public PlayerData PlayerData => _playerData;

    private const string DefaultDataPath = "DefaultData";
    private const string PlayerDataKey = "PlayerData";

    private PlayerData _playerData;

    private void LoadOrCreatePlayerData()
    {
        if(PlayerPrefs.HasKey(PlayerDataKey))
        {
            LoadPlayerData();
        }
        else
        {
            _playerData = LoadDefaultData();
            SavePlayerData();
        }
    }

    private void LoadPlayerData()
    {
        _playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString(PlayerDataKey));
    }

    private void SavePlayerData()
    {
        string json = JsonUtility.ToJson(_playerData);
        PlayerPrefs.SetString(PlayerDataKey, json);
        PlayerPrefs.Save();
    }

    private PlayerData LoadDefaultData()
    {
        DefaultData defaultData = Resources.Load<DefaultData>(DefaultDataPath);

        PlayerData playerData = new PlayerData(
            defaultData.StartGold,
            defaultData.StartUnitsExpAmount,
            defaultData.MaxFuelAmount,
            defaultData.StartFuelAmount,
            new List<string> { defaultData.StartPickedUnit }
        );

        return playerData;
    }
}
