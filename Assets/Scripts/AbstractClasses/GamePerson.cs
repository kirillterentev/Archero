using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PersonState
{
	public GamePersonState Name;
	public AbstractState State;
}

public abstract class GamePerson : MonoBehaviour
{
	[SerializeField]
	protected List<PersonState> _states;
	[SerializeField]
	protected Transform _transform;
	[SerializeField]
	protected Rigidbody _rb;

	protected PersonState _currentState;
	
	public Vector3 GetPosition()
	{
		return _transform.position;
	}

	public virtual void UpdateState()
	{
		switch (_currentState.Name)
		{
			case GamePersonState.Idle:
				_rb.isKinematic = true;
				break;

			case GamePersonState.Move:
				_rb.isKinematic = false;
				break;

			case GamePersonState.Attack:
				_rb.isKinematic = true;
				break;

			default: return;
		}

		_currentState.State.Action();
	}

	protected virtual void SetState(PersonState newState)
	{
		if (_currentState == newState)
		{
			return;
		}

		_currentState = newState;
	}
}
