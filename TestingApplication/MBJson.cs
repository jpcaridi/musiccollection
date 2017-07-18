using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingApplication
{
   class MBJson
   {
   }

   public class Area
{
    public string id { get; set; }
    public string sort_name { get; set; }
    public string disambiguation { get; set; }
    public string name { get; set; }
    public List<string> iso_3166_1_codes { get; set; }
}

public class ReleaseEvent
{
    public Area area { get; set; }
    public string date { get; set; }
}

public class TextRepresentation
{
    public string language { get; set; }
    public string script { get; set; }
}

public class CoverArtArchive
{
    public bool front { get; set; }
    public int count { get; set; }
    public bool darkened { get; set; }
    public bool back { get; set; }
    public bool artwork { get; set; }
}

public class RootObject
{
    public List<ReleaseEvent> release_events { get; set; }
    public string date { get; set; }
    public object barcode { get; set; }
    public string quality { get; set; }
    public string disambiguation { get; set; }
    public string status { get; set; }
    public string id { get; set; }
    public object packaging { get; set; }
    public string status_id { get; set; }
    public TextRepresentation text_representation { get; set; }
    public string country { get; set; }
    public string title { get; set; }
    public object asin { get; set; }
    public CoverArtArchive cover_art_archive { get; set; }
    public object packaging_id { get; set; }
}

}
