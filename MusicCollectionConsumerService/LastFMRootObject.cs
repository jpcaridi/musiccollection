namespace MusicCollectionConsumerService
{
    public class LastFmRootObject
    {
        public LastFmResults Results { get; set; }
    }

    public class LastFmResults
    {
        public LastFmOpensearchQuery OpensearchQuery { get; set; }
        public string OpensearchtotalResults { get; set; }
        public string OpensearchstartIndex { get; set; }
        public string OpensearchitemsPerPage { get; set; }
        public LastFmAlbummatches Albummatches { get; set; }
        public LastFmAttr Attr { get; set; }
    }

    public class LastFmOpensearchQuery
    {
        public string Text { get; set; }
        public string Role { get; set; }
        public string SearchTerms { get; set; }
        public string StartPage { get; set; }
    }

    public class LastFmAlbummatches
    {
        public LastFmAlbum[] Album { get; set; }
    }

    public class LastFmAlbum
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Url { get; set; }
        public LastFmImage[] Image { get; set; }
        public string Streamable { get; set; }
        public string Mbid { get; set; }
    }

    public class LastFmImage
    {
        public string Text { get; set; }
        public string Size { get; set; }
    }

    public class LastFmAttr
    {
        public string LastFmFor { get; set; }
    }
}
