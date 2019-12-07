using UnityEngine;

public class GameController : MonoBehaviour
{
	public SaveLoader SaveLoader;
	public UIController UIController;

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

	private void Awake()
	{

	}

	private void Start()
	{

	}

	private void Update()
	{
		Player.UpdateState();
	}
}
