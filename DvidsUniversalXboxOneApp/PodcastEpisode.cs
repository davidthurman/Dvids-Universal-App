using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DvidsUniversalXboxOneApp
{
    class PodcastEpisode
    {
        public async static Task<PodcastEpisodeRootObject> getEpisodes(string id)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://api.dvidshub.net//podcast/get?id=" + id + "&api_key=key-5728b08b42577");
            Debug.WriteLine("123123     " + "https://api.dvidshub.net//podcast/get?id=" + id + "&api_key=key-5728b08b42577");
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(PodcastEpisodeRootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (PodcastEpisodeRootObject)serializer.ReadObject(ms);
            return data;
        }
    }

    public class EpisodePageInfo
    {
        public int total_results { get; set; }
        public int results_per_page { get; set; }
    }

    public class EpisodeResults
    {
        public int id { get; set; }
        public string asset_id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string short_description { get; set; }
        public string date_published { get; set; }
        public string keywords { get; set; }
        public string date { get; set; }
        public string category { get; set; }
        public string aspect_ratio { get; set; }
        public int duration { get; set; }
        public bool hd { get; set; }
        public string credit { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string unit_name { get; set; }
        public string branch { get; set; }
        public string timestamp { get; set; }
        public string thumbnail { get; set; }
        public string url { get; set; }
    }

    public class PodcastEpisodeRootObject
    {
        public List<string> messages { get; set; }
        public PageInfo page_info { get; set; }
        public List<EpisodeResults> results { get; set; }
    }
}
