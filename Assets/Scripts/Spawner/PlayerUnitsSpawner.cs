using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class PlayerUnitsSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    private UnitsFactory _unitsFactory;
    private ShopUpgradeData _upgradeData;

    [Inject]
    private void Construct(UnitsFactory enemyFactory, ShopUpgradeData upgradeData)
    {
        _unitsFactory = enemyFactory;
        _upgradeData = upgradeData;
    }

    public void Spawn(PlayerUnitType selectedUnitType)
    {
        Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;

        Unit enemy = _unitsFactory.GetPlayerUnit(selectedUnitType, spawnPosition, _upgradeData);
    }
}
