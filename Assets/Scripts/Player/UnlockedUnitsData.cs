using System.Collections.Generic;
using UnityEngine;

public class UnlockedUnitsData
{
    public IReadOnlyList<string> UnlockedUnitsID => _unlockedUnitsID;

    private List<string> _unlockedUnitsID;
}
