using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

public class MyEvent : UnityEvent<object[]> { }

public class GameEventDispatcher :  EventDispatcher
{
	private Dictionary<GameEvents, MyEvent> _events;

	public void AddListener(GameEvents name, UnityAction<object[]> action)
	{
		if (_events.ContainsKey(name))
		{
			_events[name].AddListener(action);
			return;
		}

		_events.Add(name, new MyEvent());
		_events[name].AddListener(action);
	}

	public void RemoveListener(GameEvents name, UnityAction<object[]> action)
	{
		if (!_events.ContainsKey(name))
		{
			return;
		}

		_events[name].RemoveListener(action);

		if (_events[name].GetPersistentEventCount() < 1)
		{
			_events.Remove(name);
		}
	}

	public void RemoveAllListeners(GameEvents name)
	{
		if (!_events.ContainsKey(name))
		{
			return;
		}

		_events[name].RemoveAllListeners();
		_events.Remove(name);
	}

	public void InvokeEvent(GameEvents name, params object[] args)
	{
		if (!_events.ContainsKey(name))
		{
			Debug.LogError($"Event with id({name}) does not contain in EventList!");
			return;
		}

		_events[name].Invoke(args);
	}
}