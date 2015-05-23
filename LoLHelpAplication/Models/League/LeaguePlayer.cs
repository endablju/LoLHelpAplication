using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoLHelpAplication.League
{
    [DataContract]
    public class LeaguePlayer
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string queue { get; set; }
        [DataMember]
        public string tier { get; set; }
        [DataMember]
        public List<LeagueEntryDto> entries { get; set; }
        
    }
}
