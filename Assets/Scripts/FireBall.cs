using UnityEngine;

public class FireBall : AbstractShell
{
	private Vector3 _target;

	public override void Shoot(Vector3 target)
	{
		_target = target;
		_rb.AddForce((_target - transform.position).normalized * 10, ForceMode.VelocityChange);
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.layer != LayerMask.NameToLayer("Enemy"))
		{
			return;
		}

		Destroy(this.gameObject);
	}
}
