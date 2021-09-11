using Newtonsoft.Json;
using System.Collections.Generic;

namespace LocationQueryLib
{
    public class LocationQueryResponse : ILocationQueryResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("places")]
        public List<Place> Places { get; set; }
    }
}