﻿using IdleRPG_JH.Bots.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IdleRPG_JH.Bots
{
    class WeaponManager
    {
        [JsonProperty("Weapons")]
        private List<Weapon> items { get; set; }

        private static string directory = "./../../../Weapons.json";
        private static int idOffset = 20000;

        public Weapon GetItemByID(ulong ID)
        {
            return items.Find(x => x.UniqueID == ID);
        }

        public void AddItem(Weapon newItem)
        {
            items.Add(newItem);
        }

        public static async Task<WeaponManager> FetchItemData()
        {
            WeaponManager itemManager = await Bot.ReadJSONFromFileIntoTypeAsync<WeaponManager>(directory);
            return itemManager;
        }

        internal void SaveItemData()
        {
            string toWrite = JsonConvert.SerializeObject(this);
            File.WriteAllText(directory, toWrite);
        }

        //Returns whether and ID is present
        public bool CheckItemID(ulong ID)
        {
            return items.Exists(x => x.UniqueID == ID);
        }

        public bool CheckItemID(int ID)
        {
            return CheckItemID(Convert.ToUInt64(ID));
        }


        public ulong GetUnusedID()
        {
            int id;
            Random rand = new Random();
            do
            {
                id = rand.Next(0, 9999);
                id += idOffset;
            }
            while (CheckItemID(id) == true);
            
            //We have a new itemID!
            return Convert.ToUInt64(id);
        }

    }
}
