using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LoLHelpAplication.League
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public long summonerLevel { get; set; }
        [DataMember]
        public int profileIconId { get; set; }
        [DataMember]
        public long revisionDate { get; set; }

        
        
    }
}
