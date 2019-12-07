using UnityEngine;
using System.Collections;

public class Keyboard : MonoBehaviour, Joystick
{
	private void Awake()
	{
		StaticContainer.Add(typeof(Joystick), this);
	}

	public Vector2 GetValue()
	{
		var horizontalAxis = Input.GetAxis("Horizontal");
		var verticalAxis = Input.GetAxis("Vertical");
		Vector2 direction = new Vector2	(horizontalAxis, verticalAxis);
		return direction.normalized;
	}
}
