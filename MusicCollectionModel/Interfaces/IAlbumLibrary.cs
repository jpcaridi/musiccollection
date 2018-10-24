using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionModel.Interfaces
{
    /// <summary>
    /// IAlbumLibrary interface
    /// </summary>
    public interface IAlbumLibrary
    {

        string LibraryName { get; set; }

        /// <summary>
        /// Album library as a list
        /// </summary>
        IReadOnlyList<IAlbum> Albums { get;}

        /// <summary>
        /// Add a new album to the library
        /// </summary>
        /// <param name="album">The album to add</param>
        void AddAlbum(IAlbum album);

        /// <summary>
        /// Remove an album from the library
        /// </summary>
        /// <param name="album">The album to remove</param>
        /// <returns></returns>
        bool RemoveAlbum(IAlbum album);
    }
}
