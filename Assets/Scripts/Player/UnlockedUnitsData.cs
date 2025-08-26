using System;
using System.Collections.Generic;

[Serializable]
public class UnlockedUnitsData
{
    public IReadOnlyList<string> UnlockedUnitsID => _unlockedUnitsID;

    private List<string> _unlockedUnitsID;

    public UnlockedUnitsData(string startUnlockedUnitID)
    {
        _unlockedUnitsID = new List<string>() { startUnlockedUnitID };
    }
}
