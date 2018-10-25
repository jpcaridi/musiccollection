using System;
using System.Collections.Generic;
using MusicCollectionConsumerService;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionController
{
    /// <summary>
    /// Control of actions to the music collection
    /// </summary>
    public class Controller
    {

        /// <summary>
        /// Create a library
        /// </summary>
        /// <param name="albumPersistance"></param>
        /// <param name="libraryName"></param>
        /// <returns></returns>
        public static IAlbumLibrary CreateLibrary(IAlbumPersistance albumPersistance, string libraryName)
        {
            return albumPersistance.CreateEmptyLibrary(libraryName);
        }

        /// <summary>
        /// Remove an album from the library if it exists
        /// </summary>
        /// <param name="albumLibrary">The album library</param>
        /// <param name="album">The album to remove from the library</param>
        /// <returns>true on success. false otherwise</returns>
        public static bool DeleteAlbum(IAlbumLibrary albumLibrary, IAlbum album)
        {
            if (album == null) throw new ArgumentNullException(nameof(album));
            return albumLibrary.RemoveAlbum(album);
        }

        /// <summary>
        /// 
        /// </summary>
        public static IList<IAlbum> Search(string searchString)
        {
            if (searchString == null) throw new ArgumentNullException(nameof(searchString));
            return LastFmService.Search(searchString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumLibrary"></param>
        /// <param name="album"></param>
        public static void AddAlbum(IAlbumLibrary albumLibrary, IAlbum album)
        {
            if (album == null) throw new ArgumentNullException(nameof(album));

            albumLibrary.AddAlbum(album);
        }

        public static void AddAlbum(IAlbumLibrary albumLibrary, string name, string artist, uint year, string url)
        {
            //TODO: Implement the IAlbum interface to allow the addition of albums.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IAlbumLibrary ReadLibrary(IAlbumPersistance albumPersistance, string libraryName)
        {
            return albumPersistance.RetrieveCollection(libraryName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumPersistance"></param>
        /// <param name="albumLibrary"></param>
        /// <returns></returns>
        public static bool WriteLibrary(IAlbumPersistance albumPersistance, IAlbumLibrary albumLibrary)
        {
            return albumPersistance.WriteCollection(albumLibrary);
        }

    }
}
