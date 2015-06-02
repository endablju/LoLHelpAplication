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
                _participants = info.participants,  
                _platformId = info.platformId

            };
        }

        private long _gameId;

        public long GameId
        {
            get { return _gameId; }
            set { _gameId = value; OnPropertyChanged(); }
        }
        private string _gameType;

        public string GameType
        {
            get { return _gameType; }
            set { _gameType = value; OnPropertyChanged(); }
        }

        private string _gameMode;

        public string GameMode
        {
            get { return _gameMode; }
            set { _gameMode = value; OnPropertyChanged(); }
        }

        private long _mapId;

        public long MapId
        {
            get { return _mapId; }
            set { _mapId = value; OnPropertyChanged(); }
        }

        private string _platformId;

        public string PlatformId
        {
            get { return _platformId; }
            set { _platformId = value; OnPropertyChanged(); }
        }

        private string _encryptionKey;

        public string EncryptionKey
        {
            get { return _encryptionKey; }
            set { _encryptionKey = value; OnPropertyChanged(); }
        }


        private List<CurrentGameParticipant> _participants;
     
        public List<CurrentGameParticipant> Participants
        {
            get { return _participants; }
            set { _participants = value; OnPropertyChanged(); }
        }
        

    }
}
