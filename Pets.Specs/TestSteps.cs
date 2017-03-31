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
		readonly IStorePeople personRepository = new InMemoryPersonRepositoryAdapter();
		readonly IStoreFoodItems foodItemRepository = new InMemoryFoodItemRepositoryAdapter();

		[Given(@"I have a Person with the reference ""(.*)"" named ""(.*)""")]
		public void GivenIHaveAPersonCalled(string reference, string name)
		{
			personRepository.Save(new Person(PersonReference.FromExisting(reference), name));
		}

		[Given(@"I have a Food Item with the SKU (.*) called ""(.*)""")]
		public void GivenIHaveAFoodItemWithTheSKUCalled(int sku, string name)
		{
			FoodItem foodItem = new FoodItem(sku, name);
			foodItemRepository.Save(foodItem);
		}

		[Given(@"Person ""(.*)"" has no favorited Food Items")]
		public void GivenSomeoneHasNoFavoritedFoodItems(string customerName)
		{
		}

		[When(@"Person ""(.*)"" tries to favorite the Food Item (.*)")]
		public void WhenSomeoneTriesToFavoriteTheFoodItem(string reference, int sku)
		{
			var person = personRepository.FindPersonWithReference(PersonReference.FromExisting(reference));
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			try
			{
				person.Favorite(foodItem);
			}
			catch(ArgumentException) { };
		}


		[Then(@"Person ""(.*)"" should have (.*) favorited Food Items")]
		public void ThenSomeoneShouldHaveFavoritedFoodItems(string reference, int expectedFavoriteCount)
		{
			var personCandidate = personRepository.FindPersonWithReference(PersonReference.FromExisting(reference));
			Assert.AreEqual(expectedFavoriteCount, personCandidate.Favorites.Count);
		}

		[Given(@"Person ""(.*)"" has favorited the Food Item (.*)")]
		public void GivenSomeoneHasFavorited(string reference, int sku)
		{
			var person = personRepository.FindPersonWithReference(PersonReference.FromExisting(reference));
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			person.Favorite(foodItem);
		}

		[When(@"Person ""(.*)"" favorites the Food Item (.*)")]
		public void WhenSomeoneFavoritesTheFoodItem(string reference, int sku)
		{
			var person = personRepository.FindPersonWithReference(PersonReference.FromExisting(reference));
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			person.Favorite(foodItem);
		}

		[When(@"Person ""(.*)"" unfavorites the Food Item (.*)")]
		public void WhenUnfavoritesTheFoodItem(string reference, int sku)
		{
			var person = personRepository.FindPersonWithReference(PersonReference.FromExisting(reference));
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			person.UnFavorite(foodItem);
		}

		[When(@"Person ""(.*)"" tries to unfavorite the Food Item (.*)")]
		public void WhenSomeoneTriesToUnfavoriteTheFoodItem(string reference, int sku)
		{
			var person = personRepository.FindPersonWithReference(PersonReference.FromExisting(reference));
			var foodItem = foodItemRepository.FindFoodItemWithSku(sku);
			try
			{
				person.UnFavorite(foodItem);
			}
			catch (ArgumentException) { };
		}
	}
}
