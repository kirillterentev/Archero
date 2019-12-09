using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Cell
{
	public CellType type;
	public GameObject prefab;
}

public class LevelController : MonoBehaviour, MapBuilder, SpawnController
{
	[SerializeField] private List<Cell> _cells;
	[SerializeField] private List<Map> _maps;



	void Start()
	{
		//BuildMap();
	}

	public void BuildMap()
	{
		var matrix = _maps[0].matrix;
		var startPos = Vector3.zero;

		for (int i = 0; i < _maps[0].height; i++)
		{
			for (int j = 0; j < _maps[0].width; j++)
			{
				Instantiate(_cells.First(x => x.type == (CellType) matrix[i * _maps[0].width + j]).prefab, startPos, Quaternion.identity);
				startPos += Vector3.right;
			}

			startPos.x = 0;
			startPos += Vector3.forward;
		}
	}

	public void Spawn(out GamePerson person)
	{
		throw new System.NotImplementedException();
	}
}
