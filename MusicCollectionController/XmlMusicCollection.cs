using MusicCollectionConsumerService;
using MusicCollectionData;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionController
{
    public class XmlMusicCollection : IMusicCollection
    {
        private XmlMusicCollection()
        {
            _mXmlPersistance = new XmlAlbumLibraryPersistance();
            _mLastFmService = new LastFmService();
        }
        private readonly XmlAlbumLibraryPersistance _mXmlPersistance;
        private readonly LastFmService _mLastFmService;

        public static XmlMusicCollection GetInstance()
        {
            return new XmlMusicCollection();
        }

        public IAlbumPersistance Persistance => _mXmlPersistance;
        public IConsumerService ConsumerService => _mLastFmService;
    }
}
