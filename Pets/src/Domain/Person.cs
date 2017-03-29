using System;
using System.Collections.Generic;

namespace FoodFavoriter
{
	public class Person
	{
		public string name;

		public List<Product> favorites = new List<Product> { };

		public Person(string name)
		{
			this.name = name;
		}

		public void FavoriteProduct(Product product)
		{
			if (!product.category.Equals(Product.productType.Food))
			{
				throw new ArgumentException("Can only favorite products from the Food category");
			}

			if (this.favorites.Contains(product))
			{
				throw new ArgumentException("Cannot favorite an product that is already in favorites");
			}

			favorites.Add(product);
		}

		public void UnFavoriteProduct(Product product)
		{
			if (!this.favorites.Contains(product))
			{
				throw new ArgumentException("Cannot unfavorite an item that is not in favorites");
			}

			favorites.Remove(product);
		}
	}
}
