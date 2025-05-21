using UnityEngine;

public class ArtefactStatModifier : StatModifier
{
    public ArtefactStatModifier(StatType statType, float value)
    {
        Value = value;
        TypeOfStat = statType;
    }

    public override float ApplyModifier(float currentValue)
    {
        return currentValue + Value;
    }
}
