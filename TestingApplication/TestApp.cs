using MusicCollectionData;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace TestingApplication
{
    public class TestApp
    {
        private static readonly String ALBUMS_FILE = "Albums.xml";
        private static readonly String LAST_FM_ROOT_URL = "http://ws.audioscrobbler.com/2.0/";
        private static readonly String MB_ROOT_URL = "http://musicbrainz.org/ws/2/";
        public static void Main(string[] args)
        {
            MusicCollection musicCollection = new MusicCollection();
            ReadCollection(musicCollection);
            String choice = "0";

            do
            {
                Console.Out.WriteLine("   -- Menu -- ");
                Console.Out.WriteLine("1 - Print Collection ");
                Console.Out.WriteLine("2 - Add Album ");
                Console.Out.WriteLine("3 - Delete Album ");
                Console.Out.WriteLine("4 - Save Collection ");
                Console.Out.WriteLine("5 - Search");
                Console.Out.WriteLine("0 - Exit ");
                Console.Out.Write("Please Enter a Selection: ");
                choice = Console.In.ReadLine().Trim();


            } while (!ProcessChoice(choice, musicCollection));
        }

        private static bool ProcessChoice(String choice, MusicCollection musicCollection)
        {
            bool exit = false;

            switch (choice)
            {
                case "1":
                    PrintCollection(musicCollection);
                    break;
                case "2":
                    AddAlbum(musicCollection);
                    break;
                case "3":
                    DeleteAlbum(musicCollection);
                    break;
                case "4":
                    WriteCollection(musicCollection);
                    break;
                case "5":
                    Search(musicCollection);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    break;
            }

            return exit;
        }

        private static void DeleteAlbum(MusicCollection musicCollection)
        {

            PrintCollection(musicCollection);

            Console.Out.Write("Enter an album number to delete: ");
            String entry = Console.In.ReadLine().Trim();
            int albumNumber;

            if (Int32.TryParse(entry, out albumNumber))
            {
                albumNumber -= 1;
                if (albumNumber >= 0 && albumNumber < musicCollection.Albums.Count)
                {
                    MusicCollectionAlbum album = musicCollection.Albums[albumNumber];
                    if (musicCollection.RemoveAlbum(album))
                    {
                        Console.Out.WriteLine("Abum has been deleted.");
                    }
                    else
                    {
                        Console.Out.WriteLine("Unable to delete album.");
                    }
                }
            }
        }

        private static void Search(MusicCollection musicCollection)
        {
            String method = "?method=album.search";
            String api_key = "&api_key=479c5b7243a02e8985b3728d483882c0";
            String format = "&limit=20&format=json";
            String url;
            String searchString;
            String albumString = "&album=";

            Console.Out.Write("Enter an album search: ");
            searchString = Console.In.ReadLine().Trim();
            albumString += searchString;

            //"?method=album.search&album=nevermind&api_key=479c5b7243a02e8985b3728d483882c0&format=json"
            url = "" + LAST_FM_ROOT_URL + method + albumString + api_key + format;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    String text = sr.ReadToEnd();

                    TestingApplication.JsonTest.Rootobject rootObject = JToken.Parse(text).ToObject<TestingApplication.JsonTest.Rootobject>();

                    TestingApplication.JsonTest.Album[] albums = rootObject.results.albummatches.album;

                    Console.Out.WriteLine("\nSearch results (" + albums.Length + " items)");
                    int num = 1;
                    foreach (TestingApplication.JsonTest.Album a in albums)
                    {
                        if (!a.mbid.Equals(""))
                        {
                            UInt32 year = RetrieveAlbumYear(a);
                            Console.Out.WriteLine("" + num + ".  Name: " + a.name + " Artist: " + a.artist + " Year:" + year /*+ " MBID: " + a.mbid*/);
                        }
                        num++;
                    }

                    Console.Out.Write("Add to collection (Enter Number - 0 to not add)? ");
                    String selection = Console.In.ReadLine().Trim();
                    Int32 choice = Int32.Parse(selection) - 1;

                    if (choice >= 0 && choice < albums.Length)
                    {
                        TestingApplication.JsonTest.Album album = albums[choice];
                        UInt32 year = RetrieveAlbumYear(album);

                        musicCollection.AddAlbum(new MusicCollectionAlbum(album.name, album.artist, year));
                    }

                }
            }
        }

        private static UInt32 RetrieveAlbumYear(TestingApplication.JsonTest.Album album)
        {
            UInt32 releaseYear = 1900;
            String method = "release/";
            String format = "?fmt=json";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(MB_ROOT_URL + method + album.mbid + format);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";
            httpWebRequest.UserAgent = "MusicCollection/1.0.0 (jpcaridi@gmail.com)";

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    String text = sr.ReadToEnd();

                    TestingApplication.MBJson.RootObject rootObject = JToken.Parse(text).ToObject<MBJson.RootObject>();

                    if (rootObject.date != null)
                    {
                       releaseYear = uint.Parse(rootObject.date.Substring(0, 4));
                    }
                }
            }
            return releaseYear;
        }

        private static void AddAlbum(MusicCollection musicCollection)
        {

            Console.Out.Write("Album Name: ");
            String name = Console.In.ReadLine();

            Console.Out.Write("Album Artist: ");
            String artist = Console.In.ReadLine();

            Console.Out.Write("Album Year: ");
            String yearString = Console.In.ReadLine();
            UInt32 year = UInt32.Parse(yearString);

            musicCollection.AddAlbum(new MusicCollectionAlbum(name, artist, year));
        }

        private static void ReadCollection(MusicCollection musicCollection)
        {
            using (XmlReader reader = XmlReader.Create(ALBUMS_FILE, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                reader.MoveToContent();
                reader.ReadStartElement("Albums");

                while (!reader.EOF && reader.ReadState == ReadState.Interactive)
                {
                    if (reader.Name == "Album")
                    {
                        XElement element = XNode.ReadFrom(reader) as XElement;
                        musicCollection.AddAlbum(ParseAlbum(element));

                    }
                    else
                    {
                        reader.Read();
                    }
                }
            }
        }

        private static void PrintCollection(MusicCollection musicCollection)
        {
            Console.Out.WriteLine("\n\t--- Music Collection ---");
            Console.Out.WriteLine("\t\t" + musicCollection.Albums.Count + " items");
            Int32 num = 1;

            foreach (MusicCollectionAlbum a in musicCollection.Albums)
            {
                Console.Out.WriteLine("\t" + num + ". " + a.Name + " " + a.Artist + " " + a.Year);
                num++;
            }
            Console.Out.WriteLine(" \t-----------------------\n");
        }

        private static MusicCollectionAlbum ParseAlbum(XElement element)
        {
            XElement albumNameEl = element.Element("Name");
            String albumName = albumNameEl.Value;

            XElement artistEl = element.Element("Artist");
            String artist = artistEl.Value;

            XElement yearEl = element.Element("Year");
            UInt32 year = UInt32.Parse(yearEl.Value);

            return new MusicCollectionAlbum(albumName, artist, year);
        }

        private static void WriteCollection(MusicCollection musicCollection)
        {
            using (XmlWriter writer = XmlWriter.Create((ALBUMS_FILE), new XmlWriterSettings()))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Albums");

                foreach (MusicCollectionAlbum a in musicCollection.Albums)
                {
                    writer.WriteStartElement("Album");

                    writer.WriteElementString("Name", a.Name);
                    writer.WriteElementString("Artist", a.Artist);
                    writer.WriteElementString("Year", a.Year.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

        }
    }
}
