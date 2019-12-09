using UnityEngine;
using System.Collections;

public class Keyboard : MonoBehaviour, Joystick
{
	private bool _inUse = false;
	private bool _checkFrame = false;
	private Vector2 _previousDirection = Vector2.zero;
	private Vector2 _direction = Vector2.zero;

	private void Awake()
	{
		StaticContainer.Add(typeof(Joystick), this);
	}

	public Vector2 GetValue()
	{
		_previousDirection = _direction;

		if (_previousDirection != Vector2.zero)
		{
			_inUse = true;
		}
		else
		{
			_inUse = false;
		}

		if (_checkFrame)
		{
			_checkFrame = false;
		}

		var horizontalAxis = Input.GetAxis("Horizontal");
		var verticalAxis = Input.GetAxis("Vertical");
		_direction.x = horizontalAxis;
		_direction.y = verticalAxis;

		if (_inUse && _direction == Vector2.zero && !_checkFrame)
		{
			_checkFrame = true;
			return _previousDirection.normalized;
		}

		return _direction.normalized;
	}

	public bool IsDown()
	{
		return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
	}
}
