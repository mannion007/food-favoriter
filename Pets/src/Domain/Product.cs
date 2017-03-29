using System;

namespace FoodFavoriter
{
	public class Product: IEquatable<Product>
	{
		public enum productType { Food, Electrical }

		public int sku;
		public string name;
		public productType category { get; }

		public Product(int sku, string name, productType category)
		{
			this.sku = sku;
			this.category = category;
			this.name = name;
		}

		public bool Equals(Product other)
		{
			return sku == other.sku;
		}

	}
}
