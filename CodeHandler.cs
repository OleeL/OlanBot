using System.Buffers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using OlanBot.Models;
using OlanBot.Models.DTOs.JDoodle;
using OlanBot.Services;

namespace OlanBot
{
    public class CodeHandler
    {
        private readonly Config _config;
        private readonly JDoodleHandler _jDoodleHandler;

        private static bool IsValidRequest(string message) => Regex.Match(message, "```").Success;

        private static string GetLanguage(string message) =>
            Regex.Match(message, "`+.*").Value.Replace("`", "");

        private static async Task PrintResponse(DiscordClient discordClient, DiscordChannel discordChannel,
            JDoodleExecutionResponse message)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("```");
            stringBuilder.AppendLine(message.CodeOutput);
            stringBuilder.AppendLine("```");
            if (message.CpuTime != null)
            {
                stringBuilder.Append("CPU Time: ");
                stringBuilder.Append(message.CpuTime);
                stringBuilder.AppendLine(" sec(s)");
            }

            if (message.MemoryUsed != null)
            {
                stringBuilder.Append("Memory Used: ");
                stringBuilder.Append(message.MemoryUsed);
                stringBuilder.AppendLine("kb(s)");
            }

            var embed = new DiscordEmbedBuilder
            {
                Title = "Code Response",
                Description = stringBuilder.ToString(),
                Color = new DiscordColor(0x00FF00)
            };
            await discordChannel.SendMessageAsync(embed: embed);
        }

        public CodeHandler(Config config)
        {
            _config = config;
            _jDoodleHandler = new JDoodleHandler(config.JdConfig);
        }

        // Scrapes the message for code
        public async Task ScrapeMessage(DiscordClient discordClient, DiscordChannel discordChannel, string message)
        {
            if (!IsValidRequest(message))
            {
                return;
            }

            var language = GetLanguage(message);
            if (language == "")
            {
                return;
            }

            var match = Regex.Match(message, "```");
            var start = match.Index + match.Length + language.Length;
            var end = match.NextMatch().Index;
            var code = message.Substring(start, end - start);

            var response = await _jDoodleHandler.SendCode(language, code, "", "");
            await PrintResponse(discordClient, discordChannel, response);
        }
    }
}