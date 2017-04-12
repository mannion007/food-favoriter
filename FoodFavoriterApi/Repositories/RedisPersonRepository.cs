using System;
using Sider;
using FoodFavoriter.Domain;
using Newtonsoft.Json;

namespace FoodFavoriter.Api.Repositories
{
	public class RedisPersonRepository : IStorePeople
	{
		readonly RedisClient connection;

		public RedisPersonRepository()
		{
			connection = new RedisClient();
		}

		public Person FindPersonWithReference(PersonReference reference)
		{
			var result = connection.Get(reference.ToString());

			if (result == null)
			{
				throw new Exception("Cannot find person with reference");
			}
			return JsonConvert.DeserializeObject<Person>(result);

		}

		public void Save(Person person)
		{
			var val = JsonConvert.SerializeObject(person);
			connection.Set(person.Reference.ToString(), val);
		}
	}
}
