using System;

namespace FoodFavoriter.Domain
{
	public class Product: IEquatable<Product>
	{
		public enum ProductType { Food, Electrical }

		public int Sku;

		public string Name;

		public ProductType Category { get; }

		public Product(int sku, string name, ProductType category)
		{
			Sku = sku;
			Name = name;
			Category = category;
		}

		public bool Equals(Product Other)
		{
			return Sku == Other.Sku;
		}
	}
}
