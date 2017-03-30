namespace FoodFavoriter.Domain
{
	public interface IFoodItemRepository
	{
		FoodItem FindFoodItemWithSku(int sku);
		void Save(FoodItem foodItem);
	}
}
