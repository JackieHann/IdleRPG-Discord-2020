using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdleRPG_JH.Bots;
using IdleRPG_JH.Bots.Managers;

namespace IdleRPG_JH.Bots.Commands
{
    public class PartyCommandsModule : BaseCommandModule
    {

        [Command("CreateParty")]
        public async Task CreateParty(CommandContext ctx, DiscordMember member = null)
        {
            var returnStr = PartyManager.Instance.CreateParty(ctx.Member.Id);
            await ctx.Channel.SendMessageAsync(returnStr);
        }

        [Command("LeaveParty")]
        public async Task LeaveParty(CommandContext ctx, DiscordMember member = null)
        {
            var returnStr = PartyManager.Instance.LeaveParty(ctx.Member.Id);
            await ctx.Channel.SendMessageAsync(returnStr);
        }
    }

    public class AdventureCommandsModule : BaseCommandModule
    {
       // public PartyManager manager { private get; set; }

        [Command("Adventure")]
        public async Task Adventure(CommandContext ctx, DiscordMember member = null)
        {
           // manager.DoSomethingHere();
            await ctx.Channel.SendMessageAsync("A Singleton Test ");
        }
    }
}
