using System;
using System.Collections.Generic;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Infrastructure.Storage
{
	public class InMemoryPersonRepositoryAdapter : IStorePeople
	{
		readonly List<Person> people = new List<Person> { };

		public Person FindPersonWithReference(PersonReference reference)
		{
			var person = people.Find(p => p.Reference.Equals(reference));

			if (person != null)
			{
				return person;
			}

			throw new ArgumentException("Unable to find person with reference " + reference);
		}

		public void Save(Person person)
		{
			people.Remove(person);
			people.Add(person);
		}
	}
}
