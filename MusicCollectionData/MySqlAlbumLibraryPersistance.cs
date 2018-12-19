using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionData
{
    public class MySqlAlbumLibraryPersistance : IAlbumPersistance
    {



        public IAlbumLibrary CreateEmptyLibrary(IUserInfo userInfo, string libraryName)
        {
            throw new NotImplementedException();
        }

        public IAlbumLibrary RetrieveCollection(string libraryName)
        {
            return XmlAlbumLibraryPersistance.ReadCollection(libraryName);
        }

        public IAlbumLibrary RetrieveCollection(IUserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public bool WriteCollection(IAlbumLibrary albumLibrary)
        {
            throw new NotImplementedException();
        }
    }
}
