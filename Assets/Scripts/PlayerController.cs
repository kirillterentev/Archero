using UnityEngine;
using System.Collections;

public class PlayerController : GamePerson, IMovable
{
	private Joystick _inputController;
	private IAnimator _animator;
	private AimingController _aimingController;
	private Rigidbody _rb;


	private Vector3 _direction = Vector3.zero;

	private void Start()
	{
		_inputController = (Joystick)StaticContainer.Get(typeof(Joystick));
		_animator = GetComponent<IAnimator>();
		_aimingController = (AimingController)StaticContainer.Get(typeof(AimingController));
		_rb = GetComponent<Rigidbody>();
		SetState(GamePersonState.Idle);
	}

	public override void UpdateState()
	{
		Debug.Log($"{_rb.velocity}");

		switch (_currentState)
		{
			case GamePersonState.Idle:
				_rb.isKinematic = true;
				Idle();
				break;

			case GamePersonState.Move :
				_rb.isKinematic = false;
				Move();
				break;

			case GamePersonState.Attack :
				_rb.isKinematic = true;
				Attack();
				break;

			default : return;
		}
	}

	private void SelectNextState()
	{
		if (_inputController.IsDown())
		{
			SetState(GamePersonState.Move);
			return;
		}

		if (_aimingController.HasEnemies())
		{
			SetState(GamePersonState.Attack);
			return;
		}

		SetState(GamePersonState.Idle);
	}

	public void Idle()
	{
		if (_inputController.IsDown())
		{
			_animator.SetParameterBool(AnimationType.Idle, false);
			SelectNextState();
		}

		if (_aimingController.HasEnemies())
		{
			_animator.SetParameterBool(AnimationType.Idle, false);
			SelectNextState();
		}
	}

	public void Move()
	{
		var direction = _inputController.GetValue();

		_rb.velocity = Vector3.zero;

		if (direction == Vector2.zero)
		{
			_animator.SetParameterBool(AnimationType.Run, false);
			SelectNextState();
			return;
		}

		_direction.x = direction.x;
		_direction.z = direction.y;

		Quaternion lookRotation = Quaternion.LookRotation(_direction);
		_rb.rotation = lookRotation;

		_rb.AddForce(_direction, ForceMode.VelocityChange);
		_animator.SetParameterBool(AnimationType.Run, true);
	}

	public void Attack()
	{
		if (_inputController.IsDown())
		{
			_animator.SetParameterBool(AnimationType.Aim, false);
			SelectNextState();
			return;
		}

		var target = _aimingController.GetTarget();

		if (target != null)
		{
			Quaternion lookRot = Quaternion.LookRotation(target.position - GetPosition());
			transform.rotation = lookRot;
			_animator.SetParameterBool(AnimationType.Aim, true);
		}
		else
		{
			SelectNextState();
		}
	}
}
