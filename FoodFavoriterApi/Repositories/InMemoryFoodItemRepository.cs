using System;
using System.Collections.Generic;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Api.Repositories
{
	public class InMemoryFoodItemRepository : IStoreFoodItems
	{
		readonly List<FoodItem> foodItems = new List<FoodItem> { };

		public InMemoryFoodItemRepository()
		{
			foodItems.Add(new FoodItem(1234567, "Granny Smith Apple"));
		}

		public FoodItem FindFoodItemWithSku(int sku)
		{
			var product = foodItems.Find(f => f.Sku == sku);
			if (product != null)
			{
				return product;
			}
			throw new ArgumentException("Unable to find product with SKU");
		}

		public void Save(FoodItem foodItem)
		{
			foodItems.Remove(foodItem);
			foodItems.Add(foodItem);
		}
	}
}
