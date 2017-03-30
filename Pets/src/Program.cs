using System;
using System.Reflection;
using Ninject;
using FoodFavoriter.Service;

namespace FoodFavoriter
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());
			var favoriterService = kernel.Get<FavoriterService>();
			favoriterService.FavouriteFoodItem("James", 123456);

			Console.WriteLine("Hello World!");
		}
	}
}
