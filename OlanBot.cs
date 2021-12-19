using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace OlanBot
{
    public class OlanBot
    {
        CodeHandler _codeHandler;
        public OlanBot()
        {
            _codeHandler = new CodeHandler();
        }
        
        public Task OnMessageCreated(DiscordClient _, MessageCreateEventArgs e)
        {
            Console.WriteLine("Hello world!");
            return Task.CompletedTask;
        }
        
        
    }
}