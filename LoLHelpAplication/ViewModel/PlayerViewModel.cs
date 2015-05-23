using LoLHelpAplication.Base;
using LoLHelpAplication.League;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLHelpAplication
{
    public class PlayerViewModel : NotificationObject
    {
        public static PlayerViewModel FromPlayer(Player player)
        {
            return new PlayerViewModel
            {
                _id = player.id,
                _name = player.name,
                _summonerLevel = player.summonerLevel,
                _profileIconId = player.profileIconId,
                _revisionDate = player.revisionDate
            };
        }

        private long _id;

        public long Id
        {
            get { return _id; }
            set { 
                    _id = value;
                    RaisePropertyChanged();
                }
        }
        
        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                RaisePropertyChanged();
            }
        }

        private long _summonerLevel;

        public long SummonerLevel
        {
            get { return _summonerLevel; }
            set 
            { 
                _summonerLevel = value;
                RaisePropertyChanged();
            }
        }

        private int _profileIconId;

        public int ProfileIconId
        {
            get { return _profileIconId; }
            set 
            { 
                _profileIconId = value;
                RaisePropertyChanged();
            }
        }

        private long _revisionDate;

        public long RevisionDate
        {
            get { return _revisionDate; }
            set 
            { 
                _revisionDate = value;
                RaisePropertyChanged();
            }
        }

    }
}
