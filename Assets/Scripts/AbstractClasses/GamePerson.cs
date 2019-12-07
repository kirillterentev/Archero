using UnityEngine;

public abstract class GamePerson : MonoBehaviour
{
	public virtual void UpdateState()
	{
		Debug.Log("This is basic class!");
	}
}
