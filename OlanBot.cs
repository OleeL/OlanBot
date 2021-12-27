using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using OlanBot.Models;

namespace OlanBot
{
    public class OlanBot : BaseCommandModule
    {
        private readonly CodeHandler _codeHandler;
        
        public OlanBot(Config config)
        {   
            _codeHandler = new CodeHandler(config);
        }
        
        public async Task OnMessageCreated(DiscordClient _, MessageCreateEventArgs e)
        {
            await Task.Run(() => _codeHandler.ScrapeMessage(e.Channel, e));
        }



        public Task OnReady(DiscordClient discordClient, ReadyEventArgs e)
        {
            Console.WriteLine("OlanBot Ready");
            return Task.CompletedTask;
            // await discordClient.CreateGlobalApplicationCommandAsync(new DiscordApplicationCommand(
            //     "help",
            //     "Learn how to use OlanBot"));
        }

        //
        // [Command("help"), Description("Learn how to use OlanBotL")]
        // public async Task CommandHelp(CommandContext ctx, DiscordChannel chn = null)
        // {
        //     await ctx.Message.RespondAsync("```" +
        //                                  "OlanBot Commands:\n" +
        //                                  "    Write code blocks and I will scrapes the code and try to compile it\n" +
        //                                  "    help - Displays this message\n" +
        //                                  "Reactions:" +
        //                                  "    ⁉️ - Language not supported```");
        // }
        //
        
    }
}