using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
	public EnemyType type;
	public float speed;
	public float rangeTravel;
	public float staticTime;
	public float health;
	public float firerate;
	public float damage;
}