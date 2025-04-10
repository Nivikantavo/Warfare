using UnityEngine;

[CreateAssetMenu(menuName = "States/AttackState")]
public class AttackStateConfig : StateConfigSO
{
    public override IState CreateState(Unit unit)
    {
        return new AttackState(unit);
    }
}
