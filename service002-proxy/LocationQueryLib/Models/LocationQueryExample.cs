using Newtonsoft.Json;

namespace LocationQueryLib
{
    public class LocationQueryExample
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("miles")]
        public int Miles { get; set; }
    }
}