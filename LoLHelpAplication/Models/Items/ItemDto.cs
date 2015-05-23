using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LoLHelpAplication.Items
{
    [DataContract]
    public class ItemDto
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string  name { get; set; }
        [DataMember]
        public ImageDto image { get; set; }
        [DataMember]
        public Gold gold { get; set; }
    }
}
