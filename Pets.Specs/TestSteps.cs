using System;

using TechTalk.SpecFlow;
using NUnit.Framework;

using FoodFavoriter.Domain;
using FoodFavoriter.Infrastructure.Storage;

namespace Pets.Specs
{
	[Binding]
	public class TestSteps
	{
		readonly IPersonRepository personRepository = new InMemoryPersonRepositoryAdapter();
		readonly IFoodItemRepository foodItemRepository = new InMemoryFoodItemRepositoryAdapter();

		[Given(@"I have a Person called ""(.*)""")]
		public void GivenIHaveAPersonCalled(string name)
		{
			personRepository.Save(new Person(name));
		}

		[Given(@"I have a Food Item with the SKU (.*) called ""(.*)""")]
		public void GivenIHaveAFoodItemWithTheSKUCalled(int sku, string name)
		{
			FoodItem foodItem = new FoodItem(sku, name);
			foodItemRepository.Save(foodItem);
		}

		[Given(@"""(.*)"" has no favorited Food Items")]
		public void GivenSomeoneHasNoFavoritedFoodItems(string customerName)
		{
		}

		[When(@"""(.*)"" tries to favorite the Food Item (.*)")]
		public void WhenSomeoneTriesToFavoriteTheFoodItem(string name, int sku)
		{
			var person = personRepository.FindPersonWithName(name);
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			try
			{
				person.Favorite(foodItem);
			}
			catch(ArgumentException) { };
		}


		[Then(@"""(.*)"" should have (.*) favorited Food Items")]
		public void ThenSomeoneShouldHaveFavoritedFoodItems(string name, int expectedFavoriteCount)
		{
			var personCandidate = personRepository.FindPersonWithName(name);
			Assert.AreEqual(expectedFavoriteCount, personCandidate.Favorites.Count);
		}

		[Given(@"""(.*)"" has favorited the Food Item (.*)")]
		public void GivenSomeoneHasFavorited(string name, int sku)
		{
			var person = personRepository.FindPersonWithName(name);
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			person.Favorite(foodItem);
		}

		[When(@"""(.*)"" favorites the Food Item (.*)")]
		public void WhenSomeoneFavoritesTheFoodItem(string name, int sku)
		{
			var person = personRepository.FindPersonWithName(name);
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			person.Favorite(foodItem);
		}

		[When(@"""(.*)"" unfavorites the Food Item (.*)")]
		public void WhenUnfavoritesTheFoodItem(string name, int sku)
		{
			var person = personRepository.FindPersonWithName(name);
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			person.UnFavorite(foodItem);
		}

		[When(@"""(.*)"" tries to unfavorite the Food Item (.*)")]
		public void WhenSomeoneTriesToUnfavoriteTheFoodItem(string name, int sku)
		{
			var person = personRepository.FindPersonWithName(name);
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			try
			{
				person.UnFavorite(foodItem);
			}
			catch (ArgumentException) { };
		}
	}
}
