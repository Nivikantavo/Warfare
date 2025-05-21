using System;

[Serializable]
public abstract class StatModifier
{
    public StatType TypeOfStat;
    public float Value;
    public int Level;

    public abstract float ApplyModifier(float currentValue);
}


public enum StatType
{
    Health,
    Damage,
    AttackSpeed,
    MoveSpeed,
}
