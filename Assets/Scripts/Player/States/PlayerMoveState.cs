using UnityEngine;
using System.Collections;

public class PlayerMoveState : AbstractState
{
	[SerializeField]
	private Rigidbody _rb;

	private Joystick _inputController;
	private IAnimator _animator;
	private Vector3 _direction;

	private void Start()
	{
		_inputController = (Joystick)StaticContainer.Get(typeof(Joystick));
		_animator = GetComponent<IAnimator>();
		_direction = Vector3.zero;
	}

	public override void Action()
	{
		var direction = _inputController.GetValue();

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
