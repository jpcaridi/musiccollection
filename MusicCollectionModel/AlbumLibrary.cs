using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionModel
{
    /// <summary>
    /// Represents a collection of albums
    /// </summary>
    public class AlbumLibrary
    {
        /// <summary>
        /// Construct a new album library
        /// </summary>
        public AlbumLibrary(string libraryName)
        {
            LibraryName = libraryName;
            _mAlbums = new List<Album>();
        }

        public string LibraryName { get; set; }

        private readonly List<Album> _mAlbums;
        /// <summary>
        /// Get the album library as a list
        /// </summary>
        public IReadOnlyList<Album> Albums => _mAlbums.AsReadOnly();

        /// <summary>
        /// Add a new album to the library
        /// </summary>
        /// <param name="album">The album to add</param>
        public void AddAlbum(Album album)
        {
            if (!_mAlbums.Contains(album))
            {
                _mAlbums.Add(album);
            }
        }

        /// <summary>
        /// Remove an album from the library
        /// </summary>
        /// <param name="album">The album to remove</param>
        /// <returns></returns>
        public bool RemoveAlbum(Album album)
        {
            return _mAlbums.Contains(album) && _mAlbums.Remove(album);
        }
    }
}
