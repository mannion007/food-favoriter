using System;

namespace FoodFavoriter
{
	public interface IProductRepository
	{
		Product FindProductWithSku(int sku);
		void Save(Product product);
	}
}
