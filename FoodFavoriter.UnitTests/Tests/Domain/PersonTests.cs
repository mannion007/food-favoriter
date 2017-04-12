using NUnit.Framework;
using FoodFavoriter.Domain;
using FoodFavoriter.Infrastructure.DomainEvent;

namespace FoodFavoriter.Unit.Tests.Domain
{
	[TestFixture()]
	public class PersonTests
	{
		[Test()]
		public void FavoritingAnItemShouldRaiseAnEvent()
		{
			var person = new Person(PersonReference.FromExisting("ref-001"), "Homer");
			var foodItem = new FoodItem(7463928, "Extra Strong Concentrated Squishee Syrup");
			PersonFavoritedFoodItemEvent raisedEvent = null;
			DomainEvents.Register<PersonFavoritedFoodItemEvent>((obj) => raisedEvent = (obj));

			person.Favorite(foodItem);

			Assert.IsInstanceOf(typeof(PersonFavoritedFoodItemEvent), raisedEvent);
			Assert.AreEqual(person, raisedEvent.Person);
			Assert.AreEqual(foodItem, raisedEvent.FoodItem);
		}

		[Test()]
		public void UnFavoritingAnItemShouldRaiseAnEvent()
		{
			var person = new Person(PersonReference.FromExisting("ref-001"), "Homer");
			var foodItem = new FoodItem(7463928, "Extra Strong Concentrated Squishee Syrup");
			PersonUnFavoritedFoodItemEvent raisedEvent = null;

			person.Favorite(foodItem);

			DomainEvents.Register<PersonUnFavoritedFoodItemEvent>((obj) => raisedEvent = (obj));
			person.UnFavorite(foodItem);

			Assert.IsInstanceOf(typeof(PersonUnFavoritedFoodItemEvent), raisedEvent);
			Assert.AreEqual(person, raisedEvent.Person);
			Assert.AreEqual(foodItem, raisedEvent.FoodItem);
		}
	}
}
