using System;
using UnityEngine;
using UnityEngine.Events;

public interface EventDispatcher
{
	void AddListener(GameEvents name, UnityAction<object[]> action);
	void RemoveListener(GameEvents name, UnityAction<object[]> action);
	void RemoveAllListeners(GameEvents name);
	void InvokeEvent(GameEvents name, params object[] args);
}
