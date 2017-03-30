using FoodFavoriter.Domain;

namespace FoodFavoriter.Service
{
	public class FavoriterService
	{
		readonly IPersonRepository personRepository;
		readonly IFoodItemRepository foodItemRepository;

		public FavoriterService(IPersonRepository personRepository, IFoodItemRepository foodItemRepository)
		{
			this.personRepository = personRepository;
			this.foodItemRepository = foodItemRepository;
		}

		public void FavouriteFoodItem(string personName, int sku)
		{
			var person = personRepository.FindPersonWithName(personName);
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			person.Favorite(foodItem);
			personRepository.Save(person);
		}

		public void UnFavouriteFoodItem(string personName, int sku)
		{
			var person = personRepository.FindPersonWithName(personName);
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			person.UnFavorite(foodItem);
			personRepository.Save(person);
		}
	}
}
