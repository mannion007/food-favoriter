using System;

using Newtonsoft.Json;

namespace FoodFavoriter.Domain
{
	public class PersonReference : IEquatable<PersonReference>
	{
		[JsonProperty()]
		readonly string Reference;

		[JsonConstructor]
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

		public override string ToString()
		{
			return Reference;
		}
	}
}
