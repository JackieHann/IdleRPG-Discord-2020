using System;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using IdleRPG_JH.Bots;

using DSharpPlus;
using DSharpPlus.Entities;

namespace IdleRPG_JH
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Initialize bot
            var bot = new Bot();
            //Asynchronously wait for messages
            bot.RunAsync().GetAwaiter().GetResult();
            
        }
    }
}
