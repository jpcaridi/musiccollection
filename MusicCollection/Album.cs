using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionData
{
    public class MusicCollectionAlbum
    {
        public MusicCollectionAlbum(String name, String artist, UInt32 year)
        {
            Name = name;
            Artist = artist;
            Year = year;
            PlayCount = 0;
        }
        public String Name
        {
            get;
            set;
        }

        public String Artist
        {
            get;
            set;
        }

        public UInt32 Year
        {
            get;
            set;
        }

        public int PlayCount
        { get; set; }
    }
}
