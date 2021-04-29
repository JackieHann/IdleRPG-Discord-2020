using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace IdleRPG_JH.Bots.Items
{
    public partial class Item
    {

        [JsonProperty]
        public ulong UniqueID { get; private set; }

        [JsonProperty]
        public string Name { get; protected set; }

        [JsonProperty]
        public int Price { get; protected set; }

        [JsonProperty]
        public int Level { get; protected set; }

        [JsonProperty]
        public int iLevel { get; protected set; }

        [JsonProperty]
        public float Perfection { get; protected set; }

        [JsonProperty]
        public Rarities Rarity { get; protected set; }

        public virtual string GetFormattedNameString()
        {
            return Name;
        }


        public Item(ulong id)
        {
            UniqueID = id;
        }

        public string GetRarityString()
        {
            switch (Rarity)
            {
                case Rarities.Common:
                    return "Common";
                case Rarities.Uncommon:
                    return "Uncommon";
                case Rarities.Rare:
                    return "Rare";
                case Rarities.Epic:
                    return "Epic";
                case Rarities.Legendary:
                    return "Legendary";
                case Rarities.Unique:
                    return "Unique";

            }

            return "";
        }
    }
}
