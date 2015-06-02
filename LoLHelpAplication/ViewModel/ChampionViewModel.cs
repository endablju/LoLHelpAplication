using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoLHelpAplication.Base;

namespace LoLHelpAplication
{
    public class ChampionViewModel : NotificationObject 
    {
        public static ChampionViewModel FromChampion(ChampionDto champions)
        {
            return new ChampionViewModel
            {
                _id = champions.id,
                _name = champions.name,
                _title = champions.title,
                _full = champions.image.Full,
                _group = champions.image.Group,
                _blurb = champions.blurb
            };
        }
        
        private int _id;

        public int Id
        {
            get { return _id; }
            set 
            { 
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set 
            { 
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _full;
        private string _group;

        public string Group
        {
            get { return _group; }
            set 
            { 
                _group = value;
                OnPropertyChanged();
            }
        }

        public string Full
        {
            get { return _full; }
            set 
            { 
                _full = "http://ddragon.leagueoflegends.com/cdn/5.2.1/img/" + _group + "/" + value;
                OnPropertyChanged();
            }
        }

        private string _key;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private string _blurb;

        public string Blurb
        {
            get { return _blurb; }
            set { _blurb = value; }
        }

        public string DisplayedImage
        {
            get { return @"http://ddragon.leagueoflegends.com/cdn/5.2.1/img/" + _group + "/" + _full; }
        }
    }
}
