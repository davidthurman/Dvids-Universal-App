using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DvidsUniversalXboxOneApp
{
    class LiveEpisodes
    {
        public async static Task<LiveRootObject> getPodcasts()
        {
            var http = new HttpClient();
            Debug.WriteLine("1");
            var response = await http.GetAsync("https://api.dvidshub.net//live/list?max_results=50&api_key=key-5728b08b42577");
            Debug.WriteLine("2");
            var result = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("3");
            var serializer = new DataContractJsonSerializer(typeof(LiveRootObject));
            Debug.WriteLine("4");
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            Debug.WriteLine("5");
            var data = (LiveRootObject)serializer.ReadObject(ms);
            Debug.WriteLine("6");
            return data;
        }
        
    }
    [DataContract]
    public class LiveThumbnail
    {
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public int width { get; set; }
        [DataMember]
        public int height { get; set; }
    }
    [DataContract]
    public class LiveResult
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string begin { get; set; }
        [DataMember]
        public string end { get; set; }
        [DataMember]
        public LiveThumbnail thumbnail { get; set; }
        [DataMember]
        public string url { get; set; }
    }

    [DataContract]
    public class LiveRootObject
    {
        [DataMember]
        public List<LiveResult> results { get; set; }
        [DataMember]
        public string current_time { get; set; }
    }
}
