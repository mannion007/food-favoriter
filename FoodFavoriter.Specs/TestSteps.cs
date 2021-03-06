﻿using System;

using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

using FoodFavoriter.Domain;

namespace FoodFavoriter.Specs
{
	[Binding]
	public class TestSteps
	{
		readonly Dictionary<string, Person> people = new Dictionary<string, Person>();
		readonly Dictionary<int, FoodItem> foodItems = new Dictionary<int, FoodItem>();

		[Given(@"I have a Person with the reference ""(.*)"" named ""(.*)""")]
		public void GivenIHaveAPersonWithTheReferenceNamed(string reference, string name)
		{
			this.people.Add(reference, new Person(PersonReference.FromExisting(reference), name));
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
			Person person = null;
			this.people.TryGetValue(reference, out person);

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
			Person person = null;
			this.people.TryGetValue(reference, out person);
			var reflectedFavorites = typeof(Person).GetField("Favorites", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance).GetValue(person);
			var collection = (IList<FoodItem>)reflectedFavorites;
			Assert.AreEqual(expectedFavoriteCount, collection.Count);

		}

		[Given(@"Person ""(.*)"" has favorited the Food Item (.*)")]
		public void GivenSomeoneHasFavorited(string reference, int sku)
		{
			Person person = null;
			this.people.TryGetValue(reference, out person);

			FoodItem foodItem = null;
			this.foodItems.TryGetValue(sku, out foodItem);

			person.Favorite(foodItem);
		}

		[When(@"Person ""(.*)"" favorites the Food Item (.*)")]
		public void WhenSomeoneFavoritesTheFoodItem(string reference, int sku)
		{
			Person person = null;
			this.people.TryGetValue(reference, out person);

			FoodItem foodItem = null;
			this.foodItems.TryGetValue(sku, out foodItem);

			//throw new Exception("live");

			person.Favorite(foodItem);
		}

		[When(@"Person ""(.*)"" unfavorites the Food Item (.*)")]
		public void WhenUnfavoritesTheFoodItem(string reference, int sku)
		{
			Person person = null;
			this.people.TryGetValue(reference, out person);

			FoodItem foodItem = null;
			this.foodItems.TryGetValue(sku, out foodItem);

			person.UnFavorite(foodItem);
		}

		[When(@"Person ""(.*)"" tries to unfavorite the Food Item (.*)")]
		public void WhenSomeoneTriesToUnfavoriteTheFoodItem(string reference, int sku)
		{
			Person person = null;
			this.people.TryGetValue(reference, out person);

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
