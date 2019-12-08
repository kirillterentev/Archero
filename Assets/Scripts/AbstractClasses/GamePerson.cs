using UnityEngine;

public abstract class GamePerson : MonoBehaviour
{
	protected GamePersonState _currentState;
	protected Transform _transform;

	private void Awake()
	{
		_transform = transform;
	}

	public Vector3 GetPosition()
	{
		return _transform.position;
	}

	public virtual void UpdateState()
	{
		Debug.Log("This is basic class!");
	}

	protected void SetState(GamePersonState newState)
	{
		if (_currentState == newState)
		{
			return;
		}

		_currentState = newState;
	}
}
