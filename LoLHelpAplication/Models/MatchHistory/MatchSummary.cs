using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoLHelpAplication.MatchHistory
{
    [DataContract]
    public class MatchSummary
    {
        [DataMember]
        public int mapId { get; set; }
        [DataMember]
        public long matchDuration { get; set; }
        [DataMember]
        public long matchId { get; set; }
        [DataMember]
        public string matchMode { get; set; }
        [DataMember]
        public string queueType { get; set; }
        [DataMember]
        public string regionType { get; set; }
        [DataMember]
        public string seson { get; set; }
        [DataMember]
        public List<ParticipanIdentity> participantIdentities { get; set; }
        [DataMember]
        public List<Participant> participants { get; set; }
    }
}
