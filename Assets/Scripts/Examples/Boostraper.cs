using UnityEngine;
using UnityEngine.UI;

public class Boostraper : MonoBehaviour
{
    [Header("UI")]

    [SerializeField] private Slider _playerBaseHealthSlider;
    [SerializeField] private Slider _enemyBaseHealthSlider;
    [SerializeField] private Button _spawnButton;
    [SerializeField] private Button _spawnButton2;

    [Space, Header("Objects")]
    [SerializeField] private PlayerUnitsSpawner _spawner;
    [SerializeField] private PlayerBaseData _baseData;
    [SerializeField] private PlayerBase _playerBase;
    [SerializeField] private EnemyBase _enemyBase;


    private void Start()
    {
        _playerBase.Initialize(_baseData);
        _enemyBase.Initialize(_baseData);


        _playerBaseHealthSlider.maxValue = _baseData.HealthConfig.MaxHealth;
        _playerBaseHealthSlider.value = _baseData.HealthConfig.MaxHealth;
        _enemyBaseHealthSlider.maxValue = _baseData.HealthConfig.MaxHealth;
        _enemyBaseHealthSlider.value = _baseData.HealthConfig.MaxHealth;


        _spawnButton.onClick.AddListener(SpawnSolder);
        _spawnButton2.onClick.AddListener(SpawnSityman);
        _playerBase.Health.HealthValueChange += OnPlayerBaseHealthChange;
        _enemyBase.Health.HealthValueChange += OnEnemyBaseHealthChange;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        _spawnButton.onClick.RemoveListener(SpawnSolder);
        _spawnButton2.onClick.RemoveListener(SpawnSityman);
        _playerBase.Health.HealthValueChange -= OnPlayerBaseHealthChange;
        _enemyBase.Health.HealthValueChange -= OnEnemyBaseHealthChange;
    }

    public void SpawnSolder()
    {
        _spawner.Spawn(PlayerUnitType.Solder_1);
    }

    public void SpawnSityman()
    {
        _spawner.Spawn(PlayerUnitType.Sityman_1);
    }

    private void OnEnemyBaseHealthChange(float newValue)
    {
        _enemyBaseHealthSlider.value = newValue;
    }

    private void OnPlayerBaseHealthChange(float newValue)
    {
        _playerBaseHealthSlider.value = newValue;
    }
}
