using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoLHelpAplication.Base;
using LoLHelpAplication.Game;

namespace LoLHelpAplication.ViewModel
{
    public class CurrentGameParticipantsViewModel : NotificationObject
    {
        public static CurrentGameParticipantsViewModel fromParticipants(CurrentGameParticipant part)
        {
            return new CurrentGameParticipantsViewModel
            {
                _championId = part.championId,
                _bot = part.bot,
                _spell1Id = part.spell1Id,
                _spell2Id = part.spell2Id,
                _sumarryId = part.summaryId,
                _summaryName = part.summaryName,
                _teamId = part.teamId
            };
        }

        private long _championId;

        public long ChampionId
        {
            get { return _championId; }
            set { _championId = value; RaisePropertyChanged(); }
        }
        private int _teamId;

        public int TeamId
        {
            get { return _teamId; }
            set { _teamId = value; RaisePropertyChanged(); }
        }

        private int _spell1Id;

        public int Spell1Id
        {
            get { return _spell1Id; }
            set
            {
                _spell1Id = value;
                RaisePropertyChanged();
            }
        }

        private int _spell2Id;

        public int Spell2Id
        {
            get { return _spell2Id; }
            set
            {
                _spell2Id = value;
                RaisePropertyChanged();
            }
        }

        private string _summaryName;

        public string SummaryName
        {
            get { return _summaryName; }
            set { _summaryName = value; RaisePropertyChanged(); }
        }

        private long _sumarryId;

        public long SummaryId
        {
            get { return _sumarryId; }
            set { _sumarryId = value; RaisePropertyChanged(); }
        }

        private bool _bot;
        public bool Bot
        {
            get { return _bot; }
            set { _bot = value; RaisePropertyChanged(); }
        }

        
    }
}
