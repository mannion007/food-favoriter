using System;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Service
{
	public class FavoriterService
	{
		readonly IPersonRepository personRepository;
		readonly IProductRepository productRepository;

		public FavoriterService(IPersonRepository personRepository, IProductRepository productRepository)
		{
			this.personRepository = personRepository;
			this.productRepository = productRepository;
		}

		public void FavouriteFoodItem(string personName, int sku)
		{
			var person = personRepository.FindPersonWithName(personName);
			var productToFavorite = productRepository.FindProductWithSku(sku);
			person.FavoriteProduct(productToFavorite);
			personRepository.Save(person);
		}

		public void UnFavouriteFoodItem(string personName, int sku)
		{
			var person = personRepository.FindPersonWithName(personName);
			var productToUnFavorite = productRepository.FindProductWithSku(sku);
			person.UnFavoriteProduct(productToUnFavorite);
			personRepository.Save(person);
		}
	}
}
