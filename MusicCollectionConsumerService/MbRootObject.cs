using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionConsumerService
{
    public class MbRootObject
    {
        public List<MbReleaseEvent> release_events { get; set; }
        public string date { get; set; }
        public object barcode { get; set; }
        public string quality { get; set; }
        public string disambiguation { get; set; }
        public string status { get; set; }
        public string id { get; set; }
        public object packaging { get; set; }
        public string status_id { get; set; }
        public MbTextRepresentation text_representation { get; set; }
        public string country { get; set; }
        public string title { get; set; }
        public object asin { get; set; }
        public MbCoverArtArchive cover_art_archive { get; set; }
        public object packaging_id { get; set; }
    }
    public class MbArea
    {
        public string id { get; set; }
        public string sort_name { get; set; }
        public string disambiguation { get; set; }
        public string name { get; set; }
        public List<string> iso_3166_1_codes { get; set; }
    }

    public class MbReleaseEvent
    {
        public MbArea area { get; set; }
        public string date { get; set; }
    }

    public class MbTextRepresentation
    {
        public string language { get; set; }
        public string script { get; set; }
    }

    public class MbCoverArtArchive
    {
        public bool front { get; set; }
        public int count { get; set; }
        public bool darkened { get; set; }
        public bool back { get; set; }
        public bool artwork { get; set; }
    }
}
