using UnityEngine;

public class FireBall : AbstractShell
{
	private bool _isFire = false;
	private Vector3 _target;

	public override void Shoot(Vector3 target)
	{
		_target = target;
		_isFire = true;
	}

	private void Update()
	{
		if (!_isFire)
		{
			return;
		}

		transform.Translate((_target - transform.position).normalized * 0.5f);
	}
}
