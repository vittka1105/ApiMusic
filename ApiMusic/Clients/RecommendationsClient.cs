using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiMusic.Model;


namespace ApiMusic.Clients
{
    public class RecommendationsClient
    {
        private HttpClient _client3;
        private static string _address;
        private static string _apikey;

        public RecommendationsClient()
        {
            _address = Constants._adress;
            _apikey = Constants._key;

            _client3 = new HttpClient();
            _client3.BaseAddress = new Uri(_address);


        }

        public async Task<RecommendModel> GetRecommendations()
        {
            HttpClient _client3 = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://shazam.p.rapidapi.com/songs/list-recommendations?key=484129036&locale=en-US"),
                Headers =
                {
                    { "X-RapidAPI-Host", "shazam.p.rapidapi.com"},
                    {"X-RapidAPI-Key", "ac3e50bb89msh3e65ace965500b4p11c35ajsnc402e86aef1b" },

                },
            };

            var responce = await _client3.SendAsync(request);
            responce.EnsureSuccessStatusCode();
            var content = await responce.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<RecommendModel>(content);
            return result;
        }
    }
}
