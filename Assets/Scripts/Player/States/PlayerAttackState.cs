using UnityEngine;
using System.Collections;

public class PlayerAttackState : AbstractState
{
	[SerializeField]
	private GamePerson _person;
	[SerializeField]
	private AbstractWeapon _weapon;

	private IAnimator _animator;
	private AimingController _aimingController;
	private float _timer = 0;

	private void Start()
	{
		_aimingController = (AimingController)StaticContainer.Get(typeof(AimingController));
		_animator = GetComponent<IAnimator>();
	}

	public override void Action()
	{
		var target = _aimingController.GetTarget();

		if (target != null)
		{
			Quaternion lookRot = Quaternion.LookRotation(target.position - _person.GetPosition());
			transform.rotation = lookRot;
			_animator.SetParameterBool(AnimationType.Aim, true);

			_timer += Time.deltaTime;
			if (_timer > 1)
			{
				_animator.SetParameterTrigger(AnimationType.Shoot, true);
				_weapon.Shoot(target.position);
				_timer = 0;
			}
		}
	}
}
