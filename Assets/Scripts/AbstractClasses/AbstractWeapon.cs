using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour
{
	[SerializeField]
	protected AbstractShell _shell;
	[SerializeField]
	protected Transform _shootPoint;

	public virtual void Shoot(Vector3 target)
	{
		return;
	}
}
