using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using LoLHelpAplication.Summoner_spells;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

namespace LoLHelpAplication.Services
{
    public static class SpellService
    {
        public static SummonerSpellListDto GetSpells()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            SummonerSpellListDto result;
            using (StreamReader reader = File.OpenText(@"Data\summoner_spells.json"))
            {
                string text = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<SummonerSpellListDto>(text);
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));

            return result;
        }
    }
}
