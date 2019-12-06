using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "Map")]
public class Map : ScriptableObject
{
	public int width;
	public int height;
	public int[] matrix = new int[1];
}