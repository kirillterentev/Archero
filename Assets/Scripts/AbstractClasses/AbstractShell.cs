using UnityEngine;

public abstract class AbstractShell : MonoBehaviour
{
	[SerializeField]
	protected Rigidbody _rb;
	[SerializeField]
	protected Transform _transform;

	public virtual void Shoot(Vector3 target)
	{
		return;
	}
}
