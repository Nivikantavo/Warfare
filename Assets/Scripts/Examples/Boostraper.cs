using UnityEngine;
using UnityEngine.UI;

public class Boostraper : MonoBehaviour
{
    [SerializeField] private Button _spawnButton;
    [SerializeField] private PlayerUnitsSpawner _spawner;

    private void OnEnable()
    {
        _spawnButton.onClick.AddListener(SpawnSolder);
    }

    private void OnDisable()
    {
        _spawnButton.onClick.RemoveListener(SpawnSolder);
    }

    public void SpawnSolder()
    {
        _spawner.Spawn(PlayerUnitType.Solder_1);
    }
}
