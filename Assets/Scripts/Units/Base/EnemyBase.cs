using UnityEngine;

public class EnemyBase : UnitsBase, IPlayerTarget
{
    public Vector3 Position => transform.position;

    public GameObject GameObject => gameObject;

    public Health Health { get; protected set; }

    public void Initialize(PlayerBaseData baseData)
    {
        Health = new Health(baseData.HealthConfig.MaxHealth);
    }
}
