using System;
using UnityEngine;

public class UnitStats
{
    [field: SerializeField] public float Damage { get; set; }
    [field: SerializeField] public float AttackCooldown { get; set; }
    [field: SerializeField, Range(1, 2)] public float AttackSpeed { get; set; }
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField] public float StopingDistance { get; set; }
    [field: SerializeField] public FinderData FinderData { get; set; }
    [field: SerializeField] public float MaxHealth { get; set; }

    [field: SerializeField] private StartDirection Direction;
    public Vector2 StartDirection
    {
        get
        {
            switch (Direction)
            {
                case global::StartDirection.Left:
                    return Vector2.left;
                case global::StartDirection.Right:
                    return Vector2.right;
                default:
                    throw new NotImplementedException(nameof(StartDirection));
            }
        }
    }
}
