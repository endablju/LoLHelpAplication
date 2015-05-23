using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoLHelpAplication.Base;
using LoLHelpAplication.Game;
using LoLHelpAplication.ViewModel;

namespace LoLHelpAplication.ViewModel 
{
    public class GameViewModel :NotificationObject
    {

        public static GameViewModel FromGame(CurrentGameInfo info)
        {
            return new GameViewModel
            {
                _encryptionKey = info.observers.encryptionKey,
                _gameId = info.gameId,
                _gameMode = info.gameMode,
                _gameType = info.gameType,
                _mapId = info.mapId,
                //Participants = CurrentGameParticipantsViewModel.fromParticipants(info.participants.);
                //_participants =     
            };
        }

        private long _gameId;

        public long GameId
        {
            get { return _gameId; }
            set { _gameId = value; RaisePropertyChanged(); }
        }
        private string _gameType;

        public string GameType
        {
            get { return _gameType; }
            set { _gameType = value; RaisePropertyChanged(); }
        }

        private string _gameMode;

        public string GameMode
        {
            get { return _gameMode; }
            set { _gameMode = value; RaisePropertyChanged(); }
        }

        private long _mapId;

        public long MapId
        {
            get { return _mapId; }
            set { _mapId = value; RaisePropertyChanged(); }
        }

        private string platformId;

        public string PlatformId
        {
            get { return platformId; }
            set { platformId = value; RaisePropertyChanged(); }
        }

        private string _encryptionKey;

        public string EncryptionKey
        {
            get { return _encryptionKey; }
            set { _encryptionKey = value; RaisePropertyChanged(); }
        }



        private List<CurrentGameParticipantsViewModel> _participants;

        public List<CurrentGameParticipantsViewModel> Participants
        {
            get { return _participants; }
            set { _participants = value; RaisePropertyChanged(); }
        }
        

    }
}
