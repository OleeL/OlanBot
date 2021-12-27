using System.Net;
using Newtonsoft.Json;

namespace OlanBot.Models.DTOs.JDoodle;

public class JDoodleExecutionResponse
{
    [JsonProperty("output")]
    public string CodeOutput { get; set; }
    
    [JsonProperty("statusCode")]
    public HttpStatusCode HttpStatusCode { get; set; }
    
    [JsonProperty("memory")]
    public string MemoryUsed { get; set; }
    
    [JsonProperty("cpuTime")]
    public string CpuTime { get; set; }
}
