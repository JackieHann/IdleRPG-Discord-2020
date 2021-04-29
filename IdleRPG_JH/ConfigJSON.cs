using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using DSharpPlus;
using DSharp​Plus.CommandsNext;

namespace IdleRPG_JH
{
    public class ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string Prefix { get; private set; }


        [JsonProperty("Testing")]
        public List<string> Testing { get; private set; }

        public DiscordConfiguration GetClientConfiguration()
        {
            return new DiscordConfiguration
            {
                Token = this.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug
            };
        }

        public CommandsNextConfiguration GetCommandsConfiguration()
        {
            return new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { this.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                CaseSensitive = false,
                DmHelp = false,
                IgnoreExtraArguments = false,
                UseDefaultCommandHandler = true
            };
        }
    }
}
