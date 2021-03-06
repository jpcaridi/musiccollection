﻿using System;
using System.Collections.Generic;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionController
{
    /// <summary>
    /// Control of actions to the music collection
    /// </summary>
    public class Controller
    {

        /// <summary>
        /// Log into the system
        /// </summary>
        /// <param name="logInService"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static IUserInfo LogIn(ILogInService logInService, string userName, string password)
        {
            return logInService.LogIn(userName, password);
        }

        public static bool ChangePassword(ILogInService logInService, IUserInfo userInfo, string currentPassword, string newPassword)
        {
            return logInService.ChangePassword(userInfo, currentPassword, newPassword);
        }

        /// <summary>
        /// Create a library
        /// </summary>
        /// <param name="albumPersistance"></param>
        /// <param name="libraryName"></param>
        /// <returns></returns>
        public static IAlbumLibrary CreateLibrary(IAlbumPersistance albumPersistance, IUserInfo userInfo, string libraryName)
        {
            return albumPersistance.CreateEmptyLibrary(userInfo, libraryName);
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
        public static IList<IAlbum> Search(IConsumerService consumerService, string searchString)
        {
            if (searchString == null) throw new ArgumentNullException(nameof(searchString));
            if (consumerService == null) throw new ArgumentNullException(nameof(consumerService));

            return consumerService.Search(searchString);
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

        public static IAlbumLibrary ReadLibrary(IAlbumPersistance albumPersistance, IUserInfo userInfo)
        {
            return albumPersistance.RetrieveCollection(userInfo);
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
