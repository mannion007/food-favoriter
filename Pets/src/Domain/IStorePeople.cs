namespace FoodFavoriter.Domain
{
	public interface IStorePeople
	{
		Person FindPersonWithReference(PersonReference reference);
		void Save(Person person);
	}
}
