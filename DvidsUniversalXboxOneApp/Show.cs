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
    public class Show
    {
        public async static Task<RootObject> getShows()
        {

            var http = new HttpClient();
            var response = await http.GetAsync("https://api.dvidshub.net//series/list?&api_key=key-5728b08b42577");
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);
            return data;
        }
    }
    [DataContract]
    public class Result
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
    public class RootObject
    {
        [DataMember]
        public List<Result> results { get; set; }
    }
}
