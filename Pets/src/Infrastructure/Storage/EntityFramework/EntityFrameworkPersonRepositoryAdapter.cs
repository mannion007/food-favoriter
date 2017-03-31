﻿using System;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Infrastructure.Storage.EntityFramework
{
	public class EntityFrameworkPersonRepositoryAdapter : IStorePeople
	{
		readonly FoodFavoritingContext context = new FoodFavoritingContext();

		public Person FindPersonWithReference(PersonReference reference)
		{
			var person = context.People.Find(reference);

			if (person != null)
			{
				return person;
			}

			throw new ArgumentException("Could not find person with reference " + reference);
		}


		public void Save(Person person)
		{
			var existingPerson = context.People.Find(person.Reference);

			if (existingPerson != null)
			{
				context.People.Remove(existingPerson);
			}

			context.People.Add(person);
			context.SaveChanges();
		}
	}
}
