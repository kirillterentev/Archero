using UnityEngine;
using System.Collections;

public class DoubleBullet : AbstractShell
{
	private Vector3 _target;
	private Vector3 _direction;

	public override void Shoot(Vector3 target)
	{
		_target = target;

		if (_direction == null || _direction == Vector3.zero)
		{
			_target.y = transform.position.y;
			_direction = (_target - transform.position).normalized;
		}

		_rb.AddForce((_target - transform.position).normalized * 5, ForceMode.VelocityChange);

		Destroy(gameObject, 10);
	}

	private void OnCollisionEnter(Collision other)
	{
		Destroy(this.gameObject);
	}
}
