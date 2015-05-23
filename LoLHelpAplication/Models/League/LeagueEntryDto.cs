using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoLHelpAplication.League
{
    [DataContract]
    public class LeagueEntryDto
    {
        [DataMember]
        public string division { get; set; }
        [DataMember]
        public int wins { get; set; }
        [DataMember]
        public int losses { get; set; }
        [DataMember]
        public int leaguePoints { get; set; }
        [DataMember]
        public string playerOrTeamName { get; set; }
        [DataMember]
        public long playerOrTeamId { get; set; }
    
    }
}
