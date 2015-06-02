using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLHelpAplication
{
    public class ChampionDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public string title { get; set; }
        public ImageDto image { get; set; }

        public string key { get; set; }

        public string blurb { get; set; }

    }
}
