namespace PruebaXamarin.Models
{
    using Newtonsoft.Json;

    public class Thumbnail
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
    }
}
