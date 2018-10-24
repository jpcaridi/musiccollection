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
            string albumName = "";
            string artist = "";
            string yearStr = "";
            string playCountStr = "";
            string url = "";
            
            albumName = ReadElement(albumElement, "Name");
            artist = ReadElement(albumElement, "Artist");
            
            yearStr = ReadElement(albumElement, "Year");
            uint year = 1900;
            uint.TryParse(yearStr, out year);
            
            playCountStr = ReadElement(albumElement, "PlayCount");
            int playCount = 0;
            int.TryParse(playCountStr, out playCount);
            
            url = ReadElement(albumElement, "URL");

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

