using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelsInstaller : MonoInstaller
{
    [field: SerializeField] public List<LevelData> LevelLoadingDatas { get; private set; }
}
