using System;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionController
{
    public class Driver 
    {
        public static IMusicCollection CreateXmlMusicCollection()
        {
            return XmlMusicCollection.GetInstance();
        }
    }
}
