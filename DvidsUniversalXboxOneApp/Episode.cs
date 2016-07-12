using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DvidsUniversalXboxOneApp
{
    class Episode
    {
        public async static Task<RootObjectEpisodes> getEpisodes(string id)
        {

            var http = new HttpClient();
            var response = await http.GetAsync("https://api.dvidshub.net//series/episodes/list?id=" + id + "&api_key=key-5728b08b42577");
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(RootObjectEpisodes));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObjectEpisodes)serializer.ReadObject(ms);
            return data;
        }
    }

    [DataContract]
    public class PageInfo
    {
        [DataMember]
        public int total_results { get; set; }
        [DataMember]
        public int results_per_page { get; set; }
    }

    [DataContract]
    public class ResultEpisodes
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string date_published { get; set; }
        [DataMember]
        public string date { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public string aspect_ratio { get; set; }
        [DataMember]
        public int duration { get; set; }
        [DataMember]
        public double rating { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string unit_name { get; set; }
        [DataMember]
        public string branch { get; set; }
        [DataMember]
        public string timestamp { get; set; }
        [DataMember]
        public string short_description { get; set; }
        [DataMember]
        public string thumbnail { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string series_title { get; set; }
        [DataMember]
        public string subseries_title { get; set; }
        [DataMember]
        public int subseries_id { get; set; }
        [DataMember]
        public int episode { get; set; }
        [DataMember]
        public string keywords { get; set; }
    }


    [DataContract]
    public class RootObjectEpisodes
    {
        [DataMember]
        public List<string> messages { get; set; }
        [DataMember]
        public PageInfo page_info { get; set; }
        [DataMember]
        public List<Result> results { get; set; }
    }
}
