using System;
using System.Collections.Generic;
using FoodFavoriter.Infrastructure.DomainEvent;

namespace FoodFavoriter.Domain
{
	public class Person
	{
		public PersonReference Reference { get; private set; }

		public string Name { get; private set; }

		public List<FoodItem> Favorites { get; private set; }= new List<FoodItem> { };

		public Person(PersonReference reference, string name)
		{
			Reference = reference;
			Name = name;
		}

		public Person(PersonReference reference, string name, List<FoodItem> favorites)
		{
			Reference = reference;
			Name = name;
			Favorites = favorites;
		}

		public void Favorite(FoodItem foodItem)
		{
			if (Favorites.Contains(foodItem))
			{
				throw new ArgumentException("Cannot favorite a Food Item that is already in favorites");
			}

			Favorites.Add(foodItem);

			DomainEvents.Raise(new PersonFavoritedFoodItemEvent(this, foodItem));
		}

		public void UnFavorite(FoodItem foodItem)
		{
			if (!Favorites.Contains(foodItem))
			{
				throw new ArgumentException("Cannot unfavorite a Food Item that is not in favorites");
			}

			Favorites.Remove(foodItem);

			DomainEvents.Raise(new PersonUnFavoritedFoodItemEvent(this, foodItem));
		}
	}
}
