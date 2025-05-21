using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Transform> _preSpawnPoints;

    private UnitsFactory _enemyFactory;
    private ShopUpgradeData _shopUpgradeData;

    private List<Wave> _waves;
    private List<Wave> _preSpawnUnits;

    private Coroutine _spawn;

    [Inject]
    private void Construct(UnitsFactory enemyFactory, LevelConfig levelConfig, ShopUpgradeData shopUpgradeData)
    {
        _waves = levelConfig.Waves;
        _preSpawnUnits = levelConfig.PreSpawnedWave;
        _shopUpgradeData = shopUpgradeData;
        _enemyFactory = enemyFactory;
    }

    private void Start()
    {
        StartWork();
    }

    public void StartWork()
    {
        StopWork();
        PreSpawnStartUnits();
        _spawn = StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
        {
            StopCoroutine(_spawn);
        }
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < _waves.Count; i++)
        {
            for (int j = 0; j < _waves[i].UnitsCount; j++)
            {
                Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;

                _enemyFactory.GetEnemyUnit(_waves[i].SpawnedUnit, spawnPosition, _shopUpgradeData);

                yield return new WaitForSeconds(_waves[i].DelayBetweenSpawn);
            }

            yield return new WaitForSeconds(_waves[i].DelayAfterWave);
        }
    }

    private void PreSpawnStartUnits()
    {
        if(_preSpawnUnits == null)
            return;

        RuntimeContext runtimeContext = new RuntimeContext(true);

        for (int i = 0; i < _preSpawnUnits.Count; i++)
        {
            for (int j = 0; j < _preSpawnUnits[i].UnitsCount; j++)
            {
                Vector3 spawnPosition = _preSpawnPoints[Random.Range(0, _preSpawnPoints.Count)].position;

                _enemyFactory.GetEnemyUnit(_preSpawnUnits[i].SpawnedUnit, spawnPosition, _shopUpgradeData, runtimeContext);
            }
        }
    }
}
