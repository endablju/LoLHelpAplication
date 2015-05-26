using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using LoLHelpAplication.MatchHistory;

namespace LoLHelpAplication.MatchHistory
{
    [DataContract]
    public class PlayerHistory
    {
        [DataMember]
        public List<MatchSummary> matches;
    }
}
