using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoLHelpAplication.Base;
using LoLHelpAplication.MatchHistory;

namespace LoLHelpAplication.ViewModel
{
    public class MatchViewModel : NotificationObject
    {
        public static MatchViewModel FromMatchHistory(MatchSummary match)
        {
            return new MatchViewModel
            {
                _mapId = match.matchId,
                _assist = match.participants.Single().stats.assist,
                _bot = match.participants.Single().bot,
                _championId = match.participants.Single().championId,
                _deaths = match.participants.Single().stats.deaths,
                _goldEarned = match.participants.Single().stats.goldEarned,
                _item0Id = match.participants.Single().stats.item0,
                _item1Id = match.participants.Single().stats.item1,
                _item2Id = match.participants.Single().stats.item2,
                _item3Id = match.participants.Single().stats.item3,
                _item4Id = match.participants.Single().stats.item4,
                _item5Id = match.participants.Single().stats.item5,
                _item6Id = match.participants.Single().stats.item6,
                _kill = match.participants.Single().stats.kill,
                _lane = match.participants.Single().timeLine.lane,
                _matchDuration = match.matchDuration,
                _matchHistoryUri = match.participantIdentities.Single().player.matchHistoryUri,
                _matchId = match.matchId,
                _matchMode = match.matchMode,
                _queueType = match.queueType,
                _regionType = match.regionType,
                _role = match.participants.Single().timeLine.role,
                _sesson = match.seson,
                _spell1Id = match.participants.Single().spell1Id,
                _spell2Id = match.participants.Single().spell2Id,
                _sumarryId = match.participantIdentities.Single().player.summaryId,
                _summaryName = match.participantIdentities.Single().player.summaryName,
                _teamId = match.participants.Single().teamId,
                _winner = match.participants.Single().stats.winner
            };
        }

        private long _mapId;

        public long MapId
        {
            get { return _mapId; }
            set 
            { 
                _mapId = value;
                RaisePropertyChanged();
            }
        }
        private long _matchDuration;

        public long MatchDuration
        {
            get { return _matchDuration; }
            set 
            { 
                _matchDuration = value;
                RaisePropertyChanged();
            }
        }

        private long _matchId;

        public long MatchId
        {
            get { return _matchId; }
            set 
            { 
                _matchId = value;
                RaisePropertyChanged();
            }
        }

        private string _matchMode;

        public string MatchMode
        {
            get { return _matchMode; }
            set 
            { 
                _matchMode = value;
                RaisePropertyChanged();
            }
        }

        private string _queueType;

        public string QueueType
        {
            get { return _queueType; }
            set 
            { 
                _queueType = value;
                RaisePropertyChanged();
            }
        }

        private string _regionType;

        public string RegionType
        {
            get { return _regionType; }
            set { _regionType = value; RaisePropertyChanged(); }
        }

        private string _sesson;

        public string Sesson
        {
            get { return _sesson; }
            set { _sesson = value; RaisePropertyChanged(); }
        }

        private int _championId;

        public int ChampionId
        {
            get { return _championId; }
            set 
            { 
                _championId = value;
                RaisePropertyChanged();
            }
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
        private int _teamId;

        public int TeamId
        {
            get { return _teamId; }
            set { _teamId = value; RaisePropertyChanged(); }
        }

        private bool _bot;

        public bool Bot
        {
            get { return _bot; }
            set { _bot = value; RaisePropertyChanged(); }
        }

        private long _kill;

        public long Kill
        {
            get { return _kill; }
            set { _kill = value; RaisePropertyChanged(); }
        }

        private long _deaths;

        public long Deaths
        {
            get { return _deaths; }
            set { _deaths = value; RaisePropertyChanged();}
        }

        private long _assist;

        public long Assist
        {
            get { return _assist; }
            set { _assist = value; RaisePropertyChanged();}
        }

        private long _goldEarned;

        public long GoldEarned
        {
            get { return _goldEarned; }
            set 
            { 
                _goldEarned = value;
                RaisePropertyChanged();
            }
        }
        private long _item0Id;

        public long Item0Id
        {
            get { return _item0Id; }
            set { 
                _item0Id = value;
                RaisePropertyChanged();
            }
        }
        private long _item1Id;

        public long Item1Id
        {
            get { return _item1Id; }
            set
            {
                _item1Id = value;
                RaisePropertyChanged();
            }
        }
        private long _item2Id;

        public long Item2Id
        {
            get { return _item2Id; }
            set
            {
                _item2Id = value;
                RaisePropertyChanged();
            }
        }
        private long _item3Id;

        public long Item3Id
        {
            get { return _item3Id; }
            set
            {
                _item3Id = value;
                RaisePropertyChanged();
            }
        }
        private long _item4Id;

        public long Item4Id
        {
            get { return _item4Id; }
            set
            {
                _item4Id = value;
                RaisePropertyChanged();
            }
        }
        private long _item5Id;

        public long Item5Id
        {
            get { return _item5Id; }
            set
            {
                _item5Id = value;
                RaisePropertyChanged();
            }
        }
        private long _item6Id;

        public long Item6Id
        {
            get { return _item6Id; }
            set
            {
                _item6Id = value;
                RaisePropertyChanged();
            }
        }

        private bool _winner;

        public bool Winner
        {
            get { return _winner; }
            set 
            { 
                _winner = value;
                RaisePropertyChanged();
            }
        }

        private string _lane;

        public string Lane
        {
            get { return _lane; }
            set { _lane = value;
            RaisePropertyChanged();
            }
        }

        private string _role;

        public string Role
        {
            get { return _role; }
            set 
            { 
                _role = value;
                RaisePropertyChanged();
            }
        }

        private string _matchHistoryUri;

        public string MatchHistoryUri
        {
            get { return _matchHistoryUri; }
            set 
            { 
                _matchHistoryUri = value;
                RaisePropertyChanged();
            }
        }

        private string _summaryName;

        public string SummaryName
        {
            get { return _summaryName; }
            set { _summaryName = value; RaisePropertyChanged();}
        }

        private long _sumarryId;

        public long SummaryId
        {
            get { return _sumarryId; }
            set { _sumarryId = value; RaisePropertyChanged();}
        }
      
    }
}
