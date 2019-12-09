using UnityEngine;
using System.Collections;

public class Rifle : AbstractWeapon
{
	public override void Shoot(Vector3 target)
	{
		_shell = Instantiate(_shell.gameObject, _shootPoint.position, Quaternion.identity).GetComponent<AbstractShell>();
		_shell.Shoot(target);
	}
}
