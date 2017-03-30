using System;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Infrastructure.Storage.EntityFramework
{
	public class EntityFrameworkPersonRepositoryAdapter : IPersonRepository
	{
		readonly FoodFavoritingContext context = new FoodFavoritingContext();

		public Person FindPersonWithName(string name)
		{
			var personWithName = context.People.Find(name);

			if (personWithName != null)
			{
				return personWithName;
			}

			throw new ArgumentException("Could not find person");
		}


		public void Save(Person person)
		{
			var personWithName = context.People.Find(person.Name);

			if (personWithName != null)
			{
				context.People.Remove(personWithName);
			}

			context.People.Add(person);
			context.SaveChanges();
		}
	}
}
