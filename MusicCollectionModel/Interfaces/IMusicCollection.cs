
namespace MusicCollectionModel.Interfaces
{
    /// <summary>
    /// Represents the root music collection objects
    /// </summary>
    public interface IMusicCollection
    {
        IAlbumPersistance Persistance { get; }
        IConsumerService ConsumerService { get; }
    }
}
