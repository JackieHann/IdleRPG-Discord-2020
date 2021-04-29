using IdleRPG_JH.Bots.Items;
using IdleRPG_JH.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleRPG_JH.Bots
{
    public class Armour : Item
    {
        public Armour(ulong ide)
            : base(ide)
        {

        }

        [JsonProperty]
        public ClassTypes ItemClass;

        [JsonProperty]
        public ArmourTypes ArmourType;

        [JsonProperty]
        public BodyRestriction Restriction;

        [JsonProperty]
        public int maxArmour;

        [JsonProperty]
        public int minArmour;

        [JsonProperty]
        public string Prefix;

        [JsonProperty]
        public string Suffix;

        public void RollArmour(int level)
        {
            Level = level;

            //roll a class
            ItemClass = ClassTypes.Warrior;

            Rarity = Rarities.Legendary;

            //random name
            int randomItemForClass = 1;
            Name = "Helmet";
            Restriction = BodyRestriction.Head;

            //Random prefix
            int randomprefix = 1;
            Prefix = "Something";

            //Random suffix
            int randomSuffix = 1;
            Suffix = "of Something Else";

            iLevel = Level + randomprefix + randomSuffix;

            Perfection = 0.45f;

            ArmourType = ArmourTypes.Heavy;

            minArmour = 10 + randomprefix;
            maxArmour = minArmour + 3 + randomSuffix;

        }

        private string GetArmourTypeString()
        {
            switch (ArmourType)
            {
                case ArmourTypes.Heavy:     return "Heavy";
                case ArmourTypes.Medium:    return "Medium";
                case ArmourTypes.Light:     return "Light";
            }

            return "";
        }
        public override string GetFormattedNameString()
        {
            return $"Armour: {Prefix} {GetArmourTypeString()} {Name} {Suffix}";
        }

    }
}
