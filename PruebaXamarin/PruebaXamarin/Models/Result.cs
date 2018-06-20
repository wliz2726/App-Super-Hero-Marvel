namespace PruebaXamarin.Models
{
    using Newtonsoft.Json;

    public class Result
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        //[JsonProperty("resourceURI")]
        //public string ResourceUri { get; set; }
    }
}
