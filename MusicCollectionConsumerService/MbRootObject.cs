using System.Collections.Generic;

namespace MusicCollectionConsumerService
{
    public class MbRootObject
    {
        public List<MbReleaseEvent> ReleaseEvents { get; set; }
        public string Date { get; set; }
        public object Barcode { get; set; }
        public string Quality { get; set; }
        public string Disambiguation { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public object Packaging { get; set; }
        public string StatusId { get; set; }
        public MbTextRepresentation TextRepresentation { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public object Asin { get; set; }
        public MbCoverArtArchive CoverArtArchive { get; set; }
        public object PackagingId { get; set; }
    }
    public class MbArea
    {
        public string Id { get; set; }
        public string SortName { get; set; }
        public string Disambiguation { get; set; }
        public string Name { get; set; }
        public List<string> Iso31661Codes { get; set; }
    }

    public class MbReleaseEvent
    {
        public MbArea Area { get; set; }
        public string Date { get; set; }
    }

    public class MbTextRepresentation
    {
        public string Language { get; set; }
        public string Script { get; set; }
    }

    public class MbCoverArtArchive
    {
        public bool Front { get; set; }
        public int Count { get; set; }
        public bool Darkened { get; set; }
        public bool Back { get; set; }
        public bool Artwork { get; set; }
    }
}
