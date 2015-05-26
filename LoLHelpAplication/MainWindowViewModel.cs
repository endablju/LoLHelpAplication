using LoLHelpAplication.Base;
using LoLHelpAplication.Items;
using LoLHelpAplication.League;
using LoLHelpAplication.Services;
using LoLHelpAplication.Summoner_spells;
using LoLHelpAplication.MatchHistory;
using LoLHelpAplication.ViewModel;
using LoLHelpAplication.Game;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoLHelpAplication
{
    public class MainWindowViewModel : NotificationObject
    {

        private ObservableCollection<ItemViewModel> _itemList = new ObservableCollection<ItemViewModel>();
        public ObservableCollection<ItemViewModel> ItemList
        {
            get 
            {
                return _itemList; 
            }
            set
            {
                _itemList = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<SpellViewModel> _spellList = new ObservableCollection<SpellViewModel>();

        public ObservableCollection<SpellViewModel> SpellList
        {
            get { return _spellList; }
            set
            {
                _spellList = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<ChampionViewModel> _championsList = new ObservableCollection<ChampionViewModel>();

        public ObservableCollection<ChampionViewModel> ChampionList
        {
            get { return _championsList; }
            set
            {
                _championsList = value;
                RaisePropertyChanged();
            }
        }

        private LoLHelpAplication.League.Player _findPlayer;

        public LoLHelpAplication.League.Player FindPlayer
        {
            get { return _findPlayer; }
            set 
            { 
                _findPlayer = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<MatchViewModel> _matchList = new ObservableCollection<MatchViewModel>();

        public ObservableCollection<MatchViewModel> MatchList
        {
            get { return _matchList; }
            set { _matchList = value; RaisePropertyChanged(); }
        }

        private CurrentGameInfo _gameInfo;

        public CurrentGameInfo GameInfo
        {
            get { return _gameInfo; }
            set { _gameInfo = value; RaisePropertyChanged(); }
        }

        private void searchSummonerByName(object _)
        {
            String url = "https://eune.api.pvp.net/api/lol/eune/v1.4/summoner/by-name/" + SearchTextBox + "?api_key=77692cb6-ae7f-40a3-922c-d5ae529236a3";
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            string result = null;
            try
            {
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    result = reader.ReadToEnd();

                }
                var player = JsonConvert.DeserializeObject<Dictionary<string, LoLHelpAplication.League.Player>>(result);
                FindPlayer = player.Values.First(); 
                //PlayerList.Add(new PlayerViewModel() { id = player.Values.First().id, name = player.Values.First().name, summonerLevel = player.Values.First().summonerLevel, revisionDate = player.Values.First().revisionDate, profileIconId = player.Values.First().profileIconId });
                //PlayerList.Add(PlayerViewModel.FromPlayer(player.Values.First()));
                IdTextBox = FindPlayer.id.ToString();
                
            }
            catch (WebException ex)
            {
                HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                    MessageBox.Show("Not found");
                else if (errorResponse.StatusCode == HttpStatusCode.BadRequest)
                    MessageBox.Show("Bad Request");
                else if (errorResponse.StatusCode == HttpStatusCode.ServiceUnavailable)
                    MessageBox.Show("Service Unvailable");
                else if (errorResponse.StatusCode == HttpStatusCode.InternalServerError)
                    MessageBox.Show("Internal Server Error");                 
                else if (errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                    MessageBox.Show("Unauthorized");
            }
        }

        private BasicCommand _searchSummoner;

        public BasicCommand SearchSummoner
        {
            get { return _searchSummoner ?? (_searchSummoner = new BasicCommand(searchSummonerByName)); }
        }

        private string _searchTextBox;

        public string SearchTextBox
        {
            get { return _searchTextBox; }
            set {
                _searchTextBox = value;
                RaisePropertyChanged();
            }
        }

        private string _idTextBox;

        public string IdTextBox
        {
            get { return _idTextBox; }
            set
            {
                _idTextBox = value;
                RaisePropertyChanged();
            }
        }

        private bool _isLoadingItems;

        public bool IsLoadingItems
        {
            get { return _isLoadingItems; }
            set
            {
                _isLoadingItems = value;
                RaisePropertyChanged();
            }
        }

        private bool _isLoadingSpell;

        public bool IsLoadingSpells
        {
            get { return _isLoadingSpell; }
            set
            {
                _isLoadingSpell = value;
                RaisePropertyChanged();
            }
        }

        private bool _isLoadingChampions;

        public bool IsLoadingChampions
        {
            get { return _isLoadingChampions; }
            set
            {
                _isLoadingChampions = value;
                RaisePropertyChanged();
            }
        }

        private BasicCommand _loadItems;

        public BasicCommand LoadItems
        {
            get { return _loadItems ?? (_loadItems = new BasicCommand(OnLoadItems, CanLoadItems)); }
        }

        private void OnLoadItems(object _)
        {
            IsLoadingItems = true;

            Task<ItemListDto>.Factory.StartNew(
                () =>
                {
                    return ItemService.GetItems();
                },
                TaskCreationOptions.LongRunning)
            .ContinueWith(
                task =>
                {
                    foreach (var item in task.Result.data)
                    {
                        ItemList.Add(ItemViewModel.FromItem(item.Value));
                    }
                    IsLoadingItems = false;
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private bool CanLoadItems(object _)
        {
            return !IsLoadingItems;
        }

        private ItemViewModel _selectedItem;
        public ItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }

        private SpellViewModel _selectedSpell;
        public SpellViewModel SelectedSpell
        {
            get { return _selectedSpell; }
            set
            {
                _selectedSpell = value;
                RaisePropertyChanged();
            }
        } 
        private bool CanLoadSpell(object _)
        {
            return !IsLoadingSpells;
        }

        private void OnLoadSpell(object _)
        {
            IsLoadingSpells = true;

            Task<SummonerSpellListDto>.Factory.StartNew(
                () =>
                {
                    return SpellService.GetSpells();
                },
                TaskCreationOptions.LongRunning)
            .ContinueWith(
                task =>
                {
                    foreach (var spell in task.Result.data)
                    {
                        SpellList.Add(SpellViewModel.FromSpell(spell.Value));
                    }
                    IsLoadingSpells = false;
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private BasicCommand _loadSpells;

        public BasicCommand LoadSpells
        {
            get { return _loadSpells ?? (_loadSpells = new BasicCommand(OnLoadSpell, CanLoadSpell)); }
        }

        private bool CanLoadChampions(object _)
        {
            return !IsLoadingChampions;
        }

        private void OnLoadChampions(object _)
        {
            IsLoadingChampions = true;

            Task<ChampionsListDto>.Factory.StartNew(
                () =>
                {
                    return ChampionService.GetChampions();
                },
                TaskCreationOptions.LongRunning)
            .ContinueWith(
                task =>
                {
                    foreach (var champion in task.Result.data)
                    {
                        ChampionList.Add(ChampionViewModel.FromChampion(champion.Value));
                    }
                    IsLoadingChampions = false;
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private BasicCommand _loadChampions;

        public BasicCommand LoadChampions
        {
            get { return _loadChampions ?? (_loadChampions = new BasicCommand(OnLoadChampions, CanLoadChampions)); }
        }

        private void searchMatchHistory(object _)
        {
            String url = "https://eune.api.pvp.net/api/lol/eune/v2.2/matchhistory/" + IdTextBox + "?api_key=77692cb6-ae7f-40a3-922c-d5ae529236a3";
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            string result = null;
            try
            {
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    result = reader.ReadToEnd();

                }
                var matchHistory = JsonConvert.DeserializeObject<PlayerHistory>(result);
                
                foreach (var listMatchHistory in matchHistory.matches)
                {
                MatchList.Add(MatchViewModel.FromMatchHistory(listMatchHistory));                   
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                    MessageBox.Show("Not found");
                else if (errorResponse.StatusCode == HttpStatusCode.BadRequest)
                    MessageBox.Show("Bad Request");
                else if (errorResponse.StatusCode == HttpStatusCode.ServiceUnavailable)
                    MessageBox.Show("Service Unvailable");
                else if (errorResponse.StatusCode == HttpStatusCode.InternalServerError)
                    MessageBox.Show("Internal Server Error");                 
                else if (errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                    MessageBox.Show("Unauthorized");
                
            }
        }

        private BasicCommand _history;

        public BasicCommand History
        {
            get { return _history ?? (_history = new BasicCommand(searchMatchHistory)); }
        }
        private void searchCurrentGame(object _)
        {
            String url = "https://eune.api.pvp.net/observer-mode/rest/consumer/getSpectatorGameInfo/EUN1/" + IdTextBox + "?api_key=77692cb6-ae7f-40a3-922c-d5ae529236a3";
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            string result = null;
            try
            {
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    result = reader.ReadToEnd();

                }
                var gameInfo = JsonConvert.DeserializeObject<CurrentGameInfo>(result);
                GameInfo = gameInfo;
            }
            catch (WebException ex)
            {
                HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                    MessageBox.Show("Not found");
                else if (errorResponse.StatusCode == HttpStatusCode.BadRequest)
                    MessageBox.Show("Bad Request");
                else if (errorResponse.StatusCode == HttpStatusCode.ServiceUnavailable)
                    MessageBox.Show("Service Unvailable");
                else if (errorResponse.StatusCode == HttpStatusCode.InternalServerError)
                    MessageBox.Show("Internal Server Error");
                else if (errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                    MessageBox.Show("Unauthorized");

            }
        }
        private BasicCommand _currentGame;

        public BasicCommand CurrentGame
        {
            get { return _currentGame ?? (_currentGame = new BasicCommand(searchCurrentGame)); }
        }
        /*
        private BasicCommand _displeyPlayers;

        public BasicCommand DispleyPlayers
        {
            get { return _displeyPlayers ?? (_displeyPlayers = new BasicCommand(displeyPlayersListBox)); }
        }

        private void displeyPlayersListBox(object _)
        {
            
        }
        */
        
        
    }
}
