using LoLHelpAplication.Summoner_spells;
using LoLHelpAplication.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLHelpAplication
{
    public class SpellViewModel : NotificationObject
    {
        public static SpellViewModel FromSpell(SummonerSpellDto spells)
        {
            return new SpellViewModel
            {
                _id = spells.id,
                _name = spells.name,
                _descriptions = spells.description,
                _group = spells.image.Group,
                _full = spells.image.Full,
                _key = spells.key,
                _summonerLevel = spells.SummonerLevel,
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

        private string _descriptions;

        public string Descriptions
        {
            get { return _descriptions; }
            set
            {
                _descriptions = value;
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
                //_full = "http://ddragon.leagueoflegends.com/cdn/5.2.1/img/" + _group + "/" + value;
                _full = value;
                OnPropertyChanged();
            }
        }

        private string _key;

        public string Key
        {
            get { return _key; }
            set 
            {
                _key = value;
                OnPropertyChanged();
            }
        }

        private int _summonerLevel;

        public int SummonerLevel
        {
            get { return _summonerLevel; }
            set 
            { 
                _summonerLevel = value;
                OnPropertyChanged();
            }
        }


        public string GetSummonerLevel
        {
            get { return "Min level " + _summonerLevel; }   
        }

        public string DisplayedImage
        {
            get { return @"http://ddragon.leagueoflegends.com/cdn/5.2.1/img/" + _group + "/" + _full; }
        }
    }
}