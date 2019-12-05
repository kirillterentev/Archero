using System;
using UnityEngine;
using UnityEngine.Events;

public interface EventDispatcher
{
	void AddListener(GameEvents name, UnityEvent action);
	void RemoveListener(GameEvents name, UnityEvent action);
	void RemoveAllListeners(GameEvents name);
	void InvokeEvent(GameEvents name);
}
