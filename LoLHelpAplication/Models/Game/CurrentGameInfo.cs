using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using LoLHelpAplication.MatchHistory;

namespace LoLHelpAplication.Game
{
    [DataContract]
    public class CurrentGameInfo
    {
        [DataMember]
        public long gameId { get; set; }
        [DataMember]
        public string gameType { get; set; }
        [DataMember]
        public string gameMode { get; set; }
        [DataMember]
        public long mapId { get; set; }
        [DataMember]
        public Observer observers { get; set; }
        [DataMember]
        public BannedChampion bannedChampions { get; set; }
        [DataMember]
        public string platformId { get; set; }
        [DataMember]
        public List<CurrentGameParticipant> participants { get; set; }
    }
}
