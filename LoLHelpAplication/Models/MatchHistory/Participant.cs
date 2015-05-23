using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LoLHelpAplication.MatchHistory
{
    [DataContract]
    public class Participant
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
        public ParticipantStats stats { get; set; }
        [DataMember]
        public ParticipantTimeLine timeLine { get; set; }
        [DataMember]
        public bool bot { get; set; }



    }
}
