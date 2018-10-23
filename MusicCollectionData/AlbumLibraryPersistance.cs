using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using MusicCollectionModel;

namespace MusicCollectionData
{
    public class AlbumLibraryPersistance
    {
        private static readonly String ALBUMS_FILE = "Albums.xml";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumLibrary"></param>
        public static void ReadCollection(AlbumLibrary albumLibrary)
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
            XElement albumNameEl = element.Element("Name");
            String albumName = albumNameEl.Value;

            XElement artistEl = element.Element("Artist");
            String artist = artistEl.Value;

            XElement yearEl = element.Element("Year");
            UInt32 year = UInt32.Parse(yearEl.Value);

            return new Album(albumName, artist, year);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumLibrary"></param>
        public static void WriteCollection(AlbumLibrary albumLibrary)
        {
            using (XmlWriter writer = XmlWriter.Create((ALBUMS_FILE), new XmlWriterSettings()))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Albums");

                foreach (Album a in albumLibrary.Albums)
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
