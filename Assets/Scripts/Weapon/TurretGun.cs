using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : AbstractWeapon
{
	public override void Shoot(Vector3 target)
	{
		Instantiate<AbstractShell>(_shell, _shootPoint.position, transform.rotation).Shoot(target);
	}
}
