using UnityEngine;
using System.Collections;
using System.Linq;

public class EnemyController : GamePerson, IDamageble
{
	[SerializeField]
	protected EnemyData _data;
	[SerializeField]
	protected PersonIndicator _indicator;

	public void TakeDamage(int damage)
	{
		_data.health -= damage;
		if (_data.health <= 0)
		{
			_data.health = 0;
		}

		_indicator.UpdateValue(_data.health / _data.maxHealth);
	}
}
