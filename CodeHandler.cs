using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using OlanBot.Models;
using OlanBot.Models.DTOs.JDoodle;
using OlanBot.Services;

namespace OlanBot
{
    public class CodeHandler
    {
        private readonly Config _config;
        private readonly JDoodleHandler _jDoodleHandler;

        // Max is 4096 but we need room for additional text
        private const int MaxLength = 4096 - 512;


        private static bool IsValidRequest(string message) => Regex.Match(message, "```").Success;

        private static string GetLanguage(string message) =>
            Regex.Match(message, "`+.*").Value.Replace("`", "");

        private static string TruncateCode(string code) =>
            code.Substring(Math.Max(code.Length - MaxLength, 0), Math.Min(code.Length, MaxLength));

        private static async Task PrintResponse(DiscordChannel discordChannel,
            JDoodleExecutionResponse message)
        {
            
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("```");
            if (message.CodeOutput.Length > MaxLength)
            {
                stringBuilder.Append("...");
            }
            stringBuilder.AppendLine(TruncateCode(message.CodeOutput));
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
        public async Task ScrapeMessage(DiscordChannel discordChannel, MessageCreateEventArgs e)
        {
            var message = e.Message.Content;
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
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                await PrintResponse(discordChannel, response);
            }
            else
            {
                await e.Message.CreateReactionAsync(DiscordEmoji.FromUnicode("⁉️"));
            }
        }
    }
}