using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EllipseTargetFinde : MonoBehaviour, ITargetFinder
{
	[SerializeField] private Transform _finderCastPoint;
	
	private List<ITarget> _targets;
    private ITarget _target;

    [SerializeField] private int _rayCount;
    [SerializeField] private float _minLength;
    [SerializeField] private float _maxLength;
    [SerializeField] private float _ellipseA;
    [SerializeField] private float _ellipseB;
    [SerializeField] private LayerMask _layerMask;

    public EllipseTargetFinde(Transform finderCastPoint)
	{
		_finderCastPoint = finderCastPoint;
	}

    public Vector3 Position => throw new System.NotImplementedException();

    //public List<T> Find<T>() where T : ITarget
    //{
    //	List<T> targets = new List<T>();

    //       Vector3 startPosition = transform.position;
    //       Vector3 forward = transform.forward;

    //       for (int i = -_rayCount; i < _rayCount; i++)
    //	{
    //           float angle = (float)i / _rayCount * Mathf.PI * 2;
    //           float lengthFactor = Mathf.Abs((float)(i * i) / (_rayCount - 1));
    //           float rayLength = Mathf.Lerp(_maxLength, _minLength, lengthFactor);

    //           float x = Mathf.Cos(angle) * _ellipseA;
    //           float y = Mathf.Sin(angle) * _ellipseB;

    //           Vector3 direction = (forward + new Vector3(x, y, 0)).normalized;
    //           Ray ray = new Ray(startPosition, direction);
    //           Debug.DrawLine(startPosition, startPosition + direction * rayLength, Color.green);
    //           if (Physics.Raycast(_finderCastPoint.position, direction, out var hit, _maxLength))
    //		{
    //               if(hit.collider.TryGetComponent<T>(out var target))
    //			{
    //                   if (targets.Contains(target) == false)
    //                   {
    //                       Debug.DrawLine(startPosition, hit.point, Color.red);
    //                       targets.Add(target);
    //                   }
    //               }
    //		}
    //	}

    //	return targets;
    //}


    public List<T> Find<T>(LayerMask layerMask) where T : ITarget
    {
        HashSet<T> reusableTargets = new HashSet<T>();
        
        Vector3 startPosition = transform.position;
        Vector3 forward = transform.forward;
        float angleStep = 2 * Mathf.PI / _rayCount;

        RaycastHit2D[] hits = new RaycastHit2D[10];

        for (int i = -_rayCount; i < _rayCount; i++)
        {
            float angle = i * angleStep;
            float lengthFactor = Mathf.Abs((i * i) / (_rayCount - 1f));
            float rayLength = Mathf.Lerp(_maxLength, _minLength, lengthFactor);

            float x = Mathf.Cos(angle) * _ellipseA;
            float y = Mathf.Sin(angle) * _ellipseB;
            Vector3 direction = (forward + new Vector3(x, y, 0)).normalized;

            Debug.DrawLine(startPosition, startPosition + direction * rayLength, Color.green);

            int hitCount = Physics2D.RaycastNonAlloc(startPosition, direction, hits, _maxLength, layerMask);
            for (int j = 0; j < hitCount; j++)
            {
                Debug.DrawLine(startPosition, startPosition + direction * rayLength, Color.red);
                if (hits[j].collider.TryGetComponent<T>(out var target))
                {
                    if(target.GameObject != gameObject)
                        reusableTargets.Add(target);
                }
            }
        }

        return reusableTargets.ToList();
    }

    private void FixedUpdate()
    {
        _targets = Find<ITarget>(_layerMask);
        if( _targets != null)
        {
            if( _targets.Count > 0)
            {
                _target = _targets[0];
                Debug.Log(_target);
            }
        }
    }
}