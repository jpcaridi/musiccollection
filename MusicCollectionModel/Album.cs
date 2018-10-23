using System;

namespace MusicCollectionModel
{
    /// <summary>
    /// Represents a single album.
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Constructor for a new Album
        /// </summary>
        /// <param name="name">Name of the album</param>
        /// <param name="artist">Artist of the album</param>
        /// <param name="year">Year the album was recorded or attributed</param>
        public Album(string name, string artist, uint year)
        {
            Name = name;
            Artist = artist;
            Year = year;
            PlayCount = 0;
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
    }
}

