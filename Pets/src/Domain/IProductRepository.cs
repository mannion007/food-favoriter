using System;

namespace FoodFavoriter.Domain
{
	public interface IProductRepository
	{
		Product FindProductWithSku(int sku);
		void Save(Product product);
	}
}
