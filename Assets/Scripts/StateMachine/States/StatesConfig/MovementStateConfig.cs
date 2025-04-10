using UnityEngine;

[CreateAssetMenu(menuName = "States/MovmentState")]
public class MovementStateConfig : StateConfigSO
{
    public override IState CreateState(Unit unit)
    {
        return new MovmentState(unit);
    }
}
