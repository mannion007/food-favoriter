namespace FoodFavoriter.Domain
{
	public interface IPersonRepository
	{
		Person FindPersonWithName(string name);
		void Save(Person person);
	}
}
