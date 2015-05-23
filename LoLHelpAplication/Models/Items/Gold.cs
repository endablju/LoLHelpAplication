using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LoLHelpAplication.Items
{
    [DataContract]
    public class Gold
    {
        [DataMember]
        public int total { get; set; }
        [DataMember]
        public int sell { get; set; }
       
    }
}
