using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ForvardTargetFinder : ITargetFinder
{
    private Transform _finderCastPoint;

    private float _rayLength;

    private LayerMask _layerMask;
    private Vector3 _forvard;
    private FinderData _finderData;

    public ForvardTargetFinder(Transform finderCastPoint, FinderData finderData)
    {
        _finderCastPoint = finderCastPoint;
        _finderData = finderData;

        _rayLength = _finderData.MaxDistance;
        _layerMask = _finderData.LayerMask;
        _forvard = _finderData.Direction;
    }

    public List<T> Find<T>(LayerMask layerMask) where T : ITarget
    {
        HashSet<T> reusableTargets = new HashSet<T>();

        Vector3 startPosition = _finderCastPoint.position;

        RaycastHit2D[] hits = new RaycastHit2D[5];

        int hitCount = Physics2D.RaycastNonAlloc(startPosition, _forvard, hits, _rayLength, layerMask);
        for (int j = 0; j < hitCount; j++)
        {
            Debug.DrawLine(startPosition, startPosition + _forvard * _rayLength, Color.red);
            if (hits[j].collider.TryGetComponent<T>(out var target))
            {
                if (target.GameObject != _finderCastPoint.gameObject)
                    reusableTargets.Add(target);
            }
        }

        return reusableTargets.ToList();
    }

    public T GetNearestTarget<T>() where T : ITarget
    {
        var targets = Find<T>(_layerMask);
        T resultTarget = default;

        if (targets != null && targets.Count > 0)
        {
            resultTarget = targets[0];
            foreach (var target in targets)
            {
                if (Vector3.Distance(_finderCastPoint.position, target.Position) < Vector3.Distance(_finderCastPoint.position, target.Position))
                {
                    resultTarget = target;
                }
            }
        }

        return resultTarget;
    }
}
