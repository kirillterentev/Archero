using UnityEngine;
using System.Collections;

public class EnemyAttackState_Turret : AbstractState
{
	[SerializeField]
	private GamePerson _person;
	[SerializeField]
	private AbstractWeapon _weapon;

	private AimingController _aimingController;
	private float _timer = 0;

	private void Start()
	{
		_aimingController = (AimingController)StaticContainer.Get(typeof(AimingController));
	}

	public override void Action()
	{
		var target = _aimingController.GetMainPlayer();

		if (target != null)
		{
			Quaternion lookRot = Quaternion.LookRotation(target.position - _person.GetPosition());
			_weapon.transform.rotation = lookRot;

			_timer += Time.deltaTime;
			if (_timer > 5)
			{
				_weapon.Shoot(target.position);
				_timer = 0;
			}
		}
	}
}
