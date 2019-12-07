using UnityEngine;

public class GameController : MonoBehaviour
{
	public SaveLoader SaveLoader;

	private CameraControl _cameraControl;

	public GamePerson Player;

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

	private void Start()
	{
		_cameraControl = (CameraControl) StaticContainer.Get(typeof(CameraControl));
		_cameraControl.SetTarget(Player.transform);
	}

	private void Update()
	{
		Player.UpdateState();
	}

	private void LateUpdate()
	{
		_cameraControl.UpdatePosition();
	}
}
