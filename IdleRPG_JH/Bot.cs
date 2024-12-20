﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using DSharpPlus;
using DSharp​Plus.CommandsNext;
using IdleRPG_JH.Commands;
using System.Timers;
using DSharpPlus.Entities;

using IdleRPG_JH.Channels;
using Microsoft.Extensions.DependencyInjection;
using IdleRPG_JH.Bots.Commands;

namespace IdleRPG_JH.Bots
{

    public class Bot
    {
        private Timer adventureTimer;

        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public static async Task<T> ReadJSONFromFileIntoTypeAsync<T>(string file_path)
        {
            var json = string.Empty;
            using (var fs = File.OpenRead(file_path))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = await sr.ReadToEndAsync().ConfigureAwait(false);
                }
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }


        

        public async Task RunAsync()
        {
            ConfigJson settings = await ReadJSONFromFileIntoTypeAsync<ConfigJson>("./../../../Config.json");

            Client = new DiscordClient(settings.GetClientConfiguration());
            Client.Ready += OnClientReady;


            CommandsNextConfiguration cfg = settings.GetCommandsConfiguration();
            Commands = Client.UseCommandsNext(cfg);
            Commands.RegisterCommands<PartyCommandsModule>();
            Commands.RegisterCommands<AdminCommands>();
            Commands.RegisterCommands<AdventureCommandsModule>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task OnClientReady(DiscordClient t, DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            Singleton.Instance.Instantiate();
            
            
            //InitAdventureTimer();

            return Task.CompletedTask;
        }

        private void InitAdventureTimer()
        {
            adventureTimer = new Timer();
            adventureTimer.Interval = 2000;
            adventureTimer.Elapsed += UpdateAdventureLog;
            adventureTimer.AutoReset = true;
            adventureTimer.Enabled = true;
        }
        private async void UpdateAdventureLog(object sender, EventArgs e)
        {
            DiscordChannel discordchannel = await Client.GetChannelAsync(ChannelIDs.event_log);
            await discordchannel?.SendMessageAsync("If this works its pog");

        }
    }
}
