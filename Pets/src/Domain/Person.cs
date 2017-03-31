using System;
using System.Collections.Generic;

namespace FoodFavoriter.Domain
{
	public class Person
	{
		public PersonReference Reference { get; private set; }

		public string Name { get; private set; }

		public List<FoodItem> Favorites = new List<FoodItem> { };

		public Person(PersonReference reference, string name)
		{
			Reference = reference;
			Name = name;
		}

		public void Favorite(FoodItem foodItem)
		{
			if (Favorites.Contains(foodItem))
			{
				throw new ArgumentException("Cannot favorite an product that is already in favorites");
			}

			Favorites.Add(foodItem);
		}

		public void UnFavorite(FoodItem foodItem)
		{
			if (!Favorites.Contains(foodItem))
			{
				throw new ArgumentException("Cannot unfavorite an item that is not in favorites");
			}

			Favorites.Remove(foodItem);
		}
	}
}
