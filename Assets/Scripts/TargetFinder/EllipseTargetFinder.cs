using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EllipseTargetFinde : MonoBehaviour, ITargetFinder
{
	[SerializeField] private Transform _finderCastPoint;
	[SerializeField] private int _raycastCount;
	[SerializeField] private float _maxDistance;
	private float _angle;
	
	private ITarget _target;
	
	public EllipseTargetFinde(Transform finderCastPoint)
	{
		_finderCastPoint = finderCastPoint;
	}

	public List<T> Find<T>() where T : ITarget
	{
		List<T> targets = new List<T>();
		_angle = 0;
		for(int i = 0; i < _raycastCount; i++)
		{
			
			
			//var x = Mathf.Sin(_angle) * 2;
			//var y = Mathf.Cos(_angle) * 2;
			//_angle += 360 / _raycastCount;
			
			//var ray = new Ray(_finderCastPoint.position, new Vector3(x, y, 0));
			//Debug.DrawRay(ray.origin, ray.direction, Color.red, 10);
			//if(Physics.Raycast(ray, out var hit, _maxDistance))
			
			
			if(Physics.Raycast(_finderCastPoint.position, _finderCastPoint.forward, out var hit, _maxDistance))
			{
				var target = hit.collider.GetComponent<T>();
				if(target != null)
				{
					targets.Add(target);
				}
			}
		}
		
		T cloasestTarget = targets.Count > 0 ? targets[0] : default;
		foreach(var target in targets)
		{
			if(Vector3.Distance(target.Position, _finderCastPoint.position) < Vector3.Distance(cloasestTarget.Position, _finderCastPoint.position))
			{
				cloasestTarget = target;
			}
		}
		
		return targets;
	}
	
	public int rayCount = 20;  // Количество лучей
	public float minLength = 1f;  // Начальная длина луча
	public float maxLength = 5f;  // Максимальная длина луча
	public float ellipseA = 3f;  // Длина полуоси по X
	public float ellipseB = 1.5f;  // Длина полуоси по Z

	void Update()
	{
		Vector3 startPosition = transform.position;
		Vector3 forward = transform.forward;

		for (int i = 0; i < rayCount; i++)
		{
			float angle = (float)i / rayCount * Mathf.PI; // Угол от 0 до 2π
			float lengthFactor = (float)i / (rayCount - 1);  // От 0 до 1
			float rayLength = Mathf.Lerp(maxLength, minLength, lengthFactor); // Увеличение длины

			// Создаём эллиптические смещения
			float x = Mathf.Cos(angle) * ellipseA;
			float y = Mathf.Sin(angle) * ellipseB;

			Vector3 direction = (forward + new Vector3(x, y, 0)).normalized; // Смещение направления
			Ray ray = new Ray(startPosition, direction);

			if (Physics.Raycast(ray, out RaycastHit hit, rayLength))
			{
				Debug.DrawLine(startPosition, hit.point, Color.red);
			}
			else
			{
				Debug.DrawLine(startPosition, startPosition + direction * rayLength, Color.green);
			}
		}
	}
}