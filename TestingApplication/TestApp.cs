using MusicCollectionData;
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
        private static readonly String ROOT_URL = "http://ws.audioscrobbler.com/2.0/";
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
                Console.Out.WriteLine("3 - Save Collection ");
                Console.Out.WriteLine("4 - Search");
                Console.Out.WriteLine("0 - Exit ");
                Console.Out.Write("Please Enter a Selection: ");
                choice = Console.In.ReadLine().Trim();


            } while (!ProcessChoice(choice, musicCollection));
        }

        private static bool ProcessChoice (String choice, MusicCollection musicCollection)
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
                    WriteCollection(musicCollection);
                    break;
                case "4":
                    Search();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    break;
            }

            return exit;
        }

        private static void Search()
        {
            String url = ROOT_URL + "?method=album.search&album=Believe&api_key=479c5b7243a02e8985b3728d483882c0&format=json";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    String text = sr.ReadToEnd();

                    Console.Out.WriteLine(text);
                }
            }
        }

        private static void AddAlbum (MusicCollection musicCollection)
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
            foreach (MusicCollectionAlbum a in musicCollection.Albums)
            {
                Console.Out.WriteLine("\t" + a.Name + " " + a.Artist + " " + a.Year);
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

        private static void WriteCollection (MusicCollection musicCollection)
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
