using UnityEngine;

[CreateAssetMenu(menuName = "States/DieState")]
public class DieStateConfig : StateConfigSO
{
    public override IState CreateState(Unit unit)
    {
        return new DieState(unit);
    }
}
