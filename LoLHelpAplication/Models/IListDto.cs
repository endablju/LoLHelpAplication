using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LoLHelpAplication
{

    interface IListDto<T>
    {
        [DataMember]
        Dictionary<string, T> data { get; set; }
        [DataMember]
        string Type { get; set; }
        [DataMember]
        string Version { get; set; }
    }
}
