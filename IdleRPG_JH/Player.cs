using System;
using System.Collections.Generic;
using System.Text;
using IdleRPG_JH.Bots.Items;
using Newtonsoft.Json;
namespace IdleRPG_JH.Bots
{
    public class Player
    {
        [JsonProperty("DiscordID")]
        public ulong DiscordID { get; private set; }

        [JsonProperty("Nickname")]
        public string Nickname { get; private set; }

        [JsonProperty]
        public int Experience { get; private set; }

        public int Level { get; private set; }

        [JsonProperty("Gold")]
        public int Gold { get; private set; }

        [JsonProperty("Inventory")]
        public List<ulong> Inventory { get; private set; }

        [JsonProperty("Equipment")]
        public Equipment Equipment { get; private set; }

        public Player(ulong discordID, string nickname)
        {
            DiscordID = discordID;
            Nickname = nickname;
            ResetProfile();    
            
        }

        public void SetNickname(string newName)
        {
            Nickname = newName;
        }

        private void ResetProfile()
        {
            Experience = 0;
            Level = 0;
            Gold = 0;
            Inventory = new List<ulong>();
        }

        public void InitializeProfile()
        {
            Level = Experience / 10;
        }

        public void AddItemToBag(Item item)
        {
            Inventory.Add(item.UniqueID);
        }

        public void EquipItem(Item item)
        {
            Equipment.Equip(item);
        }


    }
}
