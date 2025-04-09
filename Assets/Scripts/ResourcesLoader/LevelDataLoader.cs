using System.IO;
using UnityEngine;

public class LevelDataLoader
{
    private const string LevelsDataFolderPath = "LevelsData";

    public LevelData GetLevelData(int levelIndex)
    {
        string path = Path.Combine(LevelsDataFolderPath, levelIndex.ToString());
        Debug.Log(path);
        return Resources.Load<LevelData>(path);
    }
}
