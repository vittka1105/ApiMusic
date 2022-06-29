using ApiMusic.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMusic.Model;


namespace ApiMusic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : ControllerBase
    {
        public readonly MusicSearchClient _musicSearch;
        public readonly MusicAutoCompleteClient _musicAutoComplete;
        public readonly TopMusicClient _topMusic;
        public readonly RecommendationsClient _recommendations;
        public readonly TracksClient _tracks;
        public readonly DetailClient _detail;
        public readonly CountClient _count;
        public readonly TracksListClient _list;
        public readonly SpecificBookClient _specificBook;
        public readonly AllBooksClient _allBooks;
        public readonly PodcastClient _podcast;
        public readonly PlaylistsClient _playlists;
             

        private readonly ILogger<MusicController> _logger;

        public MusicController(ILogger<MusicController> logger, MusicSearchClient musicSearch, MusicAutoCompleteClient musicAutoComplete, TopMusicClient topMusic, RecommendationsClient recommendations, TracksClient musictracks, DetailClient detail, CountClient count, TracksListClient list, SpecificBookClient specificBook, AllBooksClient allBooks, PodcastClient podcast, PlaylistsClient playlists)
        {
            _logger = logger;
            _musicSearch = musicSearch;
            _musicAutoComplete = musicAutoComplete;
            _topMusic = topMusic;
            _recommendations = recommendations;
            _tracks = musictracks;
            _detail = detail;
            _count = count;
            _list = list;
            _specificBook = specificBook;
            _allBooks = allBooks;
            _podcast = podcast;
            _playlists = playlists;
        }

        [HttpGet("search")]
        public async Task<MusicSearchResponse> GetSearch ([FromQuery] MusicSearchParameters parameters)
        {
            MusicSearchClient musicSearchClient = new MusicSearchClient();
            var music = await _musicSearch.GetSearch(parameters.name);

            MusicSearchModel model = musicSearchClient.GetSearch(parameters.name).Result;

            var result = new MusicSearchResponse
            {
                SongTitle = music.tracks.hits.FirstOrDefault().track.title,
                Artist = music.tracks.hits.FirstOrDefault().track.subtitle,
                ShazamLink = music.tracks.hits.FirstOrDefault().track.share.href,
                SongImage = music.tracks.hits.FirstOrDefault().track.share.image,
                ArtistAvatar = music.artists.hits.FirstOrDefault().artist.avatar,
                ArtistName = music.artists.hits.FirstOrDefault().artist.name,
                ArtistLink = music.artists.hits.FirstOrDefault().artist.weburl
            };

            return result;
                
        }

        [HttpGet("{name}")]

        public async Task<MusicSearchModel> GetSearch([FromRoute] string name)
        {
            var _music = await _musicSearch.GetSearch(name);
            //var _result = new MusicSearchResponse
            //{
            //    SongTitle = _music.tracks.hits.FirstOrDefault().track.title,
            //    Artist = _music.tracks.hits.FirstOrDefault().track.subtitle,
            //    ShazamLink = _music.tracks.hits.FirstOrDefault().track.share.href,
            //    SongImage = _music.tracks.hits.FirstOrDefault().track.share.image,
            //    ArtistAvatar = _music.artists.hits.FirstOrDefault().artist.avatar,
            //    ArtistName = _music.artists.hits.FirstOrDefault().artist.name,
            //    ArtistLink = _music.artists.hits.FirstOrDefault().artist.weburl
            //};

            return _music;

        }

        [HttpGet("AutoComplete")]

        public async Task<MusicAutoCompleteModel> GetAutoComplete([FromQuery] MusicAutoCompleteParameters parameters)
        {
            MusicAutoCompleteClient musicAutoCompleteClient = new MusicAutoCompleteClient();

            var autocomplete = await _musicAutoComplete.GetAutoComplete(parameters.term);
            return autocomplete;
        }

        //[HttpGet("{term}")]

        //public async Task<MusicAutoCompleteModel> GetAutoComplete([FromRoute] string term)
        //{

        //    var _autocomplete = await _musicAutoComplete.GetAutoComplete(term);
        //    return _autocomplete;
        //}

        [HttpGet("TopList")]

        public async Task<TopListModel> GetTopList()
        {
            TopMusicClient topMusicClient = new TopMusicClient();

            var toplist = await _topMusic.GetTopList();
            return toplist;
        }

        [HttpGet("Details")]

        public async Task<DetailsModel> GetDetails()
        {
            DetailClient detailClient = new DetailClient();

            var details = await _detail.GetDetails();
            return details;
        }
        [HttpGet("Count")]

        public async Task<CountModel> GetCount()
        {
            CountClient detailClient = new CountClient();

            var counts = await _count.GetCount();
            return counts;
        }

        [HttpGet("Recommendations")]

        public async Task<RecommendModel> GetRecommendations()
        {
            RecommendationsClient recommendationsClient = new RecommendationsClient();

            var recommendationss = await _recommendations.GetRecommendations();
            return recommendationss;
            
        }

        [HttpGet("TracksList")]

        public async Task<TracksListModel> GetList()
        {
            TracksListClient listClient = new TracksListClient();

            var lists = await _list.GetList();
            return lists;

        }

        [HttpGet("Tracks")]
        
        public async Task<TracksModel> GetTracks()
        {
            TracksClient tracksClient = new TracksClient();

            var tracks = await _tracks.GetTracks();
            return tracks;
        }

        [HttpGet("Podcasts")]

        public async Task<PodcastModel> GetPodcast([FromQuery] PodcastParam podcastParam)
        {
            PodcastClient podcastClient = new PodcastClient();

            var podcasts = await _podcast.GetPodcast(podcastParam.name);
            return podcasts;
        }

        [HttpGet("Playlists")]

        public async Task<PlaylistsModel> GetPlaylists()
        {
            PlaylistsClient playlistsClient = new PlaylistsClient();

            var playlist = await _playlists.GetPlaylists();
            return playlist;
        }



        [HttpGet("SpecificBook")]

        public async Task<List<SpecificBookModel>> GetSpecificBook()
        {
            SpecificBookClient specificbookClient = new SpecificBookClient();

            var spbook = await _specificBook.GetSpecificBook();
            return spbook;
        }

        [HttpGet("AllBooks")]

        public async Task<List<AllBooksModel>> GetAllBooks()
        {
            AllBooksClient allbooksClient = new AllBooksClient();

            var allbook = await _allBooks.GetAllBooks();
            return allbook;
        }

    }
}
