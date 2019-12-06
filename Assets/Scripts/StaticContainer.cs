using System;
using System.Collections.Generic;

public class StaticContainer
{
	private static Dictionary<Type, object> _container = new Dictionary<Type, object>();

	public static void Add(Type type, object obj)
	{
		if (_container.ContainsKey(type))
		{
			_container[type] = obj;
			return;
		}

		_container.Add(type, obj);	
	}

	public static object Get(Type type)
	{
		return _container.ContainsKey(type) ? _container[type] : null;
	}

	public static void Remove(Type type)
	{
		if (!_container.ContainsKey(type))
		{
			return;
		}

		_container.Remove(type);
	}
}
