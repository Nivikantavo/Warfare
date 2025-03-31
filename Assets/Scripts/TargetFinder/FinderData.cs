using System;
using UnityEngine;

[Serializable]
public class FinderData
{
    [field: SerializeField] public int RayCount { get; private set; }
    [field: SerializeField] public float MinDistance { get; private set; }
    [field: SerializeField] public float MaxDistance { get; private set; }
    [field: SerializeField] public LayerMask LayerMask { get; private set; }

    [field: SerializeField] private StartDirection FindDirection;

    public Vector2 Direction
    {
        get
        {
            switch (FindDirection)
            {
                case StartDirection.Left:
                    return Vector2.left;
                case StartDirection.Right:
                    return Vector2.right;
                default:
                    throw new NotImplementedException(nameof(StartDirection));
            }
        }
    }
}
