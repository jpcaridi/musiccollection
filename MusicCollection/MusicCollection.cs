using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionData
{
    public class MusicCollection
    {
        public MusicCollection()
        {
            m_albums = new List<MusicCollectionAlbum>();
        }

        private List<MusicCollectionAlbum> m_albums;
        public IList<MusicCollectionAlbum> Albums
        {
            get
            {
                return m_albums.AsReadOnly();
            }
        }

        public void AddAlbum(MusicCollectionAlbum album)
        {
            m_albums.Add(album);
        }

        public bool RemoveAlbum(MusicCollectionAlbum album)
        {
           if (m_albums.Contains(album))
           {
              return m_albums.Remove(album);
           }

           return false;
        }
    }
}
