using System;
using System.Collections.Generic;

namespace FoodFavoriter.Domain
{
	public class Person
	{
		public string Name { get; private set; }

		public List<Product> Favorites = new List<Product> { };

		public Person(string name)
		{
			Name = name;
		}

		public void FavoriteProduct(Product product)
		{
			if (!product.Category.Equals(Product.ProductType.Food))
			{
				throw new ArgumentException("Can only favorite products from the Food category");
			}

			if (Favorites.Contains(product))
			{
				throw new ArgumentException("Cannot favorite an product that is already in favorites");
			}

			Favorites.Add(product);
		}

		public void UnFavoriteProduct(Product product)
		{
			if (!Favorites.Contains(product))
			{
				throw new ArgumentException("Cannot unfavorite an item that is not in favorites");
			}

			Favorites.Remove(product);
		}
	}
}
