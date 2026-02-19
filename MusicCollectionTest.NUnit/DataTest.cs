using NUnit.Framework;
using MusicCollectionController;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionTest.NUnit
{
    [TestFixture]
    public class DataTest
    {

        private class TestAlbum : IAlbum
        {
            public string Name { get; set; } = "";
            public string Artist { get; set; } = "";
            public uint Year { get; set; }
            public int PlayCount { get; set; }
            public string Url { get; set; } = "";
        }

        private class TestUserInfo : IUserInfo
        {
            public int UserId => 1;
            public string UserName => "test";
        }

        /// <summary>
        /// TEST_XmlLibrary
        /// </summary>
        [Test]
        public void TEST_XmlLibrary()
        {
            const string testLibraryName = "test_LIBRARY";

            IMusicCollection musicCollection = Driver.CreateXmlMusicCollection();
            TestUserInfo userInfo = new TestUserInfo();

            IAlbumLibrary library = Controller.CreateLibrary(musicCollection.Persistance, userInfo, testLibraryName);

            Assert.That(library.LibraryName, Is.EqualTo(testLibraryName), "Library name does not match expected " + testLibraryName);

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

            Assert.That(albums.Length == library.Albums.Count, Is.True, "Not all albums added to library.");

            int location = 0;
            foreach (IAlbum a in library.Albums)
            {
                Assert.That(a.Name == albums[location].Name, Is.True, "Name does not match.");
                Assert.That(a.Artist == albums[location].Artist, Is.True, "Artist does not match.");
                Assert.That(a.PlayCount == albums[location].PlayCount, Is.True, "Playcount does not match.");
                Assert.That(a.Url == albums[location].Url, Is.True, "Url does not match.");
                Assert.That(a.Year == albums[location].Year, Is.True, "Year does not match.");

                location++;
            }


            Assert.That(Controller.WriteLibrary(musicCollection.Persistance, library), Is.True, "Count not save the library.");
        }

        /// <summary>
        /// TEST_LoadLibrary
        /// </summary>
        [Test]
        public void TEST_LoadLibrary()
        {
            const string testLibraryName = "test_LIBRARY";

            IMusicCollection musicCollection = Driver.CreateXmlMusicCollection();
            IAlbumLibrary library = Controller.ReadLibrary(musicCollection.Persistance, testLibraryName);
            Assert.That(library, Is.Not.Null, "The library " + testLibraryName + " should not be null.");

            Assert.That(library, Is.Not.Null, "Loading " + testLibraryName + " should not be null.");
            Assert.That(library.Albums.Count == 3, Is.True, "There should be exactly 3 albums in the library.");

            foreach (IAlbum a in library.Albums)
            {
                Assert.That(a.Artist, Is.Not.Null, "Artist should not be null");
                Assert.That(a.Name, Is.Not.Null, "Name should not be null");
                Assert.That(a.PlayCount, Is.Not.Null, "PlayCount should not be null");
                Assert.That(a.Url, Is.Not.Null, "Url should not be null");
                Assert.That(a.Year, Is.Not.Null, "Year should not be null");
            }

        }

        /// <summary>
        /// TEST_LogIn
        /// </summary>
        [Test]
        public void TEST_LogIn()
        {
            const string testUserName = "test";
            const string testPassword = "test";
            const string testBadPassword = "test123";

            IMusicCollection musicCollection = Driver.CreateXmlMusicCollection();
            IUserInfo userInfo = Controller.LogIn(musicCollection.LogInService, testUserName, testPassword);

            /* Test successful log in.*/
            Assert.That(userInfo, Is.Not.Null, "User should not be null.");
            Assert.That(userInfo.UserName.Equals(testUserName), Is.True, "User name does not match.");

            /* Test a bad login.*/
            userInfo = Controller.LogIn(musicCollection.LogInService, testUserName, testBadPassword);
            Assert.That(userInfo, Is.Null, "A bad log in should return a null user");
        }
    }
}
