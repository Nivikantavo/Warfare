using UnityEngine;

public class LevelStatModifire : StatModifier
{
    private const float LevelStatModifireCoefficient = 1.042f;

    public LevelStatModifire(int level, StatType statType)
    {
        Level = level;
        TypeOfStat = statType;
    }

    public override float ApplyModifier(float currentValue)
    {
        return Mathf.RoundToInt(currentValue * Mathf.Pow(LevelStatModifireCoefficient, Level));
    }
}
