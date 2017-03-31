using System;

namespace FoodFavoriter.Domain
{
	public class FoodItem: IEquatable<FoodItem>
	{
		public int Sku;

		public string Name;

		public FoodItem(int sku, string name)
		{
			Sku = sku;
			Name = name;
		}

		public bool Equals(FoodItem Other)
		{
			return Sku == Other.Sku;
		}
	}
}
