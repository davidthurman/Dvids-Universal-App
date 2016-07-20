using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DvidsUniversalXboxOneApp
{
    public class newsStreamEpisodes
    {
        public async static Task<NewsStreamRootObject> getNewsStreams(string hash)
        {

            var http = new HttpClient();
            var response = await http.GetAsync("https://api.dvidshub.net/playlist/get?hash=" + hash + "&api_key=key-5728b08b42577");
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(NewsStreamRootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (NewsStreamRootObject)serializer.ReadObject(ms);
            return data;
        }

        
    }
    [DataContract]
    public class NewsStreamResult
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string date_published { get; set; }
        [DataMember]
        public string date { get; set; }
        [DataMember]
        public string keywords { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string credit { get; set; }
        [DataMember]
        public string unit_name { get; set; }
        [DataMember]
        public string branch { get; set; }
        [DataMember]
        public string aspect_ratio { get; set; }
        [DataMember]
        public string timestamp { get; set; }
        [DataMember]
        public string short_description { get; set; }
        [DataMember]
        public string thumbnail { get; set; }
        [DataMember]
        public int thumb_width { get; set; }
        [DataMember]
        public int thumb_height { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public int duration { get; set; }
        [DataMember]
        public int rating { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string city { get; set; }
    }

    [DataContract]
    public class NewsStreamPageInfo
    {
        [DataMember]
        public int total_results { get; set; }
        [DataMember]
        public int results_per_page { get; set; }
    }
    [DataContract]
    public class NewsStreamRootObject
    {
        [DataMember]
        public List<string> messages { get; set; }
        [DataMember]
        public List<NewsStreamResult> results { get; set; }
        [DataMember]
        public PageInfo page_info { get; set; }
    }
}
