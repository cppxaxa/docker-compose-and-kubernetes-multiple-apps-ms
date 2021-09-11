using Newtonsoft.Json;
using System.Collections.Generic;

namespace LocationQueryLib
{
    internal class LocationQueryExamples : ILocationQueryExamples
    {
        [JsonProperty("examples")]
        public List<string> Examples { get; set; }
    }
}