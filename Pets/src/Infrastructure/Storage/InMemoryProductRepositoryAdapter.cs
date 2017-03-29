using System;
using System.Collections.Generic;

namespace FoodFavoriter
{
	public class InMemoryProductRepositoryAdapter : IProductRepository
	{
		private List<Product> products = new List<Product> { };

		public Product FindProductWithSku(int sku)
		{
			var product = this.products.Find(result => result.sku == sku);

			if (product != null)
			{
				return product;
			}

			throw new ArgumentException("Unable to find product");
		}

		public void Save(Product product)
		{
			products.Remove(product);
			products.Add(product);
		}
	}
}
