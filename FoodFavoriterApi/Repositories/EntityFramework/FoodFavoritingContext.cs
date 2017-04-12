using System.Data.Entity;
using System.Reflection;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Api.Repositories.EntityFramework
{
	public class FoodFavoritingContext : DbContext
	{
		public DbSet<Person> People { get; set; }

		public DbSet<FoodItem> FoodItems { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(GetType()));
			base.OnModelCreating(modelBuilder);
		}
	}
}
