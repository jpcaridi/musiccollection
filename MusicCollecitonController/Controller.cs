using System;
using System.Collections.Generic;
using MusicCollectionModel;
using MusicCollectionData;
using MusicCollectionConsumerService;

namespace MusicCollecitonController
{
    /// <summary>
    /// Control of actions to the music collection
    /// </summary>
    public class Controller
    {

        /// <summary>
        /// Remove an album from the library if it exists
        /// </summary>
        /// <param name="albumLibrary">The album library</param>
        /// <param name="album">The album to remove from the library</param>
        /// <returns>true on success. false otherwise</returns>
        public static bool DeleteAlbum(AlbumLibrary albumLibrary, Album album)
        {
            return albumLibrary.RemoveAlbum(album);
        }

        /// <summary>
        /// 
        /// </summary>
        public static IList<Album> Search(string searchString)
        {
            if (searchString == null) throw new ArgumentNullException(nameof(searchString));
            return ConsumerService.Search(searchString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumLibrary"></param>
        /// <param name="album"></param>
        public static void AddAlbum(AlbumLibrary albumLibrary, Album album)
        {
            albumLibrary.AddAlbum(album);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static AlbumLibrary ReadLibrary()
        {
            AlbumLibrary albumLibrary = new AlbumLibrary();

            AlbumLibraryPersistance.ReadCollection(albumLibrary);

            return albumLibrary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumLibrary"></param>
        /// <returns></returns>
        public static bool WriteLibrary(AlbumLibrary albumLibrary)
        {
            AlbumLibraryPersistance.WriteCollection(albumLibrary);
            return true;
        }

    }
}
