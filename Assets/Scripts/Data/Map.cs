using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "Map")]
public class Map : ScriptableObject
{
	public float width;
	public float height;
	public byte[,] matrix;
}