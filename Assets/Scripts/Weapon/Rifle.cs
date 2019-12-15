using UnityEngine;
using System.Collections;

public class Rifle : AbstractWeapon
{
	public override void Shoot(Vector3 target)
	{
		Instantiate<AbstractShell>(_shell, _shootPoint.position, Quaternion.identity).Shoot(target);
		_shell.Shoot(target);
	}
}
