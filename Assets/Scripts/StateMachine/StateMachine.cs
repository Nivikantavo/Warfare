using System;
using System.Collections.Generic;
using System.Linq;

public class StateMachine
{
	private List<IState> _states;
	private IState _currentState;

	public StateMachine()
	{
		/*
		StateMachineData data = new StateMachineData();

		_states = new List<IState>()
		{
			new IdleState(this, data, character),
			new RunningState(this, data, character),
		};
		*/
		_currentState = _states[0];
		_currentState.Enter();
	}

	public void SwitchStat<T>() where T : IState
	{
		IState state = _states.FirstOrDefault(state => state is T);

		if(state == null)
		{
			throw new ArgumentException($"State of type {typeof(T)} not found");
		}

		_currentState.Exit();
		_currentState = state;
		_currentState.Enter();
	}

	public void HandleInput() => _currentState.HandleInput();

	public void Update() => _currentState.Update();
}
