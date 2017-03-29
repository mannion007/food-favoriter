using System;
using System.Collections.Generic;

namespace FoodFavoriter
{
	public class InMemoryPersonRepositoryAdapter : IPersonRepository
	{
		private List<Person> people = new List<Person> { };

		public Person FindPersonWithName(string name)
		{
			var person = this.people.Find(result => result.name == name);

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
