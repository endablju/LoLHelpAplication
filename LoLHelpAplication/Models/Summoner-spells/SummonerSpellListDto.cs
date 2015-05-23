using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoLHelpAplication.Summoner_spells
{
    [DataContract]
    public class SummonerSpellListDto : IListDto<SummonerSpellDto> 
    {
        [DataMember]
        public Dictionary<string, SummonerSpellDto> data  
        {
            get;
            set;
        }
        [DataMember]
        public string Type
        {
            get;
            set;
        }
        [DataMember]
        public string Version
        {
            get;
            set;
        }
    }
}
