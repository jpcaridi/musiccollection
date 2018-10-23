using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MusicCollectionModel;
using Newtonsoft.Json;

namespace MusicCollectionConsumerService
{
    public class ConsumerService
    {

        private static readonly string LAST_FM_ROOT_URL = "http://ws.audioscrobbler.com/2.0/";
        private static readonly string MB_ROOT_URL = "http://musicbrainz.org/ws/2/";
        private static readonly string LAST_FM_API_KEY = "479c5b7243a02e8985b3728d483882c0";

        public static IList<Album> Search(string searchString)
        {
            const string method = "?method=album.search";
            string apiKey = "&api_key=" + LAST_FM_API_KEY;
            const string format = "&limit=20&format=json";
            var albumString = "&album=" + searchString;

            List<Album> albumSearhchList = new List<Album>();
            
            // This url should be formatted like:
            // "?method=album.search&album=nevermind&api_key=123456789101112&format=json"
            var requestUri = "" + LAST_FM_ROOT_URL + method + albumString + apiKey + format;
            string response = MakeGetRequest(requestUri);

            LastFMRootObject rootObject = JsonConvert.DeserializeObject<LastFMRootObject>(response);
            LastFMAlbum[] albums = rootObject.results.albummatches.album;

            foreach (LastFMAlbum a in albums)
            {
                if (!a.mbid.Equals(""))
                {
                    UInt32 year = RetrieveAlbumYear(a);
                    albumSearhchList.Add(new Album(a.name, a.artist, year, a.url));
                }
            }

            return albumSearhchList;
        }

        private static UInt32 RetrieveAlbumYear(LastFMAlbum album)
        {
            UInt32 releaseYear = 1900;
            String method = "release/";
            String format = "?fmt=json";

            string requestUri = MB_ROOT_URL + method + album.mbid + format;
            string response = MakeGetRequest(requestUri);

            try
            {
                MbRootObject rootObject = JsonConvert.DeserializeObject<MbRootObject>(response);
                if (rootObject.date != null)
                {
                    releaseYear = uint.Parse(rootObject.date.Substring(0, 4));
                }
            }
            catch (Exception)
            {
                // ignored
            }


            return releaseYear;
        }

        private static string MakeGetRequest(string requestUrlString)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrlString);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";
            httpWebRequest.UserAgent = "MusicCollection/1.0.0 (jpcaridi@gmail.com)";

            string text = "";
            try
            {
                using (HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        text = sr.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                text = ex.Message;
            }

            return text;
        }
    }
}
