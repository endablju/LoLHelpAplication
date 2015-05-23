using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LoLHelpAplication.Game
{
    [DataContract]
    public class Observer
    {
        [DataMember]
        public string encryptionKey { get; set; }
    }
}
