using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OlanBot.Models;
using OlanBot.Models.DTOs.JDoodle;

namespace OlanBot.Services;

public class JDoodleHandler
{
    private readonly JDoodleConfig _Config;
    
    public JDoodleHandler(JDoodleConfig config)
    {
        _Config = config;
    }

    public async Task<JDoodleExecutionResponse> SendCode(string language, string code, string stdin, string version)
    {
           var dto = new JDoodleExecution()
           {
               ClientSecret = _Config.ClientSecret,
               ClientId = _Config.ClientId,
               Language = language,
               Script = code,
               Stdin = stdin,
               VersionIndex = version
           };
           
           var json = JsonConvert.SerializeObject(dto);
           var serializedResponse = await PostRequest(_Config.Url, "/v1/execute", json);
           return JsonConvert.DeserializeObject<JDoodleExecutionResponse>(serializedResponse);
    }

    // HTTP GET request to the API
    private static async void GetRequest(string url, string path)
    {
        var client = new HttpClient();
        var response = await client.GetAsync($"https://{url}{path}");
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }
    
    // HTTP POST request to the API
    private static async Task<string> PostRequest(string url, string path, string jsonStringBody)
    {
        var client = new HttpClient();
        var strContent = new StringContent(jsonStringBody, Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"https://{url}{path}", strContent);
        return await response.Content.ReadAsStringAsync();
    }
}

