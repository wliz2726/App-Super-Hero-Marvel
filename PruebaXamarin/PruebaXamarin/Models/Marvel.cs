namespace PruebaXamarin.Models
{
    using Newtonsoft.Json;

    public class Marvel
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
