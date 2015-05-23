using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoLHelpAplication.MatchHistory
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public string matchHistoryUri { get; set; }
        [DataMember]
        public long summaryId { get; set; }
        [DataMember]
        public string summaryName { get; set; }
    }
}
