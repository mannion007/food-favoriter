using System;
using System.Collections.Generic;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Infrastructure.Storage
{
	public class InMemoryFoodItemRepositoryAdapter : IFoodItemRepository
	{
		readonly List<FoodItem> foodItems = new List<FoodItem> { };

		public FoodItem FindFoodItemWithSku(int sku)
		{
			var product = this.foodItems.Find(result => result.Sku == sku);
			if (product != null)
			{
				return product;
			}
			throw new ArgumentException("Unable to find product");
		}

		public void Save(FoodItem foodItem)
		{
			foodItems.Remove(foodItem);
			foodItems.Add(foodItem);
		}
	}
}
