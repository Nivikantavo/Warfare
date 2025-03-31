using System.Collections.Generic;
using UnityEngine;

public interface ITargetFinder
{
    public List<T> Find<T>(LayerMask layerMask) where T : ITarget;
    public T GetNearestTarget<T>() where T : ITarget;
}