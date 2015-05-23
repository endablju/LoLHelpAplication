using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLHelpAplication
{
    public class ChampionsListDto : IListDto<ChampionDto>
    {

        public Dictionary<string, ChampionDto> data
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }
    }
}
