using UnityEngine;

public interface ITarget
{
    public Vector3 Position { get; }
    public GameObject GameObject { get; }
    public Health Health { get; }
}
