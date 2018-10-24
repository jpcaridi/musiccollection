using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionModel.Interfaces
{
    /// <summary>
    /// Service for a Music Collection
    /// </summary>
    public interface IConsumerService
    {
        /// <summary>
        /// Search for an album
        /// </summary>
        /// <param name="searchString">The search criteria</param>
        /// <returns>A collection of albums that match the search</returns>
        IList<IAlbum> Search(string searchString);
    }
}
