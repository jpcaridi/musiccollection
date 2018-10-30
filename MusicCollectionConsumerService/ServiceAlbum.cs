using MusicCollectionModel.Interfaces;

namespace MusicCollectionConsumerService
{
    internal class ServiceAlbum : IAlbum
    {
        private ServiceAlbum()
        {
        }

        /// <summary>
        /// Create a new service album instance
        /// </summary>
        /// <returns>a new service album</returns>
        public static ServiceAlbum CreateInstance(LastFmAlbum lastFmAlbum, uint year)
        {
            return new ServiceAlbum
            {
                Name = lastFmAlbum.Name,
                Artist = lastFmAlbum.Artist,
                Year = year,
                PlayCount = 0,
                Url = lastFmAlbum.Url
            };
        }

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
