using System;
using System.Data.Entity.ModelConfiguration;

namespace FoodFavoriter
{
	public class PersonMap : EntityTypeConfiguration<Person>
	{
		public PersonMap()
		{
			//ToTable("Account");
			HasKey(p => p.Name);

			//Property(a => a.Username).HasMaxLength(50);
			//Property(a => a.Email).HasMaxLength(255);
			//Property(a => a.Name).HasMaxLength(255);
		}
	}
}
