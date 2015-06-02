using LoLHelpAplication.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoLHelpAplication.Services
{
    public static class ItemService
    {
        public static ItemListDto GetItems()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ItemListDto result;
            using (StreamReader reader = File.OpenText(@"..\..\Data\items.json"))
            {
                string text = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<ItemListDto>(text);
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));
            
            return result;
        }
    }
}
