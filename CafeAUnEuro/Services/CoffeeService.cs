using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CafeAUnEuro
{
	public class CoffeeService : ICoffeeService
	{
		private const string url = "https://opendata.paris.fr/api/records/1.0/search/?dataset=liste-des-cafes-a-un-euro&facet=arrondissement";

		public async Task<List<string>> GetCoffeesDataAsync()
		{
			await Task.Delay(1000);

			List<string> data = new List<string> { "coffe1", "coffe2", "coffee3" };
			return data;
		}

		public async Task<IList<Record>> GetCoffeesAsync()
		{
			string jsonData;
			using (var client = new HttpClient())
			{
				jsonData = await client.GetStringAsync(url);
				var serializer = new DataContractJsonSerializer(typeof(Example));

			}

			var result = JsonConvert.DeserializeObject<Example>(jsonData);

			return result.records;
		}
	}
}
