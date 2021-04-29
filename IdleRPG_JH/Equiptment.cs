using IdleRPG_JH.Bots.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleRPG_JH.Bots
{
    //Group of equipped items
    public class Equipment
    {
        Equipment()
        {
            MainHand = 0;
            OffHand = 0;
        }

        [JsonProperty("MainHand")]
        public ulong MainHand;

        [JsonProperty("OffHand")]
        public ulong OffHand;

        [JsonProperty("Head")]
        public ulong Head;

        [JsonProperty("Body")]
        public ulong Body;

        [JsonProperty("Waist")]
        public ulong Waist;

        [JsonProperty("Legs")]
        public ulong Legs;

        [JsonProperty("Feet")]
        public ulong Feet;

        [JsonProperty("Gloves")]
        public ulong Gloves;

        public void Equip(Item item)
        {
            
        }
    }
}
