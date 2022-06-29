using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiMusic.Model;
using Newtonsoft.Json;

namespace ApiMusic.Clients
{
    public class PlaylistsClient
    {
		public async Task<PlaylistsModel> GetPlaylists()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://spotify23.p.rapidapi.com/playlist_tracks/?id=37i9dQZF1DX4Wsb4d7NKfP&offset=0&limit=100"),
				Headers =
				{
				  { "X-RapidAPI-Key", "ac3e50bb89msh3e65ace965500b4p11c35ajsnc402e86aef1b" },
				  { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
				},
			};
			var response = await client.SendAsync(request);
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				Console.WriteLine(body);
				var res = JsonConvert.DeserializeObject<PlaylistsModel>(body);

				return res;
			}


		}
	}
}
