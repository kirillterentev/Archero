using UnityEngine;
using System.Collections;

public class PlayerController : GamePerson, IMovable
{
	private Joystick _inputController;
	private IAnimator _animator;
	private Rigidbody _rb;

	private Vector3 _direction = Vector3.zero;

	private void Start()
	{
		_inputController = (Joystick)StaticContainer.Get(typeof(Joystick));
		_animator = GetComponent<IAnimator>();
		_rb = GetComponent<Rigidbody>();
	}

	public override void UpdateState()
	{
		var direction = _inputController.GetValue();
		Move(direction);
	}

	public void Move(Vector2 direction)
	{
		_rb.velocity = Vector3.zero;

		if (direction == Vector2.zero)
		{
			_animator.SetParameterBool(AnimationType.Run, false);
			return;
		}

		_direction.x = direction.x;
		_direction.z = direction.y;

		Quaternion lookRotation = Quaternion.LookRotation(_direction);
		_rb.rotation = lookRotation;

		_rb.AddForce(_direction, ForceMode.VelocityChange);
		_animator.SetParameterBool(AnimationType.Run, true);
	}
}
