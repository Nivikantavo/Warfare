using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TeamSettingsPanel : UIPanel
{
    [SerializeField] private List<UnitShopItemConfig> _shopItems;
    [SerializeField] private UnitsUpgradeCostConfig _upgradeCostConfig;

    [SerializeField] private UnitCardView _cardTemplate;

    [SerializeField] private Transform _deckContainer;
    [SerializeField] private Transform _availableCollectionContainer;
    [SerializeField] private Transform _lockedCollectionContainer;

    private List<UnitCardView> _cards = new List<UnitCardView>();

    private SaveLoadSystem _saveLoadSystem;

    [Inject]
    private void Construct(SaveLoadSystem saveLoadSystem)
    {
        _saveLoadSystem = saveLoadSystem;

        Dictionary<string, int> boughtUpgrades = new Dictionary<string, int>();
        if (_saveLoadSystem.PlayerData.PurchasedItemsData.UpgradedItemsLevels.Count > 0)
        {
            boughtUpgrades = _saveLoadSystem.PlayerData.PurchasedItemsData.UpgradedItemsLevels.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        
        Initialize(_saveLoadSystem.PlayerData.CurrentPlayerDeck.CurrentPickedUnits.ToList(), _saveLoadSystem.PlayerData.UnlockedUnitsData.UnlockedUnitsID.ToList(), _saveLoadSystem.PlayerData.PurchasedItemsData.BoughtItems.ToList(), boughtUpgrades);
    }

    public void Initialize(List<string> currentPlayerDeck, List<string> unlockedItems, List<string> boughtItems, Dictionary<string, int> boughtUpgrades)
    {
        SpawnShopItemsCards(currentPlayerDeck, unlockedItems, boughtItems, boughtUpgrades);
    }

    private void SpawnShopItemsCards(List<string> currentPlayerDeck, List<string> unlockedItems, List<string> boughtItems, Dictionary<string, int> boughtUpgrades)
    {
        SpawnDeckCard();
        SortUnlockedItems(unlockedItems);
        SortCurrentDeckItems(currentPlayerDeck);
    }

    private void SpawnDeckCard()
    {
        for(int i = 0; i < _shopItems.Count; i++)
        {
            var card = Instantiate(_cardTemplate, _lockedCollectionContainer);
            card.Initialize(_shopItems[i]);

            _cards.Add(card);
        }
    }

    private void SortUnlockedItems(List<string> unlockedItems)
    {
        for (int i = 0; i < unlockedItems.Count; i++)
        {
            if(_cards.Any(card => card.UnitID == unlockedItems[i]))
            {
                _cards.FirstOrDefault(card => card.UnitID == unlockedItems[i]).transform.SetParent(_availableCollectionContainer);
            }
        }
    }

    private void SortCurrentDeckItems(List<string> currentPlayerDeck)
    {
        for (int i = 0; i < currentPlayerDeck.Count; i++)
        {
            if(_cards.Any(card => card.UnitID == currentPlayerDeck[i]))
            {
                _cards.FirstOrDefault(card => card.UnitID == currentPlayerDeck[i]).transform.SetParent(_deckContainer);
            }
        }
    }
}
