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
    public static class ChampionService
    {
        public static ChampionsListDto GetChampions()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ChampionsListDto result;
            using (StreamReader reader = File.OpenText(@"Data\champions.json"))
            {
                string text = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<ChampionsListDto>(text);
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));

            return result;
        }
    }
}
