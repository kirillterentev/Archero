using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerController : GamePerson, IDamageble
{
	[SerializeField]
	private PlayerData _data;
	[SerializeField]
	private PersonIndicator _indicator;

	private Joystick _inputController;
	private IAnimator _animator;
	private AimingController _aimingController;

	private void Start()
	{
		_inputController = (Joystick)StaticContainer.Get(typeof(Joystick));
		_animator = GetComponent<IAnimator>();
		_aimingController = (AimingController)StaticContainer.Get(typeof(AimingController));
		SetState(_states.First(x => x.Name == GamePersonState.Idle));
	}

	public override void UpdateState()
	{
		if (_inputController.IsDown())
		{
			SetState(_states.First(x => x.Name == GamePersonState.Move));
			base.UpdateState();
			return;
		}

		if (_aimingController.HasEnemies())
		{
			SetState(_states.First(x => x.Name == GamePersonState.Attack));
			base.UpdateState();
			return;
		}

		SetState(_states.First(x => x.Name == GamePersonState.Idle));
		base.UpdateState();
	}

	protected override void SetState(PersonState newState)
	{
		base.SetState(newState);

		_animator.SetParameterBool(AnimationType.Run, newState.Name == GamePersonState.Move);
		_animator.SetParameterBool(AnimationType.Aim, newState.Name == GamePersonState.Attack);
		_animator.SetParameterBool(AnimationType.Idle, newState.Name == GamePersonState.Idle);
		_animator.SetParameterTrigger(AnimationType.Shoot, false);
	}

	public void TakeDamage(int damage)
	{
		_data.health -= damage;
		if (_data.health <= 0)
		{
			_data.health = 0;
		}

		_indicator.UpdateValue(_data.health / _data.maxHealth);
	}
}
