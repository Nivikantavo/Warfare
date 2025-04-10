using System;
using UnityEngine;

[Serializable]
public class MovmentStateData
{
    [field: SerializeField] public float Speed {  get; private set; }
    [field: SerializeField] public float StopingDistance { get; private set; }

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
