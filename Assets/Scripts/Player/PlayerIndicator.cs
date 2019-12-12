using UnityEngine;
using UnityEngine.UI;

public class PlayerIndicator : MonoBehaviour, PersonIndicator
{
	[SerializeField]
	private Image _bar;

	public void UpdateValue(float value)
	{
		_bar.fillAmount = value;
	}
}
