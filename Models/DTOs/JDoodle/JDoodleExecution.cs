using Newtonsoft.Json;

namespace OlanBot.Models.DTOs.JDoodle;

class JDoodleExecution
{
    [JsonProperty("language")] public string Language { get; set; }
    [JsonProperty("script")] public string Script { get; set; }
    [JsonProperty("clientId")] public string ClientId { get; set; }
    [JsonProperty("clientSecret")] public string ClientSecret { get; set; }
    [JsonProperty("stdin")] public string Stdin { get; set; }
    [JsonProperty("versionIndex")] public string VersionIndex { get; set; }
}