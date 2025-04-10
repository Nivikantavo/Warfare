using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateAssembler
{
    public List<IState> AssembleStates(Unit unit, UnitDataConfig config, RuntimeContext context = null)
    {
        var states = new List<IState>();

        if (context != null)
        {
            if (context.PreSpawned)
            {
                states.Add(new StartIdleState(unit));
            }
        }

        states.AddRange(config.States.Select(s => s.CreateState(unit)));
        Debug.Log("STATES COUNT: " + states.Count);
        return states;
    }
}
