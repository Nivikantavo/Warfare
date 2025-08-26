using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PurchasedItemsData
{
    public IReadOnlyList<string> BoughtItems => _boughtItemsID;
    public IReadOnlyDictionary<string, int> UpgradedItemsLevels => _upgradedItemsLevels;

    private List<string> _boughtItemsID;
    private Dictionary<string, int> _upgradedItemsLevels;

    public PurchasedItemsData(string startUnlockedUnitID)
    {
        Debug.Log(startUnlockedUnitID);
        _boughtItemsID = new List<string>() { startUnlockedUnitID };
        _upgradedItemsLevels = new Dictionary<string, int>() { { startUnlockedUnitID, 0 } };
    }
}
