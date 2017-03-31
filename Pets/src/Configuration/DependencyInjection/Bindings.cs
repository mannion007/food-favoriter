using Ninject.Modules;
using FoodFavoriter.Domain;
using FoodFavoriter.Infrastructure.Storage;

namespace FoodFavoriter.Configuration.DependencyInjection
{
	public class Bindings : NinjectModule
	{
		public override void Load()
		{
			Bind<IStorePeople>().To<InMemoryPersonRepositoryAdapter>();
			Bind<IStoreFoodItems>().To<InMemoryFoodItemRepositoryAdapter>();
		}
	}
}
