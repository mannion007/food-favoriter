using System;

namespace FoodFavoriter.Domain
{
	public class PersonReference : IEquatable<PersonReference>
	{
		readonly string Reference;

		PersonReference(string reference)
		{
			Reference = reference;
		}

		public static PersonReference FromExisting(string existing)
		{
			return new PersonReference(existing);
		}

		public bool Equals(PersonReference other)
		{
			return Reference == other.Reference;
		}

	}
}
