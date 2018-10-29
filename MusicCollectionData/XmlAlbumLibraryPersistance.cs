using System;
using System.IO;
using System.Xml;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionData
{
    public class XmlAlbumLibraryPersistance : IAlbumPersistance
    {
        private static readonly String ALBUMS_FILE_EXTENSION = ".musiclibraryxml";
        private static readonly String ALBUMS_FILE_LOCATION = "\\MusicCollection\\DataStore";

        private static string LibraryFileName(string libraryName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path += ALBUMS_FILE_LOCATION;

            //Ensure the directory exists.
            Directory.CreateDirectory(path);

            return Path.Combine(path, libraryName + ALBUMS_FILE_EXTENSION);
        }

        /// <summary>
        /// ReadCollection
        /// </summary>
        /// <param name="libraryName"></param>
        /// <returns></returns>
        public static IAlbumLibrary ReadCollection(string libraryName)
        {
            string fileName = LibraryFileName(libraryName);
            XmlAlbumLibrary albumLibrary = XmlAlbumLibrary.CreateInstance(libraryName, fileName);

            return albumLibrary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumLibrary"></param>
        public static void WriteCollection(IAlbumLibrary albumLibrary)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                NewLineOnAttributes = true
            };

            using (XmlWriter writer = XmlWriter.Create(LibraryFileName(albumLibrary.LibraryName), settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Albums");

                foreach (IAlbum a in albumLibrary.Albums)
                {
                    writer.WriteStartElement("Album");

                    writer.WriteElementString("Name", a.Name);
                    writer.WriteElementString("Artist", a.Artist);
                    writer.WriteElementString("Year", a.Year.ToString());
                    writer.WriteElementString("PlayCount", a.PlayCount.ToString());
                    writer.WriteElementString("URL", a.Url);

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

        }

        public IAlbumLibrary CreateEmptyLibrary(string libraryName)
        {
            return XmlAlbumLibrary.CreateInstance(libraryName);
        }

        public IAlbumLibrary RetrieveCollection(string libraryName)
        {
            return ReadCollection(libraryName);
        }

        bool IAlbumPersistance.WriteCollection(IAlbumLibrary albumLibrary)
        {
            bool collectionSaved = true;
            try
            {
                WriteCollection(albumLibrary);
            }
            catch (Exception)
            {
                collectionSaved = false;
            }

            return collectionSaved;
        }
    }
}
