﻿using System.Data.Entity.ModelConfiguration;
using FoodFavoriter.Domain;

namespace FoodFavoriter.Api.Repositories.EntityFramework
{
	public class PersonEntityConfiguration : EntityTypeConfiguration<Person>
	{
		public PersonEntityConfiguration()
		{
			HasKey(p => p.Reference);
		}
	}
}
