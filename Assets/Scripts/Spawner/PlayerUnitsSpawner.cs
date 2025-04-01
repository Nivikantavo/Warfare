using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class PlayerUnitsSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    private UnitsFactory _unitsFactory;

    [Inject]
    private void Construct(UnitsFactory enemyFactory)
    {
        Debug.Log("Construct");
        _unitsFactory = enemyFactory;
    }

    public void Spawn(PlayerUnitType selectedUnitType)
    {
        Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;

        Unit enemy = _unitsFactory.Get(selectedUnitType, spawnPosition);
    }
}
