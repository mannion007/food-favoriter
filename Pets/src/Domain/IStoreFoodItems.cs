namespace FoodFavoriter.Domain
{
	public interface IStoreFoodItems
	{
		FoodItem FindFoodItemWithSku(int sku);
		void Save(FoodItem foodItem);
	}
}
