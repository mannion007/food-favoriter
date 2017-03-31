using System;
using System.Collections.Generic;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Infrastructure.Storage
{
	public class InMemoryFoodItemRepositoryAdapter : IStoreFoodItems
	{
		readonly List<FoodItem> foodItems = new List<FoodItem> { };

		public FoodItem FindFoodItemWithSku(int sku)
		{
			var product = foodItems.Find(f => f.Sku == sku);
			if (product != null)
			{
				return product;
			}
			throw new ArgumentException("Unable to find product with SKU " + sku);
		}

		public void Save(FoodItem foodItem)
		{
			foodItems.Remove(foodItem);
			foodItems.Add(foodItem);
		}
	}
}
