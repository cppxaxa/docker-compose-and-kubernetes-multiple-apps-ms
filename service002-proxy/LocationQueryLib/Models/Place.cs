using Newtonsoft.Json;

namespace LocationQueryLib
{
    public class Place
    {
        [JsonProperty("articleUrl")]
        public string ArticleUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("distance")]
        public double Distance { get; set; }
        
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}