using FoodFavoriter.Domain;

namespace FoodFavoriter.Service
{
	public class FavoriterService
	{
		readonly IStorePeople personRepository;
		readonly IStoreFoodItems foodItemRepository;

		public FavoriterService(IStorePeople personRepository, IStoreFoodItems foodItemRepository)
		{
			this.personRepository = personRepository;
			this.foodItemRepository = foodItemRepository;
		}

		public void FavouriteFoodItem(string personReference, int sku)
		{
			var person = personRepository.FindPersonWithReference(PersonReference.FromExisting(personReference));
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			person.Favorite(foodItem);
			personRepository.Save(person);
		}

		public void UnFavouriteFoodItem(string personReference, int sku)
		{
			var person = personRepository.FindPersonWithReference(PersonReference.FromExisting(personReference));
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			person.UnFavorite(foodItem);
			personRepository.Save(person);
		}
	}
}
