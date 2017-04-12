using System;
using System.Collections.Generic;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Api.Repositories
{
	public class InMemoryPersonRepository : IStorePeople
	{
		readonly List<Person> people = new List<Person> { };

		public InMemoryPersonRepository()
		{
			people.Add(new Person(PersonReference.FromExisting("ref-001"), "James"));
		}


		public Person FindPersonWithReference(PersonReference reference)
		{
			var person = people.Find(p => p.Reference.Equals(reference));

			if (person != null)
			{
				return person;
			}

			throw new ArgumentException("Unable to find person with reference");
		}

		public void Save(Person person)
		{
			people.Remove(person);
			people.Add(person);
		}
	}
}
