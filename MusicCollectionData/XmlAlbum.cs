using System.Xml.Linq;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionData
{
    /// <summary>
    /// Represents a single album.
    /// </summary>
    internal class XmlAlbum : IAlbum
    {
        /// <summary>
        /// Constructor for a new Album
        /// </summary>
        /// <param name="name">Name of the album</param>
        /// <param name="artist">Artist of the album</param>
        /// <param name="year">Year the album was recorded or attributed</param>
        /// <param name="playCount"></param>
        /// <param name="url"></param>
        private XmlAlbum(string name, string artist, uint year, int playCount, string url)
        {
            Name = name;
            Artist = artist;
            Year = year;
            PlayCount = playCount;
            Url = url;
        }

        public static XmlAlbum CreateInstance(XElement albumElement)
        {
            var albumName = ReadElement(albumElement, "Name");
            var artist = ReadElement(albumElement, "Artist");
            
            var yearStr = ReadElement(albumElement, "Year");
            uint year;
            uint.TryParse(yearStr, out year);
            
            var playCountStr = ReadElement(albumElement, "PlayCount");
            int playCount;
            int.TryParse(playCountStr, out playCount);
            
            var url = ReadElement(albumElement, "URL");

            return new XmlAlbum(albumName, artist, year, playCount, url);
        }

        private static string ReadElement(XElement albumElement, XName name)
        {
            string value;
            try
            {
                XElement el = albumElement.Element(name);
                value = el?.Value;
            }
            catch 
            {
                value = " ";
            }

            return value;
        }

        /// <summary>
        /// Name of the album
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Artist of the album
        /// </summary>
        public string Artist
        {
            get;
            set;
        }

        /// <summary>
        /// Year the album was recorded or attributed 
        /// </summary>
        public uint Year
        {
            get;
            set;
        }

        /// <summary>
        /// Number of plays this album has had.
        /// </summary>
        public int PlayCount
        { get; set; }

        /// <summary>
        /// The url to the album
        /// </summary>
        public string Url { get; set; }
    }
}

