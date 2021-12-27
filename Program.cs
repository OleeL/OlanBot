using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
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
            
            _olanBot = new OlanBot(config);

            discordClient.MessageCreated += _olanBot.OnMessageCreated;
            discordClient.Ready += _olanBot.OnReady;
            discordClient.InteractionCreated += HandleSlashCommands;

            await discordClient.ConnectAsync(GetActivity(), UserStatus.DoNotDisturb);

            await Task.Delay(-1);
        }

        public async Task HandleSlashCommands(DiscordClient client, InteractionCreateEventArgs e)
        {
            var interaction = new DiscordInteractionResponseBuilder().WithContent(
                "OlanBot Write code blocks and I will scrape the code and try to compile it\n" +
                "Commands:\n" +
                " - **/help** - Displays this message\n" +
                "Reaction Meaning:\n" +
                "    ⁉️ - Language not supported").AsEphemeral(true);
            await e.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, interaction);
            // await e.Interaction.CreateResponseAsync(InteractionResponseType.Pong, interaction);

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
                throw new Exception("NO TOKEN IN " + filename);
            }

            return config;
        }

        private static DiscordActivity GetActivity()
        {
#if DEBUG
            Console.WriteLine("DEBUG MODE");
            return new DiscordActivity("with the debugger", ActivityType.Playing);
#endif
            Console.WriteLine("RELEASE MODE");
            return new DiscordActivity("your code", ActivityType.Watching);
        }
    }
}