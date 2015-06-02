using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoLHelpAplication.Game
{
    [DataContract]
    public class CurrentGameParticipant
    {
        [DataMember]
        public int championId { get; set; }
        [DataMember]
        public int spell1Id { get; set; }
        [DataMember]
        public int spell2Id { get; set; }
        [DataMember]
        public int teamId { get; set; }
        [DataMember]
        public bool bot { get; set; }
        [DataMember]
        public long summaryId { get; set; }
        [DataMember]
        public string summonerName { get; set; }
        public string championStr { get; set; }
        [DataMember]
        public string spell1Str { get; set; }
        [DataMember]
        public string spell2Str { get; set; }
    }
}
