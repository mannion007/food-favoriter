using System;

namespace FoodFavoriter
{
	public interface IPersonRepository
	{
		Person FindPersonWithName(string name);
		void Save(Person person);
	}
}
