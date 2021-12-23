using Newtonsoft.Json;

namespace OlanBot.Models
{
    public class JDoodleConfig
    {
        [JsonProperty("Url")]
        public string Url { get; set; }
        
        [JsonProperty("ClientSecret")]
        public string ClientSecret { get; set; }
        
        [JsonProperty("ClientId")]
        public string ClientId { get; set; }
    }
}