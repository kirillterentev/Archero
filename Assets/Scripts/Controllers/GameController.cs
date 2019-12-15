using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour, AimingController
{
	public SaveLoader SaveLoader;

	private CameraControl _cameraControl;

	[SerializeField]
	private GamePerson _player;
	[SerializeField]
	private List<GamePerson> _enemies;

	public GameData GameData
	{
		get
		{
			if (GameData == null)
			{
				SaveLoader.Load();
			}

			return GameData;
		}
	}

	private void Awake()
	{
		StaticContainer.Add(typeof(AimingController), this);
	}

	private void Start()
	{
		_cameraControl = (CameraControl) StaticContainer.Get(typeof(CameraControl));
		_cameraControl.SetTarget(_player.transform);
	}

	public Transform GetMainPlayer()
	{
		return _player.transform;
	}

	public Transform GetTarget()
	{
		if (_enemies.Count == 0)
		{
			return null;
		}

		var _enemyDistances = new Dictionary<Transform, float>();

		foreach (var enemy in _enemies)
		{
			_enemyDistances.Add(enemy.transform, (_player.GetPosition() - enemy.GetPosition()).magnitude);
		}

		var min = _enemyDistances.Min(x => x.Value);
		return _enemyDistances.First(x => x.Value == min).Key;
	}

	public bool HasEnemies()
	{
		return _enemies.Count > 0;
	}

	private void Update()
	{
		_player.UpdateState();

		foreach (var enemy in _enemies)
		{
			enemy.UpdateState();
		}
	}

	private void LateUpdate()
	{
		_cameraControl.UpdatePosition();
	}
}
