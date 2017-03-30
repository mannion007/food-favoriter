﻿using System;
using System.Collections.Generic;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Infrastructure.Storage
{
	public class InMemoryProductRepositoryAdapter : IProductRepository
	{
		readonly List<Product> products = new List<Product> { };

		public Product FindProductWithSku(int sku)
		{
			var product = this.products.Find(result => result.Sku == sku);

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
