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
    public class Podcast
    {
        public async static Task<RootObjectPodcast> getPodcasts()
        {

            var http = new HttpClient();
            var response = await http.GetAsync("https://api.dvidshub.net//podcast/list?thumb_width=300&id%5B%5D=64&id%5B%5D=102&id%5B%5D=108&id%5B%5D=1&id%5B%5D=34&id%5B%5D=79&id%5B%5D=47&id%5B%5D=33&id%5B%5D=183&id%5B%5D=58&id%5B%5D=32&id%5B%5D=212&id%5B%5D=214&id%5B%5D=215&id%5B%5D=222&id%5B%5D=224&id%5B%5D=217&id%5B%5D=220&id%5B%5D=12&id%5B%5D=227&api_key=key-5728b08b42577");
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(RootObjectPodcast));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObjectPodcast)serializer.ReadObject(ms);
            return data;
        }
        
        
    }
    [DataContract]
    public class ResultPodcasts
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string thumbnail { get; set; }
    }

    [DataContract]
    public class RootObjectPodcast
    {
        [DataMember]
        public List<Result> results { get; set; }
    }
}
