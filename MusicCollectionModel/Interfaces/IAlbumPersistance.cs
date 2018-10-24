﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionModel.Interfaces
{
    public interface IAlbumPersistance
    {
        /// <summary>
        /// Retrieve Library Collection
        /// </summary>
        /// <param name="libraryName">The name of the library to retrieve</param>
        /// <returns>The library with the given name. Returns null if it does not exist</returns>
        IAlbumLibrary RetrieveCollection(string libraryName);
        
        /// <summary>
        /// Write the collection to the persistant store
        /// </summary>
        /// <param name="albumLibrary">The library collection to save</param>
        /// <returns>True if the collection has been stored. False otherwise</returns>
        bool WriteCollection(IAlbumLibrary albumLibrary);
    }
}