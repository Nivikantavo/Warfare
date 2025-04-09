using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCell : Cell
{
    public event Action<int> LevelCellInteract;

    [SerializeField] private int _levelIndex;

    protected override void Interact()
    {
        SelectLevel();
    }

    private void SelectLevel()
    {
        LevelCellInteract?.Invoke(_levelIndex);
    }
}
