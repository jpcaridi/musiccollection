using System;
using System.Xml.Linq;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionData
{
    /// <summary>
    /// Represents a single album.
    /// </summary>
    internal class XmlAlbum : IAlbum
    {
        private XmlAlbum() { }

        /// <summary>
        /// Constructor for a new Album
        /// </summary>
        /// <param name="name">Name of the album</param>
        /// <param name="artist">Artist of the album</param>
        /// <param name="year">Year the album was recorded or attributed</param>
        private XmlAlbum(string name, string artist, uint year, string url)
        {
            Name = name;
            Artist = artist;
            Year = year;
            PlayCount = 0;
            Url = url;
        }

        public static XmlAlbum CreateInstance(XElement albumElement)
        {
            string albumName = "";
            string artist = "";
            string yearStr = "";
            string url = "";

            XElement albumNameEl = albumElement.Element("Name");
            albumName = albumNameEl?.Value;

            XElement artistEl = albumElement.Element("Artist");
            artist = artistEl?.Value;

            XElement yearEl = albumElement.Element("Year");
            yearStr = yearEl?.Value;
            uint year = uint.Parse(yearStr);

            XElement urlEl = albumElement.Element("URL");
            url = urlEl?.Value;

            return new XmlAlbum(albumName, artist, year, url);
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

