using System;

using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

using FoodFavoriter.Domain;
using FoodFavoriter.Api.Repositories;

namespace FoodFavoriter.Specs
{
	[Binding, Scope(Tag = "api")]
	public class ApiSteps
	{
		readonly IStorePeople peopleRepository = new RedisPersonRepository();
		readonly Dictionary<int, FoodItem> foodItems = new Dictionary<int, FoodItem>();

		[Given(@"I have a Person with the reference ""(.*)"" named ""(.*)""")]
		public void GivenIHaveAPersonWithTheReferenceNamed(string reference, string name)
		{
			peopleRepository.Save(new Person(PersonReference.FromExisting(reference), name));
		}

		[Given(@"I have a Food Item with the SKU (.*) called ""(.*)""")]
		public void GivenIHaveAFoodItemWithTheSKUCalled(int sku, string name)
		{
			this.foodItems.Add(sku, new FoodItem(sku, name));
		}

		[Given(@"Person ""(.*)"" has no favorited Food Items")]
		public void GivenSomeoneHasNoFavoritedFoodItems(string customerName)
		{
		}

		[When(@"Person ""(.*)"" tries to favorite the Food Item (.*)")]
		public void WhenSomeoneTriesToFavoriteTheFoodItem(string reference, int sku)
		{
			Person person = peopleRepository.FindPersonWithReference(PersonReference.FromExisting(reference));

			FoodItem foodItem = null;
			this.foodItems.TryGetValue(sku, out foodItem);

			try
			{
				person.Favorite(foodItem);
			}
			catch(ArgumentException) { };
		}


		[Then(@"Person ""(.*)"" should have (.*) favorited Food Items")]
		public void ThenSomeoneShouldHaveFavoritedFoodItems(string reference, int expectedFavoriteCount)
		{
			Person person = peopleRepository.FindPersonWithReference(PersonReference.FromExisting(reference));
			var reflectedFavorites = typeof(Person).GetField("Favorites", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance).GetValue(person);
			var collection = (IList<FoodItem>)reflectedFavorites;
			Assert.AreEqual(expectedFavoriteCount, collection.Count);

		}

		[Given(@"Person ""(.*)"" has favorited the Food Item (.*)")]
		public void GivenSomeoneHasFavorited(string reference, int sku)
		{
			Person person = peopleRepository.FindPersonWithReference(PersonReference.FromExisting(reference));

			FoodItem foodItem = null;
			this.foodItems.TryGetValue(sku, out foodItem);

			person.Favorite(foodItem);

			//this has to go...
			peopleRepository.Save(person);
		}

		[When(@"Person ""(.*)"" favorites the Food Item (.*)")]
		public void WhenSomeoneFavoritesTheFoodItem(string reference, int sku)
		{
			Person person = peopleRepository.FindPersonWithReference(PersonReference.FromExisting(reference));

			FoodItem foodItem = null;
			this.foodItems.TryGetValue(sku, out foodItem);

			person.Favorite(foodItem);

			//this has to go...
			peopleRepository.Save(person);
			//throw new Exception("die");
		}

		[When(@"Person ""(.*)"" unfavorites the Food Item (.*)")]
		public void WhenUnfavoritesTheFoodItem(string reference, int sku)
		{
			Person person = peopleRepository.FindPersonWithReference(PersonReference.FromExisting(reference));

			FoodItem foodItem = null;
			this.foodItems.TryGetValue(sku, out foodItem);

			person.UnFavorite(foodItem);

			//this has to go...
			peopleRepository.Save(person);
		}

		[When(@"Person ""(.*)"" tries to unfavorite the Food Item (.*)")]
		public void WhenSomeoneTriesToUnfavoriteTheFoodItem(string reference, int sku)
		{
			Person person = peopleRepository.FindPersonWithReference(PersonReference.FromExisting(reference));

			FoodItem foodItem = null;
			this.foodItems.TryGetValue(sku, out foodItem);

			try
			{
				person.UnFavorite(foodItem);
			}
			catch (ArgumentException) { };
		}
	}
}
