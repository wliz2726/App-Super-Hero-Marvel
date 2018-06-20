namespace PruebaXamarin.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Data
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }
}
