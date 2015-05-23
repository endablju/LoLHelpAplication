using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoLHelpAplication.Items
{
    [DataContract]
    public class ItemListDto : IListDto<ItemDto>
    {
        [DataMember]
        public Dictionary<string, ItemDto> data
        {
            get;
            set;
        }
        [DataMember]
        public string Type
        {
            get;
            set;
        }
        [DataMember]
        public string Version
        {
            get;
            set;
        }
    }
}
