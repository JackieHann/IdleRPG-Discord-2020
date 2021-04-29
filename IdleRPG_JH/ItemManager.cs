using IdleRPG_JH.Bots.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IdleRPG_JH.Bots
{
    class ItemManager
    {
        [JsonProperty("Items")]
        private List<Item> items { get; set; }

        private static string directory = "./../../../Items.json";
        private static int idOffset = 00000;

        public Item GetItemByID(ulong ID)
        {
            return items.Find(x => x.UniqueID == ID);
        }

        public void AddItem(Item newItem)
        {
            items.Add(newItem);
        }

        public static async Task<ItemManager> FetchItemData()
        {
            ItemManager itemManager = await Bot.ReadJSONFromFileIntoTypeAsync<ItemManager>(directory);
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
