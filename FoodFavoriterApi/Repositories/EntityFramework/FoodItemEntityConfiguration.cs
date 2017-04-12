using System.Data.Entity.ModelConfiguration;
using FoodFavoriter.Domain;

namespace FoodFavoriterApi
{
	public class FoodItemEntityConfiguration : EntityTypeConfiguration<FoodItem>
	{
		public FoodItemEntityConfiguration()
		{
			HasKey(f => f.Sku);
		}
	}
}
