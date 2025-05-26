using System.Collections.Generic;
using UnityEngine;

public class PurchasedItemsData
{
    public IReadOnlyList<string> BoughtItems => _boughtItemsID;
    public IReadOnlyDictionary<string, int> UpgradedItemsLevels => _upgradedItemsLevels;

    private List<string> _boughtItemsID;
    private Dictionary<string, int> _upgradedItemsLevels;
}
