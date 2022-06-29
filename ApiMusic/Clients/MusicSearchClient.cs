using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiMusic.Model;

namespace ApiMusic.Clients
{
    public class MusicSearchClient
    {
        private HttpClient _client;
        private static string _address;
        private static string _apikey;

        public MusicSearchClient()
        {
            _address = Constants._adress;
            _apikey = Constants._key;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);


        }

        public async Task <MusicSearchModel> GetSearch(string Name)
        {
            HttpClient _client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri ($"https://shazam.p.rapidapi.com/search?term={Name}&locale=en-US&offset=0&limit=5"),
                Headers =
                {
                    { "X-RapidAPI-Host", "shazam.p.rapidapi.com"},
                    {"X-RapidAPI-Key", "ac3e50bb89msh3e65ace965500b4p11c35ajsnc402e86aef1b" },

                },
            };

            var responce = await _client.SendAsync(request);
            responce.EnsureSuccessStatusCode();
            var content = await responce.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<MusicSearchModel>(content);
            return result;
        }

        
    }
}
