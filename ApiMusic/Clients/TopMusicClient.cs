using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiMusic.Model;

namespace ApiMusic.Clients
{
    public class TopMusicClient
    {
        private HttpClient _client2;
        private static string _address;
        private static string _apikey;

        public TopMusicClient()
        {
            _address = Constants._adress;
            _apikey = Constants._key;

            _client2 = new HttpClient();
            _client2.BaseAddress = new Uri(_address);


        }

        public async Task<TopListModel> GetTopList()
        {
            HttpClient _client2 = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://shazam.p.rapidapi.com/songs/list-artist-top-tracks?id=40008598&locale=en-US"),
                Headers =
                {
                    { "X-RapidAPI-Host", "shazam.p.rapidapi.com"},
                    {"X-RapidAPI-Key", "ac3e50bb89msh3e65ace965500b4p11c35ajsnc402e86aef1b" },

                },
            };

            var responce = await _client2.SendAsync(request);
            responce.EnsureSuccessStatusCode();
            var content = await responce.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TopListModel>(content);
            return result;
        }
    }
}
