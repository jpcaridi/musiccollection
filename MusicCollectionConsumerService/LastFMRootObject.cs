using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionConsumerService
{
    public class LastFMRootObject
    {
        public LastFMResults results { get; set; }
    }

    public class LastFMResults
    {
        public LastFMOpensearchQuery opensearchQuery { get; set; }
        public string opensearchtotalResults { get; set; }
        public string opensearchstartIndex { get; set; }
        public string opensearchitemsPerPage { get; set; }
        public LastFMAlbummatches albummatches { get; set; }
        public LastFMAttr attr { get; set; }
    }

    public class LastFMOpensearchQuery
    {
        public string text { get; set; }
        public string role { get; set; }
        public string searchTerms { get; set; }
        public string startPage { get; set; }
    }

    public class LastFMAlbummatches
    {
        public LastFMAlbum[] album { get; set; }
    }

    public class LastFMAlbum
    {
        public string name { get; set; }
        public string artist { get; set; }
        public string url { get; set; }
        public LastFMImage[] image { get; set; }
        public string streamable { get; set; }
        public string mbid { get; set; }
    }

    public class LastFMImage
    {
        public string text { get; set; }
        public string size { get; set; }
    }

    public class LastFMAttr
    {
        public string LastFM_for { get; set; }
    }
}
