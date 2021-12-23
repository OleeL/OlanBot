using Newtonsoft.Json;

namespace OlanBot.Models
{
    public class Config
    {
        [JsonProperty("Token")]
        public string Token { get; set; }
        
        [JsonProperty("JdConfig")]
        public JDoodleConfig JdConfig { get; set; }
    }
}