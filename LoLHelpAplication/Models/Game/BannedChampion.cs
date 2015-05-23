using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LoLHelpAplication.Game
{
    [DataContract]
    public class BannedChampion
    {
        [DataMember]
        public long championsId { get; set; }
        [DataMember]
        public long teamId { get; set; }
        [DataMember]
        public long pickTurn { get; set; }
    }
}