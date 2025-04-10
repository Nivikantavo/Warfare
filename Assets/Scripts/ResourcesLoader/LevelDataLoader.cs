using System.IO;
using UnityEngine;

public class LevelDataLoader
{
    private const string LevelsDataFolderPath = "LevelsData";

    public LevelConfig GetLevelData(int levelIndex)
    {
        string path = Path.Combine(LevelsDataFolderPath, levelIndex.ToString());
        Debug.Log(path);
        return Resources.Load<LevelConfig>(path);
    }
}
