using System.Linq;

public class Turret : EnemyController
{
	void Start()
	{
		SetState(_states.First(x => x.Name == GamePersonState.Attack));
	}

	
}
