using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicCollectionController;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionTest
{
    [TestClass]
    public class DataTest
    {
        /// <summary>
        /// TEST_LoadLibrary
        /// </summary>
        [TestMethod]
        public void TEST_LoadLibrary()
        {
            string TEST_LIBRARY_NAME = "TEST_LIBRARY";

            IMusicCollection musicCollection = Driver.CreateXmlMusicCollection();
            IAlbumLibrary library = Controller.ReadLibrary(musicCollection.Persistance, TEST_LIBRARY_NAME);
            Assert.IsNotNull(library, "Loading " + TEST_LIBRARY_NAME + " should not be null.");

            int count = 0;
            foreach (IAlbum a in library.Albums)
            {
                count++;
            }

            Assert.IsTrue(count == 3, "There should be exactly 2 albums in the library.");
        }
    }
}
