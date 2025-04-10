using UnityEngine;

[CreateAssetMenu(menuName = "States/StartIdleState")]
public class StartIdleStateConfig : StateConfigSO
{
    public override IState CreateState(Unit unit)
    {
        return new StartIdleState(unit);
    }
}
