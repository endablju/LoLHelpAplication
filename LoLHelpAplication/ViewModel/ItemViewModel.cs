using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoLHelpAplication.Base;
using LoLHelpAplication.Items;

namespace LoLHelpAplication
{
    public class ItemViewModel : NotificationObject
    {
        public static ItemViewModel FromItem(ItemDto items)
        {
            return new ItemViewModel
            {
                _id = items.id,
                _name = items.name,
                _descriptions = items.description,
                _group = items.image.Group,
                _full = items.image.Full,
                _sell = items.gold.sell,
                _total = items.gold.total
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

        private int _total;

        public int Total
        {
            get { return _total; }
            set 
            { 
                _total = value;
                OnPropertyChanged();
            }
        }

        private int _sell;

        public int Sell
        {
            get { return _sell; }
            set 
            { 
                _sell = value;
                OnPropertyChanged();
            }
        }

        public string DisplayedImage
        {
            get { return @"http://ddragon.leagueoflegends.com/cdn/5.2.1/img/"+_group+"/"+_full; }
        }


    }
}
