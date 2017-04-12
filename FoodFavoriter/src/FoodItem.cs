using System;

using Newtonsoft.Json;

namespace FoodFavoriter.Domain
{
	public class FoodItem: IEquatable<FoodItem>
	{
		[JsonProperty()]
		public int Sku { get; private set; }

		[JsonProperty()]
		string Name;

		[JsonConstructor]
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
