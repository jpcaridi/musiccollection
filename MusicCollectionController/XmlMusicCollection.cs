using MusicCollectionConsumerService;
using MusicCollectionData;
using MusicCollectionModel.Interfaces;
using MusicCollectionServices;

namespace MusicCollectionController
{
    public class XmlMusicCollection : IMusicCollection
    {
        private XmlMusicCollection()
        {
            _mXmlPersistance = new XmlAlbumLibraryPersistance();
            _mLastFmService = new LastFmService();
            _mLogInService = new LogInService();
        }
        private readonly XmlAlbumLibraryPersistance _mXmlPersistance;
        private readonly LastFmService _mLastFmService;
        private readonly LogInService _mLogInService;

        public static XmlMusicCollection GetInstance()
        {
            return new XmlMusicCollection();
        }

        public IAlbumPersistance Persistance => _mXmlPersistance;
        public IConsumerService ConsumerService => _mLastFmService;
        public ILogInService LogInService => _mLogInService;
    }
}
