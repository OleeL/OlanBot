using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using OlanBot.Models;
using OlanBot.Services;

namespace OlanBot
{
    public class OlanBot
    {
        private readonly CodeHandler _codeHandler;
        
        public OlanBot(Config config)
        {   
            _codeHandler = new CodeHandler(config);
        }
        
        public async Task OnMessageCreated(DiscordClient _, MessageCreateEventArgs e)
        {
            var message = e.Message.Content;
            await Task.Run(() => _codeHandler.ScrapeMessage(_, e.Channel, message));
        }
        
        
    }
}