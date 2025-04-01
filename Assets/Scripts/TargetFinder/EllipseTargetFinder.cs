using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EllipseTargetFinder : ITargetFinder
{
    private const float EllipseA = 3;
    private const float EllipseB = 1;

    private Transform _finderCastPoint;
	
    private int _rayCount;
    private float _minLength;
    private float _maxLength;
    
    private LayerMask _layerMask;
    private Vector3 _forvard;
    private FinderData _finderData;

    public EllipseTargetFinder(Transform finderCastPoint, FinderData finderData)
	{
		_finderCastPoint = finderCastPoint;
        _finderData = finderData;
        _rayCount = _finderData.RayCount;
        _maxLength = _finderData.MaxDistance;
        _minLength = _finderData.MinDistance;
        _layerMask = _finderData.LayerMask;
        _forvard = _finderData.Direction;
    }

    public List<T> Find<T>(LayerMask layerMask) where T : ITarget
    {
        HashSet<T> reusableTargets = new HashSet<T>();
        
        Vector3 startPosition = _finderCastPoint.position;
        float angleStep = 2 * Mathf.PI / _rayCount;

        RaycastHit2D[] hits = new RaycastHit2D[_rayCount];

        for (int i = -_rayCount; i < _rayCount; i++)
        {
            float angle = i * angleStep;
            float lengthFactor = Mathf.Abs((i * i) / (_rayCount - 1));
            float rayLength = Mathf.Lerp(_maxLength, _minLength, lengthFactor);

            float x = Mathf.Cos(angle) * EllipseA * _finderData.Direction.x;
            float y = Mathf.Sin(angle) * EllipseB * _finderData.Direction.x;
            Vector3 direction = (_forvard + new Vector3(x, y, 0)).normalized;

            Debug.DrawLine(startPosition, startPosition + direction * rayLength, Color.green);

            int hitCount = Physics2D.RaycastNonAlloc(startPosition, direction, hits, rayLength, layerMask);
            for (int j = 0; j < hitCount; j++)
            {
                Debug.DrawLine(startPosition, startPosition + direction * rayLength, Color.red);
                if (hits[j].collider.TryGetComponent<T>(out var target))
                {
                    if(target.GameObject != _finderCastPoint.gameObject)
                        reusableTargets.Add(target);
                }
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