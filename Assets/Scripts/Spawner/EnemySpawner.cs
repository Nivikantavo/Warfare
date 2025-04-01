using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;
    private UnitsFactory _enemyFactory;

    private Coroutine _spawn;

    [Inject]
    private void Construct(UnitsFactory enemyFactory)
    {
        Debug.Log("Construct");
        _enemyFactory = enemyFactory;
    }

    private void Start()
    {
        StartWork();
    }

    public void StartWork()
    {
        StopWork();

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
        while (true)
        {
            EnemyUnitType selectedEnemyType = (EnemyUnitType)Random.Range(0, Enum.GetValues(typeof(EnemyUnitType)).Length - 1);
            Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;

            Unit enemy = _enemyFactory.Get(selectedEnemyType, spawnPosition);

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}
