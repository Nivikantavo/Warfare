using UnityEngine;

public abstract class StateConfigSO : ScriptableObject
{
    public abstract IState CreateState(Unit unit);
}