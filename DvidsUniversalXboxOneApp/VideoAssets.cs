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
    class VideoAssets
    {
        public async static Task<AssettEpisodeRootObject> getDescription(string id)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://api.dvidshub.net//asset?id=" + id + "&api_key=key-5728b08b42577");
            Debug.WriteLine("123123     " + "https://api.dvidshub.net//podcast/get?id=" + id + "&api_key=key-5728b08b42577");
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(AssettEpisodeRootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (AssettEpisodeRootObject)serializer.ReadObject(ms);
            return data;
        }
    }
    [DataContract]
    public class Credit
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string rank { get; set; }
        [DataMember]
        public string url { get; set; }
    }
    [DataContract]
    public class Location
    {
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string state_abbreviation { get; set; }
        [DataMember]
        public string country_abbreviation { get; set; }
    }
    [DataContract]
    public class FileAsset
    {
        [DataMember]
        public string src { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public int height { get; set; }
        [DataMember]
        public int width { get; set; }
        [DataMember]
        public int size { get; set; }
        [DataMember]
        public int bitrate { get; set; }
    }

    [DataContract]
    public class AssetThumbnail
{
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public int width { get; set; }
        [DataMember]
        public int height { get; set; }
}
    [DataContract]
    public class AssetResults
{
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string keywords { get; set; }
        [DataMember]
        public string date_published { get; set; }
        [DataMember]
        public string date { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public string unit_name { get; set; }
        [DataMember]
        public string branch { get; set; }
        [DataMember]
        public string timestamp { get; set; }
        [DataMember]
        public string image { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public List<Credit> credit { get; set; }
        [DataMember]
        public Location location { get; set; }
        [DataMember]
        public int time_start { get; set; }
        [DataMember]
        public string virin { get; set; }
        [DataMember]
        public int duration { get; set; }
        [DataMember]
        public string aspect_ratio { get; set; }
        [DataMember]
        public List<File> files { get; set; }
        [DataMember]
        public string hls_url { get; set; }
        [DataMember]
        public Thumbnail thumbnail { get; set; }
}

public class AssetRootObject
{
    public AssetResults results { get; set; }
}

public class AssettEpisodeRootObject
    {
        public List<string> messages { get; set; }
        public PageInfo page_info { get; set; }
        public List<EpisodeResults> results { get; set; }
    }
}
