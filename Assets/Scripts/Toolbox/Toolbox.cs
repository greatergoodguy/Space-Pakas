using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class Toolbox {
	public static void Log(string message) {
#if UNITY_EDITOR || UNITY_EDITOR_64 || UNITY_EDITOR_OSX
		StackFrame frame = new StackFrame(1);
		MethodBase method = frame.GetMethod();
		string tag = method.DeclaringType?.ToString();

		UnityEngine.Debug.Log(tag + ": " + message);
#else
UnityEngine.Debug.Log(message);
#endif
	}

	public static bool IsVectorValid(Vector3 vector) {
		return !float.IsNaN(vector.x) && !float.IsNaN(vector.y) && !float.IsNaN(vector.z);
	}

	public static T GetRandomItem<T>(List<T> list) {
		if(list.Count == 0) {
			return default(T);
		}

		int index = Random.Range(0, list.Count);
		return list[index];
	}
	
	public static GameObject Create(string path, Vector3? position = null, Quaternion? rotation = null)
	{
		GameObject prefab = Resources.Load<GameObject>(path);
		if (prefab == null)
		{
			Debug.LogWarning($"PrefabLoader: Could not find prefab at Resources/{path}");
			return null;
		}

		Vector3 pos = position ?? Vector3.zero;
		Quaternion rot = rotation ?? Quaternion.identity;

		return Object.Instantiate(prefab, pos, rot);
	}
}