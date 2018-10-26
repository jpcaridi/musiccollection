using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionData
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of albums
    /// </summary>
    internal class XmlAlbumLibrary : IAlbumLibrary
    {
        private XmlAlbumLibrary(string libraryName)
        {
            LibraryName = libraryName;
            _mAlbums = new List<IAlbum>();
        }

        /// <summary>
        /// Create an empty instance of the library
        /// </summary>
        /// <param name="libraryName">The name to be given to the library</param>
        /// <returns></returns>
        public static XmlAlbumLibrary CreateInstance(string libraryName)
        {
            return new XmlAlbumLibrary(libraryName);
        }

        /// <summary>
        /// Create an instance of an XmlAlbumLibrary
        /// </summary>
        /// <param name="libraryName">The name to be given to the library</param>
        /// <param name="fileName">The path to the xml file to create the library from</param>
        /// <returns></returns>
        public static XmlAlbumLibrary CreateInstance(string libraryName, string fileName)
        {
            XmlAlbumLibrary xmlAlbumLibrary = new XmlAlbumLibrary(libraryName);

            try
            {
                using (XmlReader reader = XmlReader.Create(fileName, new XmlReaderSettings { IgnoreWhitespace = true }))
                {
                    reader.MoveToContent();
                    reader.ReadStartElement("Albums");

                    while (!reader.EOF && reader.ReadState == ReadState.Interactive)
                    {
                        if (reader.Name == "Album")
                        {
                            XElement element = XNode.ReadFrom(reader) as XElement;
                            xmlAlbumLibrary.AddAlbum(XmlAlbum.CreateInstance(element));
                        }
                        else
                        {
                            reader.Read();
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                //TODO This should really throw a new persistance exception
                xmlAlbumLibrary = null;
            }

            return xmlAlbumLibrary;
        }

        /// <summary>
        /// Library Name
        /// </summary>
        public string LibraryName { get; set; }

        private readonly List<IAlbum> _mAlbums;
        /// <summary>
        /// Get the album library as a list
        /// </summary>
        public IReadOnlyList<IAlbum> Albums => _mAlbums.AsReadOnly();

        /// <summary>
        /// Add a new album to the library
        /// </summary>
        /// <param name="album">The album to add</param>
        public void AddAlbum(IAlbum album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            if (!_mAlbums.Contains(album))
            {
                _mAlbums.Add(album);
            }
        }

        /// <summary>
        /// Remove an album from the library
        /// </summary>
        /// <param name="album">The album to remove</param>
        /// <returns></returns>
        public bool RemoveAlbum(IAlbum album)
        {
            if (album == null) throw new ArgumentNullException(nameof(album));
            return _mAlbums.Contains(album) && _mAlbums.Remove(album);
        }
    }
}
