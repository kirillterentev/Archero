using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Map))]
public class MapEditor : Editor
{
	private Map map;

	private void Awake()
	{
		map = (Map) target;
	}
	

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		map = (Map)target;

		map.width = EditorGUILayout.IntField("Width", map.width);
		map.height = EditorGUILayout.IntField("Lenght", map.height);

		GUILayout.Space(20);
		GUILayout.Label("Matrix");

		if (map.width > 0 && map.height > 0)
		{
			if (map.width * map.height != map.matrix.Length)
			{
				map.matrix = new int[map.width * map.height];
			}

			GUILayout.BeginHorizontal(GUILayout.MaxWidth(15 * map.width));
				for (int i = 0; i < map.height; i++)
				{
					GUILayout.BeginVertical(GUILayout.MaxWidth(16 * map.height));
						for (int j = 0; j < map.width; j++)
						{
							map.matrix[i * map.width + j] = EditorGUILayout.IntField(map.matrix[i * map.width + j], GUILayout.MaxWidth(15));
						}
					GUILayout.EndVertical();
				}
			GUILayout.EndHorizontal();
		}

		serializedObject.ApplyModifiedProperties();
	}
}