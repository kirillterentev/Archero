using UnityEngine;

public interface AimingController
{
	Transform GetMainPlayer();
	Transform GetTarget();
	bool HasEnemies();
}
