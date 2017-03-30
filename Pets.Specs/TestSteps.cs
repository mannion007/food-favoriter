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
		readonly IProductRepository productRepository = new InMemoryProductRepositoryAdapter();

		[Given(@"I have a Person called ""(.*)""")]
		public void GivenIHaveAPersonCalled(string name)
		{
			personRepository.Save(new Person(name));
		}

		[Given(@"I have a (.*) product with the SKU (.*) called ""(.*)""")]
		public void GivenIHaveAProductWithTheSKUCalled(string productType, int sku, string name)
		{
			Product product = new Product(sku, name, (Product.ProductType)Enum.Parse(typeof(Product.ProductType), productType, true));
			productRepository.Save(product);
		}


		[Given(@"""(.*)"" has no favorited products")]
		public void GivenSomeoneHasNoFavoritedProducts(string customerName)
		{
		}

		[When(@"""(.*)"" tries to favorite the product (.*)")]
		public void WhenSomeoneTriesToFavoriteTheProduct(string name, int sku)
		{
			var personCandidate = personRepository.FindPersonWithName(name);
			var productCandidate = productRepository.FindProductWithSku(sku);
			try
			{
				personCandidate.FavoriteProduct(productCandidate);
			}
			catch(ArgumentException) { };
		}


		[Then(@"""(.*)"" should have (.*) favorited products")]
		public void ThenSomeoneShouldHaveFavoritedProducts(string name, int expectedFavoriteCount)
		{
			var personCandidate = personRepository.FindPersonWithName(name);
			Assert.AreEqual(expectedFavoriteCount, personCandidate.Favorites.Count);
		}

		[Given(@"""(.*)"" has favorited the product (.*)")]
		public void GivenSomeoneHasFavorited(string name, int sku)
		{
			var personCandidate = personRepository.FindPersonWithName(name);
			var productCandidate = productRepository.FindProductWithSku(sku);
			personCandidate.FavoriteProduct(productCandidate);
		}

		[When(@"""(.*)"" favorites the product (.*)")]
		public void WhenSomeoneFavoritesTheProduct(string name, int sku)
		{
			var personCandidate = personRepository.FindPersonWithName(name);
			var productCandidate = productRepository.FindProductWithSku(sku);
			personCandidate.FavoriteProduct(productCandidate);
		}

		[When(@"""(.*)"" unfavorites the product (.*)")]
		public void WhenUnfavoritesTheFoodProduct(string name, int sku)
		{
			var personCandidate = personRepository.FindPersonWithName(name);
			var productCandidate = productRepository.FindProductWithSku(sku);
			personCandidate.UnFavoriteProduct(productCandidate);
		}

		[When(@"""(.*)"" tries to unfavorite the product (.*)")]
		public void WhenSomeoneTriesToUnfavoriteTheFoodProduct(string name, int sku)
		{
			var personCandidate = personRepository.FindPersonWithName(name);
			var productCandidate = productRepository.FindProductWithSku(sku);
			try
			{
				personCandidate.UnFavoriteProduct(productCandidate);
			}
			catch (ArgumentException) { };
		}
	}
}
