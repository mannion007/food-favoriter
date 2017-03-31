using FoodFavoriter.Library.Interface;

namespace FoodFavoriter.Domain
{
	public class PersonUnFavoritedFoodItemEvent : IDomainEvent
	{
		public Person Person { get; }

		public FoodItem FoodItem { get; }

		public PersonUnFavoritedFoodItemEvent(Person person, FoodItem foodItem)
		{
			Person = person;
			FoodItem = foodItem;
		}
	}
}
