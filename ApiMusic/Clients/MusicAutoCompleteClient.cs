using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ApiMusic.Model;

namespace ApiMusic.Clients
{
    public class MusicAutoCompleteClient
    {
        private HttpClient _client1;
        private static string _address;
        private static string _apikey;

        public MusicAutoCompleteClient()
        {
            _address = Constants._adress;
            _apikey = Constants._key;

            _client1 = new HttpClient();
            _client1.BaseAddress = new Uri(_address);


        }

        public async Task<MusicAutoCompleteModel> GetAutoComplete(string Term)
        {
            HttpClient _client1 = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://shazam.p.rapidapi.com/auto-complete?term={Term}&locale=en-US"),
                Headers =
                {
                    { "X-RapidAPI-Host", "shazam.p.rapidapi.com"},
                    {"X-RapidAPI-Key", "ac3e50bb89msh3e65ace965500b4p11c35ajsnc402e86aef1b" },

                },
            };

            var responce = await _client1.SendAsync(request);
            responce.EnsureSuccessStatusCode();
            var content = await responce.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<MusicAutoCompleteModel>(content);
            return result;
        }

    }
}
