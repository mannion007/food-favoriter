using FoodFavoriter.Library.Interface;

namespace FoodFavoriter.Domain
{
	public class PersonFavoritedFoodItemEvent : IDomainEvent
	{
		public Person Person { get; }

		public FoodItem FoodItem { get; }

		public PersonFavoritedFoodItemEvent(Person person, FoodItem foodItem)
		{
			Person = person;
			FoodItem = foodItem;
		}
	}
}
