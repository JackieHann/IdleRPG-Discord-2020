using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IdleRPG_JH.Bots
{
    struct PlayerManager
    {

        [JsonProperty("Players")]
        private List<Player> players { get; set; }

        private static string directory = "./../../../Players.json";

        public Player GetPlayerByID(ulong ID)
        {
            return players.Find(x => x.DiscordID == ID);
        }

        public void AddPlayer(Player newPlayer)
        {
            players.Add(newPlayer);
        }

        public static async Task<PlayerManager> FetchPlayerData()
        { 
            PlayerManager playerManager = await Bot.ReadJSONFromFileIntoTypeAsync<PlayerManager>(directory);
            return playerManager;
        }

        internal void SavePlayerData()
        {
            string toWrite = JsonConvert.SerializeObject(this);
            File.WriteAllText(directory, toWrite);
        }
    }
}
