using System;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Api.Repositories.EntityFramework
{
	public class EntityFrameworkFoodItemRepository : IStoreFoodItems
	{
		readonly FoodFavoritingContext context = new FoodFavoritingContext();

		public FoodItem FindFoodItemWithSku(int sku)
		{
			var foodItem = context.FoodItems.Find(sku);

			if (foodItem != null)
			{
				return foodItem;
			}

			throw new ArgumentException("Could not find food item with sku");
		}


		public void Save(FoodItem foodItem)
		{
			var existingFoodItem = context.FoodItems.Find(foodItem.Sku);

			if (existingFoodItem != null)
			{
				context.FoodItems.Remove(existingFoodItem);
			}

			context.FoodItems.Add(foodItem);
			context.SaveChanges();
		}
	}
}
