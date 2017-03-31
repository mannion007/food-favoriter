using System;
using System.Collections.Generic;
using FoodFavoriter.Library.Interface;

namespace FoodFavoriter.Infrastructure.DomainEvent
{
	public static class DomainEvents
	{
		static List<Delegate> actions = new List<Delegate>();

		public static void Register<T>(Action<T> callback) where T : IDomainEvent
		{
			actions.Add(callback);
		}

		public static void ClearCallbacks()
		{
			actions = new List<Delegate>();
		}

		public static void Raise<T>(T args) where T : IDomainEvent
		{

			foreach (var action in actions)
			{
				if (action is Action<T>)
				{
					((Action<T>)action)(args);
				}
			}
		}
	}
}
