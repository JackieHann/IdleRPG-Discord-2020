using IdleRPG_JH.Bots.Items;
using IdleRPG_JH.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleRPG_JH.Bots
{
    public class Weapon : Item
    {
        [JsonProperty]
        public int maxDamage;

        [JsonProperty]
        public int minDamage;

        [JsonProperty]
        public float attackSpeed;

        [JsonProperty]
        public string Prefix;

        [JsonProperty]
        public string Suffix;

        [JsonProperty]
        public ClassTypes ItemClass; 

        [JsonProperty]
        public WeaponTypes WeaponType;

        [JsonProperty]
        public HandRestriction Restriction { get; protected set; }

        public Weapon(ulong ide)
            : base(ide)
        { 
        
        }

        public void RollWeapon(int level)
        {
            Level = level;

            //roll a class
            ItemClass = ClassTypes.Warrior;

            Rarity = Rarities.Legendary;

            //random name
            int randomItemForClass = 1;
            Name = "Sword";

            //Random prefix
            int randomprefix = 1;
            Prefix = "Something";

            //Random suffix
            int randomSuffix = 1;
            Suffix = "of Something";

            iLevel = Level + randomprefix + randomSuffix;

            Perfection = 0.55f;

            attackSpeed = 1.0f;

            WeaponType = WeaponTypes.Sword;

            Restriction = HandRestriction.MainHand;

            minDamage = 1 + randomprefix;
            maxDamage = 3 + randomSuffix;
        }

        public override string GetFormattedNameString()
        {
            return "Weapon: " + Prefix + " " + Name + " " + Suffix;
        }

    }
}
