using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMusic.Model
{
    public class MusicSearchResponse
    {
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string ShazamLink { get; set; }
        public string SongImage { get; set; }
        public string ArtistAvatar { get; set; }
        public string ArtistName { get; set; }
        public string ArtistLink { get; set; }
    }
}
