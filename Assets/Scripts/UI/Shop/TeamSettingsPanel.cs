using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TeamSettingsPanel : MonoBehaviour
{
    [SerializeField] private List<UnitShopItemConfig> _shopItems;
    [SerializeField] private UnitsUpgradeCostConfig _upgradeCostConfig;

    [SerializeField] private UnitCardView _cardTemplate;

    [SerializeField] private Transform _deckContainer;
    [SerializeField] private Transform _availableCollectionContainer;
    [SerializeField] private Transform _lockedCollectionContainer;

    private List<UnitCardView> _cards;

    private SaveLoadSystem _saveLoadSystem;

    [Inject]
    private void Construct(SaveLoadSystem saveLoadSystem)
    {
        _saveLoadSystem = saveLoadSystem;
        Initialize(_saveLoadSystem.PlayerData.CurrentPlayerDeck, _saveLoadSystem.PlayerData.UnlockedUnitsData, _saveLoadSystem.PlayerData.PurchasedItemsData);
    }

    public void Initialize(List<string> currentPlayerDeck, List<string> unlockedItems, List<string> boughtItems, Dictionary<string, int> boughtUpgrades)
    {
        SpawnShopItemsCards(currentPlayerDeck, unlockedItems, boughtItems, boughtUpgrades);
    }

    private void SpawnShopItemsCards(List<string> currentPlayerDeck, List<string> unlockedItems, List<string> boughtItems, Dictionary<string, int> boughtUpgrades)
    {
        SpawnDeckCard(currentPlayerDeck, boughtUpgrades);
        SpawnUnlockedItems(boughtItems, boughtUpgrades);
        SpawnLockedItems(unlockedItems);
    }

    private void SpawnDeckCard(List<string> currentPlayerDeck, Dictionary<string, int> boughtUpgrades)
    {
        for(int i = 0; i < currentPlayerDeck.Count; i++)
        {
            //_shopItems.First(item => )
        }
    }

    private void SpawnUnlockedItems(List<string> unlockedItems, Dictionary<string, int> boughtUpgrades)
    {

    }

    private void SpawnLockedItems(List<string> unlockedItems)
    {

    }

    private void CreateShopItemsList()
    {
        for (int i = 0; i < _shopItems.Count; i++)
        {
            
        }
    }
}
