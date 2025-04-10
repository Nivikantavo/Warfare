using UnityEngine;

[CreateAssetMenu(menuName = "States/DelayIdleState")]
public class DelayIdleStateConfig : StateConfigSO
{
    public override IState CreateState(Unit unit)
    {
        return new DelayIdleState(unit);
    }
}
