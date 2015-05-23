using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using LoLHelpAplication.MatchHistory;

namespace LoLHelpAplication.MatchHistory
{
    [DataContract]
    public class ParticipanIdentity
    {
        [DataMember]
        public Player players { get; set; }
    }
}
