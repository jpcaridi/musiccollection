﻿namespace MusicCollectionModel.Interfaces
{
    /// <summary>
    /// Represents a music collection album
    /// </summary>
    public interface IAlbum
    {
        /// <summary>
        /// Name of the album
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Artist of the album
        /// </summary>
        string Artist { get; set; }

        /// <summary>
        /// Year the album was recorded or attributed 
        /// </summary>
        uint Year { get; set; }

        /// <summary>
        /// Number of plays this album has had.
        /// </summary>
        int PlayCount { get; set; }

        /// <summary>
        /// The url to the album
        /// </summary>
        string Url { get; set; }
    }
}
