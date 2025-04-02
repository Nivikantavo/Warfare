using UnityEngine;

public class PlayerBase : UnitsBase, IEnemyTarget
{
    public Vector3 Position => transform.position;

    public GameObject GameObject => gameObject;

    public Health Health { get; protected set; }

    public void Initialize(PlayerBaseData baseData)
    {
        Health = new Health(baseData.HealthConfig.MaxHealth);
    }
}
