using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiMusic.Model;

namespace ApiMusic.Clients
{
    public class DetailClient
    {
		public async Task<DetailsModel> GetDetails()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://shazam.p.rapidapi.com/songs/get-details?key=40333609&locale=en-US"),
				Headers =
	            {
		          { "X-RapidAPI-Key", "ac3e50bb89msh3e65ace965500b4p11c35ajsnc402e86aef1b" },
		          { "X-RapidAPI-Host", "shazam.p.rapidapi.com" },
	            },
			};
			var response = await client.SendAsync(request);
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				Console.WriteLine(body);
				var res = JsonConvert.DeserializeObject<DetailsModel>(body);

				return res;
			}


		}
	}
}
