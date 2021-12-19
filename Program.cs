using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using OlanBot.Models;
using Newtonsoft.Json;


// Permission int: 3072
namespace OlanBot
{
    public class Program
    {
        private OlanBot _olanBot;

        public static void Main(string[] args) =>
            new Program().RunBotAsync().GetAwaiter().GetResult();

        private async Task RunBotAsync()
        {
            var config = await InitConfig("config.json");

            var discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = config.Token,
                TokenType = TokenType.Bot,
            });
            
            Console.WriteLine("OlanBot Started");
            _olanBot = new OlanBot();

            discordClient.MessageCreated += _olanBot.OnMessageCreated;

            await discordClient.ConnectAsync();
            await Task.Delay(-1);
        }

        private async Task<Config> InitConfig(string filename)
        {
            var json = "";

            await using (var fs = File.OpenRead(filename))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = await sr.ReadToEndAsync();
                }
            }

            var config = JsonConvert.DeserializeObject<Config>(json);

            if (config?.Token == null)
            {
                throw new Exception("NO TOKEN IN "+filename);
            }

            return config;
        }
    }
}