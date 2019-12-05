using UnityEngine;

public class GameController : MonoBehaviour
{
	public SaveLoader SaveLoader;
	public UIController UIController;

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
		UIController = GetComponent<UIController>();
	}

	private void Start()
	{
		UIController.ShowWindow(GameWindow.MainMenu);
	}
}
