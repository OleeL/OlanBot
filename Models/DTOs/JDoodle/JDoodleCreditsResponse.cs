using Newtonsoft.Json;

namespace OlanBot.Models.DTOs.JDoodle;

// The 
public class JDoodleCreditsResponse
{
    [JsonProperty("Used")]
    public uint CreditsUsed { get; set; }
}
