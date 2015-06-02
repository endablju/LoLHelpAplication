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
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SpellViewModel> _spellList = new ObservableCollection<SpellViewModel>();

        public ObservableCollection<SpellViewModel> SpellList
        {
            get { return _spellList; }
            set
            {
                _spellList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ChampionViewModel> _championsList = new ObservableCollection<ChampionViewModel>();

        public ObservableCollection<ChampionViewModel> ChampionList
        {
            get { return _championsList; }
            set
            {
                _championsList = value;
                OnPropertyChanged();
            }
        }

        private PlayerViewModel _findPlayer;

        public PlayerViewModel FindPlayer
        {
            get { return _findPlayer; }
            set 
            { 
                _findPlayer = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<MatchViewModel> _matchList = new ObservableCollection<MatchViewModel>();

        public ObservableCollection<MatchViewModel> MatchList
        {
            get { return _matchList; }
            set { _matchList = value; OnPropertyChanged(); }
        }

        private GameViewModel _gameInfo;

        public GameViewModel GameInfo
        {
            get { return _gameInfo; }
            set { _gameInfo = value; OnPropertyChanged(); }
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
                FindPlayer = PlayerViewModel.FromPlayer(player.Values.First());
                IdTextBox = FindPlayer.Id.ToString();
                
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
                OnPropertyChanged();
            }
        }

        private string _idTextBox;

        public string IdTextBox
        {
            get { return _idTextBox; }
            set
            {
                _idTextBox = value;
                OnPropertyChanged();
            }
        }

        private void OnLoadItems(object _)
        {
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
                }, TaskScheduler.FromCurrentSynchronizationContext())
                .ContinueWith(
                task =>
                {
                    ItemList = new ObservableCollection<ItemViewModel>(ItemList.OrderBy(i => i.Id));
                }
                );
        }

        private ItemViewModel _selectedItem;
        public ItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private SpellViewModel _selectedSpell;
        public SpellViewModel SelectedSpell
        {
            get { return _selectedSpell; }
            set
            {
                _selectedSpell = value;
                OnPropertyChanged();
            }
        } 
        
        private void OnLoadSpell(object _)
        {
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
                }, TaskScheduler.FromCurrentSynchronizationContext())
                .ContinueWith(
                task =>
                {
                    SpellList = new ObservableCollection<SpellViewModel>(SpellList.OrderBy(i => i.SummonerLevel));
                }
                );
        }

        private void OnLoadChampions(object _)
        {
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
                }, TaskScheduler.FromCurrentSynchronizationContext())
                .ContinueWith(
                task => 
                {
                    ChampionList = new ObservableCollection<ChampionViewModel>(ChampionList.OrderBy(i => i.Name));
                }
                );
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
                
                var id_name = from match in MatchList join champion in ChampionList on match.ChampionId equals champion.Id select new{champion.Name};
                var item0 = from match in MatchList join item in ItemList on match.Item0Id equals item.Id select new{item.Name};
                var item1 = from match in MatchList join item in ItemList on match.Item1Id equals item.Id select new { item.Name };
                var item2 = from match in MatchList join item in ItemList on match.Item2Id equals item.Id select new { item.Name };
                var item3 = from match in MatchList join item in ItemList on match.Item3Id equals item.Id select new { item.Name };
                var item4 = from match in MatchList join item in ItemList on match.Item4Id equals item.Id select new { item.Name };
                var item5 = from match in MatchList join item in ItemList on match.Item5Id equals item.Id select new { item.Name };
                var item6 = from match in MatchList join item in ItemList on match.Item6Id equals item.Id select new { item.Name };

                int i = 0;
                foreach (var list in MatchList )
                {
                    list.ChampionString = id_name.ElementAt(i).Name;
                    
                    list.Item0Str = item0.ElementAt(i).Name;
                    list.Item1Str = item1.ElementAt(i).Name;
                    list.Item2Str = item2.ElementAt(i).Name;
                    list.Item3Str = item3.ElementAt(i).Name;
                    list.Item4Str = item4.ElementAt(i).Name;
                    list.Item5Str = item5.ElementAt(i).Name;
                    list.Item6Str = item6.ElementAt(i).Name;
                    
                    i++;
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
                GameInfo = GameViewModel.FromGame(gameInfo);
                var spell1 = from spel1 in GameInfo.Participants join sp1 in SpellList on spel1.spell1Id equals sp1.Id select new { sp1.Name };
                var spell2 = from spel2 in GameInfo.Participants join sp2 in SpellList on spel2.spell2Id equals sp2.Id select new { sp2.Name };
                var champion = from champ in  GameInfo.Participants join ch in ChampionList on champ.championId equals ch.Id select new { ch.Name };

                int i = 0;
                foreach (var ch in GameInfo.Participants)
                {
                    ch.championStr = champion.ElementAt(i).Name;
                    ch.spell1Str = spell1.ElementAt(i).Name;
                    ch.spell2Str = spell2.ElementAt(i).Name;
                    i++;
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
       
        private BasicCommand _currentGame;

        public BasicCommand CurrentGame
        {
            get { return _currentGame ?? (_currentGame = new BasicCommand(searchCurrentGame)); }
        }
        
        public MainWindowViewModel()
        {
            OnLoadSpell(this);
            OnLoadItems(this);
            OnLoadChampions(this);
        }

        private MatchViewModel _selectedMatch;
        public MatchViewModel SelectedMatch
        {
            get { return _selectedMatch; }
            set
            {
                _selectedMatch = value;
                OnPropertyChanged();
            }
        }

        private ChampionViewModel _selectedChampion;
        public ChampionViewModel SelectedChampion
        {
            get { return _selectedChampion; }
            set
            {
                _selectedChampion = value;
                OnPropertyChanged();
            }
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

       private bool CanLoadChampions(object _)
       {
           return !IsLoadingChampions;
       }

       private BasicCommand _loadChampions;

       public BasicCommand LoadChampions
       {
           get { return _loadChampions ?? (_loadChampions = new BasicCommand(OnLoadChampions, CanLoadChampions)); }
       }

       private BasicCommand _loadSpells;

       public BasicCommand LoadSpells
       {
           get { return _loadSpells ?? (_loadSpells = new BasicCommand(OnLoadSpell, CanLoadSpell)); }
       }

       private bool CanLoadSpell(object _)
       {
           return !IsLoadingSpells;
       }

       private bool CanLoadItems(object _)
       {
           return !IsLoadingItems;
       }
       // */

    }
}
