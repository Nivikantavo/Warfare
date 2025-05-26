using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerDeck
{
    public IReadOnlyList<string> CurrentPickedUnits => _currentPickedUnits;

    private List<string> _currentPickedUnits;
}
