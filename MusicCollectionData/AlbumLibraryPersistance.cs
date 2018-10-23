using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using MusicCollectionModel;

namespace MusicCollectionData
{
    public class AlbumLibraryPersistance
    {
        private static readonly String ALBUMS_FILE_EXTENSION = ".musiclibraryxml";
        private static readonly String ALBUMS_FILE_LOCATION = "\\MusicCollection\\DataStore";

        private static string LibraryFileName(AlbumLibrary albumLibrary)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path += ALBUMS_FILE_LOCATION;

            //Ensure the directory exists.
            Directory.CreateDirectory(path);

            return Path.Combine(path, albumLibrary.LibraryName + ALBUMS_FILE_EXTENSION);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumLibrary"></param>
        public static void ReadCollection(AlbumLibrary albumLibrary)
        {
            string fileName = LibraryFileName(albumLibrary);

            using (XmlReader reader = XmlReader.Create(fileName, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                reader.MoveToContent();
                reader.ReadStartElement("Albums");

                while (!reader.EOF && reader.ReadState == ReadState.Interactive)
                {
                    if (reader.Name == "Album")
                    {
                        XElement element = XNode.ReadFrom(reader) as XElement;
                        albumLibrary.AddAlbum(ParseAlbum(element));

                    }
                    else
                    {
                        reader.Read();
                    }
                }
            }
        }

        private static Album ParseAlbum(XElement element)
        {
            string albumName = "";
            string artist = "";
            string yearStr = "";
            string url = "";

             XElement albumNameEl = element.Element("Name");
            albumName = albumNameEl?.Value;

            XElement artistEl = element.Element("Artist");
            artist = artistEl?.Value;

            XElement yearEl = element.Element("Year");
            yearStr = yearEl?.Value;
            uint year = uint.Parse(yearStr);

            XElement urlEl = element.Element("URL");
            url = urlEl?.Value;

            return new Album(albumName, artist, year, url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumLibrary"></param>
        public static void WriteCollection(AlbumLibrary albumLibrary)
        {
            using (XmlWriter writer = XmlWriter.Create(LibraryFileName(albumLibrary), new XmlWriterSettings()))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Albums");

                foreach (Album a in albumLibrary.Albums)
                {
                    writer.WriteStartElement("Album");

                    writer.WriteElementString("Name", a.Name);
                    writer.WriteElementString("Artist", a.Artist);
                    writer.WriteElementString("Year", a.Year.ToString());
                    writer.WriteElementString("URL", a.Url);

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

        }
    }
}
