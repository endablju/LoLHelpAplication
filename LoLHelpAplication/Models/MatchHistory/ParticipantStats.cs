using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LoLHelpAplication.MatchHistory
{
    [DataContract]
    public class ParticipantStats
    {
        [DataMember]
        public long kills { get; set; }
        [DataMember]
        public long deaths { get; set; }
        [DataMember]
        public long assists { get; set; }
        [DataMember]
        public long goldEarned { get; set; }
        [DataMember]
        public long item0 { get; set; }
        [DataMember]
        public long item1 { get; set; }
        [DataMember]
        public long item2 { get; set; }
        [DataMember]
        public long item3 { get; set; }
        [DataMember]
        public long item4 { get; set; }
        [DataMember]
        public long item5 { get; set; }
        [DataMember]
        public long item6 { get; set; }
        [DataMember]
        public Boolean winner { get; set; }
    }
}
