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
    class SearchEpisode
    {
        public async static Task<SearchRootObject> getSearchResults(string query)
        {

            var http = new HttpClient();
            var response = await http.GetAsync("https://api.dvidshub.net/search?q=" + query + "&max_results=2&api_key=key-5728b08b42577");
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(SearchRootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (SearchRootObject)serializer.ReadObject(ms);
            return data;
        }
    }
    [DataContract]
    public class SearchPageInfo
    {
        [DataMember]
        public int total_results { get; set; }
        [DataMember]
        public int results_per_page { get; set; }
    }
    [DataContract]
    public class SearchResult
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string publishdate { get; set; }
        [DataMember]
        public string date { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public string aspect_ratio { get; set; }
        [DataMember]
        public int duration { get; set; }
        [DataMember]
        public bool hd { get; set; }
        [DataMember]
        public string keywords { get; set; }
        [DataMember]
        public string credit { get; set; }
        [DataMember]
        public int rating { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string city { get; set; }
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
        public int thumb_width { get; set; }
        [DataMember]
        public int thumb_height { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string date_published { get; set; }
    }

    [DataContract]
    public class SearchRootObject
    {
        [DataMember]
        public PageInfo page_info { get; set; }
        [DataMember]
        public List<SearchResult> results { get; set; }
    }
}
