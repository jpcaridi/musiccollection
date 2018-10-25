﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicCollectionController;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionTest
{
    [TestClass]
    public class DataTest
    {

        private class TestAlbum : IAlbum
        {
            public string Name { get; set; }
            public string Artist { get; set; }
            public uint Year { get; set; }
            public int PlayCount { get; set; }
            public string Url { get; set; }
        }

        /// <summary>
        /// TEST_XmlLibrary
        /// </summary>
        [TestMethod]
        public void TEST_XmlLibrary()
        {
            const string TEST_LIBRARY_NAME = "TEST_LIBRARY";

            IMusicCollection musicCollection = Driver.CreateXmlMusicCollection();
            IAlbumLibrary library = Controller.CreateLibrary(musicCollection.Persistance, TEST_LIBRARY_NAME);

            Assert.AreEqual(library.LibraryName, TEST_LIBRARY_NAME, "Library name does not match expected " + TEST_LIBRARY_NAME);

            TestAlbum[] albums = {
                new TestAlbum {Name = "London Calling", Artist = "The Clash", Year = 1979, PlayCount = 1},
                new TestAlbum {Name = "Nevermind", Artist = "Nirvana", Year = 1991, PlayCount = 0},
                new TestAlbum
                {
                    Name = "musicforthemorningafter",
                    Artist = "Pete Yorn",
                    Year = 2002,
                    PlayCount = 0,
                    Url = "https://www.last.fm/music/Pete+Yorn/musicforthemorningafter"
                }
            };

            foreach (TestAlbum a in albums)
            {
                Controller.AddAlbum(library, a);
            }

            //TODO Test each album was added to the list
            //TODO Test the persistance and load
        }

        /// <summary>
        /// TEST_LoadLibrary
        /// </summary>
        [TestMethod]
        public void TEST_LoadLibrary()
        {
            const string TEST_LIBRARY_NAME = "TEST_LIBRARY";

            IMusicCollection musicCollection = Driver.CreateXmlMusicCollection();
            IAlbumLibrary library = Controller.ReadLibrary(musicCollection.Persistance, TEST_LIBRARY_NAME);

            Assert.IsNotNull(library, "Loading " + TEST_LIBRARY_NAME + " should not be null.");
            Assert.IsTrue(library.Albums.Count == 3, "There should be exactly 3 albums in the library.");
            
            foreach (IAlbum a in library.Albums)
            {
                Assert.IsNotNull(a.Artist, "Artist should not be null");
                Assert.IsNotNull(a.Name, "Name should not be null");
                Assert.IsNotNull(a.PlayCount, "PlayCount should not be null");
                Assert.IsNotNull(a.Url, "Url should not be null");
                Assert.IsNotNull(a.Year, "Year should not be null");
            }

        }

        [ClassCleanup]
        public static void CleanupTest()
        {

        }
    }
}
