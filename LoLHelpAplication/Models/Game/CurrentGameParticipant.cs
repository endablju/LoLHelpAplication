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
        public string summaryName { get; set; }
    }
}
