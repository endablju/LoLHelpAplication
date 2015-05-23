using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLHelpAplication
{
    public class ImageDto
    {

        private string _full;
        private string _group;

        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public string Full
        {
            get { return _full; }
            set 
            { 
                //_full = "http://ddragon.leagueoflegends.com/cdn/5.2.1/img/" + _group +"/" + value; 
                _full = value;
            }
        }

        
    }
}
