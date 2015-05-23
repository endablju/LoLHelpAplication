using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LoLHelpAplication.MatchHistory
{
    [DataContract]
    public class ParticipantTimeLine
    {
        [DataMember]
        public string lane { get; set; }
        [DataMember]
        public string role { get; set; }
    }
}
