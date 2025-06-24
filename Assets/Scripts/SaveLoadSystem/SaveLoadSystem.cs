using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    private const string DefaultDataPath = "DefaultData";

    private PlayerData _playerData;

    private void LoadOrCreatePlayerData()
    {

    }

    private void LoadDefaultData()
    {
        DefaultData defaultData = Resources.Load<DefaultData>(DefaultDataPath);
    }
}
