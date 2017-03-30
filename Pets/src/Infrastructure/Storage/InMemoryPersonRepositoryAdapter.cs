using System;
using System.Collections.Generic;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Infrastructure.Storage
{
	public class InMemoryPersonRepositoryAdapter : IPersonRepository
	{
		readonly List<Person> people = new List<Person> { };

		public Person FindPersonWithName(string name)
		{
			var person = people.Find(result => result.Name == name);

			if (person != null)
			{
				return person;
			}

			throw new ArgumentException("Unable to find person");
		}

		public void Save(Person person)
		{
			people.Remove(person);
			people.Add(person);
		}
	}
}
