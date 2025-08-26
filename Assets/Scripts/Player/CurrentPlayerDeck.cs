using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class CurrentPlayerDeck
{
    public IReadOnlyList<string> CurrentPickedUnits => _currentPickedUnits;

    private List<string> _currentPickedUnits;

    public CurrentPlayerDeck(List<string> currentPickedUnits)
    {
        if (currentPickedUnits.Count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(currentPickedUnits));
        }

        foreach (var unit in currentPickedUnits)
        {
            if (string.IsNullOrEmpty(unit))
                throw new NullReferenceException(nameof(unit));
        }

        _currentPickedUnits = currentPickedUnits;
    }
}
