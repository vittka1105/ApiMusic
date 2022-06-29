using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiMusic.Model;

namespace ApiMusic.Clients
{
    public class TracksClient
    {
        private HttpClient _client4;
        private static string _address;
        private static string _apikey;

        public TracksClient()
        {
            _address = Constants._adress;
            _apikey = Constants._key;

            _client4 = new HttpClient();
            _client4.BaseAddress = new Uri(_address);


        }

        public async Task<TracksModel> GetTracks()
        {
            HttpClient _client4 = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://shazam.p.rapidapi.com/charts/track?locale=en-US&pageSize=20&startFrom=0"),
                Headers =
                {
                    { "X-RapidAPI-Host", "shazam.p.rapidapi.com"},
                    {"X-RapidAPI-Key", "ac3e50bb89msh3e65ace965500b4p11c35ajsnc402e86aef1b" },

                },
            };

            var responce = await _client4.SendAsync(request);
            responce.EnsureSuccessStatusCode();
            var content = await responce.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TracksModel>(content);
            return result;
        }
    }
}
