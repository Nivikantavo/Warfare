using System;
using System.Collections.Generic;

[Serializable]
public class OwnedCharacterData
{
    public string UnitId;
    public int CurrentLevel;
    public List<StatModifier> UnlockedArtifacts;
}
