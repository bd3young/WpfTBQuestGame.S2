using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTBQuestGame.S2.Models;
using System.Collections.ObjectModel;
using WpfTBQuestGame.S2.DataLayer;
using System.Windows;

namespace WpfTBQuestGame.S2.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {

        #region FIELDS

        private Player _player;
        private List<string> _messages;

        private Map _gameMap;
        private Location _currentLocation;
		private Location _northLocation, _eastLocation, _southLocation, _westLocation;
        private string _currentLocationInformation;
		protected Random random = new Random();

		private GameItem _currentGameItem;

        private Npc _currentNpc;
        private Shrine _currentShrine;

        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set
			{
				_player = value;
			}
        }

        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
			set
			{
				_currentLocation = value;
                _currentLocationInformation = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
		}

		public Location NorthLocation
		{
			get { return _northLocation; }
			set
			{
				_northLocation = value;
				OnPropertyChanged(nameof(NorthLocation));
				OnPropertyChanged(nameof(HasNorthLocation));
			}
		}

		public Location EastLocation
		{
			get { return _eastLocation; }
			set
			{
				_eastLocation = value;
				OnPropertyChanged(nameof(EastLocation));
				OnPropertyChanged(nameof(HasEastLocation));
			}
		}

		public Location SouthLocation
		{
			get { return _southLocation; }
			set
			{
				_southLocation = value;
				OnPropertyChanged(nameof(SouthLocation));
				OnPropertyChanged(nameof(HasSouthLocation));
			}
		}

		public Location WestLocation
		{
			get { return _westLocation; }
			set
			{
				_westLocation = value;
				OnPropertyChanged(nameof(WestLocation));
				OnPropertyChanged(nameof(HasWestLocation));
			}
		}

        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public bool HasNorthLocation { get { return NorthLocation != null; } }
		public bool HasEastLocation { get { return EastLocation != null; } }
		public bool HasSouthLocation { get { return SouthLocation != null; } }
		public bool HasWestLocation { get { return WestLocation != null; } }

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }

        public Npc CurrentNpc
        {
            get { return _currentNpc; }
            set
            {
                _currentNpc = value;
                OnPropertyChanged(nameof(CurrentNpc));
            }
        }

        public Shrine CurrentShrine
        {
            get { return _currentShrine; }
            set
            {
                _currentShrine = value;
                OnPropertyChanged(nameof(CurrentShrine));
            }
        }

		#endregion

		#region METHODS

		#endregion

		#region CONSTRUCTORS

		public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            List<string> initialMessages,
            Map gameMap,
            GameMapCoordinates currentLocationCoordinates
            )
        {
            _player = player;
            _messages = initialMessages;

            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
			InitializeView();
		}

		private void InitializeView()
		{
			UpdateAvailableTravelPoints();
            _player.UpdateInventoryCategories();
            _player.UpdateCrewCategories();
            _currentLocationInformation = CurrentLocation.Description;

		}

        #region MOVEMENT METHODS

		/// <summary>
		/// calculate travel points
		/// </summary>

		private void UpdateAvailableTravelPoints()
		{
			//
			// reset travel location information
			//
			NorthLocation = null;
			EastLocation = null;
			SouthLocation = null;
			WestLocation = null;

			if (_gameMap.NorthLocation(_player) != null)
			{
				NorthLocation = _gameMap.NorthLocation(_player);
			}

			if (_gameMap.EastLocation(_player) != null)
			{
				EastLocation = _gameMap.EastLocation(_player);
			}

			if (_gameMap.SouthLocation(_player) != null)
			{
				SouthLocation = _gameMap.SouthLocation(_player);
			}

			if (_gameMap.WestLocation(_player) != null)
			{
				WestLocation = _gameMap.WestLocation(_player);
			}
		}

		/// <summary>
		/// player move event handler
		/// </summary>
		private void OnPlayerMove()
		{
			//
			// update player stats
			//
				_player.Traveled += _currentLocation.ModifyTraveled;
                _player.Health = _player.Health - 10;

			if (!_player.HasVisited(_currentLocation))
			{
				_player.LocationsVisited.Add(_currentLocation);
				_player.Exp += _currentLocation.ModifyExp;
			}
            if (_player.Health <= 0)
            {
                _player.Lives = _player.Lives - 1;
                _player.Health = _player.Health + 100;
                CurrentLocationInformation = "The curse has consumed part of your soul. You lose a life.";
            }
            if (_player.Lives <= 0)
            {
                CurrentLocationInformation = "The curse has consumed your soul. You colapse to the ground.";
                OnPlayerDies("You have been consumed by the curse.");
            }
		}

		/// <summary>
		/// travel north
		/// </summary>
		public void MoveNorth()
        {
            _gameMap.MoveNorth();
            CurrentLocation = _gameMap.CurrentLocation;
			UpdateAvailableTravelPoints();
			OnPlayerMove();

        }

        /// <summary>
        /// travel east
        /// </summary>
        public void MoveEast()
        {
            _gameMap.MoveEast();
            CurrentLocation = _gameMap.CurrentLocation;
			UpdateAvailableTravelPoints();
			OnPlayerMove();
        }

        /// <summary>
        /// travel south
        /// </summary>
        public void MoveSouth()
        {
            _gameMap.MoveSouth();
            CurrentLocation = _gameMap.CurrentLocation;
			UpdateAvailableTravelPoints();
			OnPlayerMove();
        }

        /// <summary>
        /// travel west
        /// </summary>
        public void MoveWest()
        {
            _gameMap.MoveWest();
            CurrentLocation = _gameMap.CurrentLocation;
			UpdateAvailableTravelPoints();
			OnPlayerMove();
        }

        #endregion

        #region ACTION METHODS

        public void AddItemToInventory()
        {
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
            }
        }

        public void RemoveItemFromInventory()
        {
            if (_currentGameItem != null)
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                OnPlayerPutDown(selectedGameItem);
            }
        }

        public void AddNpcToCrew()
        {
            if (_currentNpc != null && _currentLocation.Npcs.Contains(_currentNpc))
            {
                Npc selectedNpc = _currentNpc as Npc;

                _currentLocation.RemoveNpcFromLocation(selectedNpc);
                _player.AddNpcsToCrew(selectedNpc);
            }
        }



        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.Exp += gameItem.Exp;
        }

        private void OnPlayerPutDown(GameItem gameItem)
        {
        }

        public void OnUseGameItem()
        {
            switch (_currentGameItem)
            {
                case Food food:
                    ProcessFoodUse(food);
                    break;
                case Ship ship:
                    ProcessShipUse(ship);
                    UpdateAvailableTravelPoints();
                    break;
                default:
                    break;
            }
        }

        private void ProcessFoodUse(Food currentFood)
        {
            _player.Health += currentFood.HealthChange;
            _player.RemoveGameItemFromInventory(_currentGameItem);
            CurrentLocationInformation = currentFood.UseMessage;
        }

        private void ProcessShipUse(Ship currentShip)
        {

            string message;

            switch (currentShip.UseAction)
            {
                case Ship.UseActionType.OPENLOCATION:
                    message = _gameMap.OpenLocationsByShip(currentShip.Id);
                    CurrentLocationInformation = currentShip.UseMessage;
                    break;
                case Ship.UseActionType.CREWNEEDED:
                    CheckForCrew(currentShip);
                    break;
                default:
                    break;
            }
        }

        private void CheckForCrew(Ship currentShip)
        {
            if (_player.CountCrew())
            {
                currentShip.UseAction = Ship.UseActionType.OPENLOCATION;
                currentShip.UseMessage = "You are able to sail to a new Island.";
                ProcessShipUse(currentShip);
            }
            else
            {
                CurrentLocationInformation = currentShip.UseMessage;
            }
        }

        public void OnPlayerTalkTo()
        {
            if (CurrentNpc != null && CurrentNpc is ISpeak)
            {
                ISpeak speakingNpc = CurrentNpc as ISpeak;
                CurrentLocationInformation = speakingNpc.Speak();
            }
        }

        public void OnShrineTalkTo()
        {
            if (CurrentShrine != null && CurrentShrine is ISpeak)
            {
                ISpeak speakingShrine = CurrentShrine as ISpeak;
                CurrentLocationInformation = speakingShrine.Speak();
            }
        }

        public void OnPlayerRecruit()
        {
            if (CurrentNpc != null && CurrentNpc is IRecruit)
            {
                IRecruit recruitingNpc = CurrentNpc as IRecruit;
                if (recruitingNpc.WillRecruit(CurrentNpc.Race, Player.Race))
                {
                    AddNpcToCrew();
                }
                else
                {
                    CurrentLocationInformation = "Your recruitment was rejected.";
                }

            }
        }

        public void OnInteractWithShrine()
        {
            if (CurrentShrine != null)
            {
				List<GameItem> itemsNeededForShrine = GameData.ItemsNeededForShrine();
                List<GameItem> locationGameItems = CurrentLocation.GameItems.ToList();

                int ItemCount = 0;
				foreach (GameItem gameItem in itemsNeededForShrine)
				{
                    foreach (GameItem locationGameItem in locationGameItems)
                    {
                        if (gameItem.Id == locationGameItem.Id)
                        {
                            ItemCount ++;
                        }
                    }
				}

				if (ItemCount == 5)
				{
					GiveTreasure(CurrentShrine);
                    CurrentLocationInformation = "You have recieved a chest that contains enough gold to live 1000 life times.";
                    OnPlayerWins("You have completed the game.");
				}
				else
				{
					CurrentLocationInformation = "The shrine is not pleased with your offering and consumes a part of your life";
                    _player.Health = _player.Health - 10;
                    if (_player.Health <= 0)
                    {
                        _player.Lives = _player.Lives - 1;
                        _player.Health = _player.Health + 100;
                    }
                    if (_player.Lives <= 0)
                    {
                        CurrentLocationInformation = "The curse has consumed your soul. You colapse to the ground.";
                        OnPlayerDies("You have been consumed by the curse.");
                    }
                }

			}
        }

        private void GiveTreasure(Shrine CurrentShrine)
        {
            _player.AddShrineTreasureToInventory(CurrentShrine);
        }

        private void QuiteApplication()
        {
            Environment.Exit(0);
        }

        private void OnPlayerDies(string message)
        {
            string messagetext = message +
                "\n\nThank you for playing.";
            
            string titleText = "Death";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);
            QuiteApplication();
        }

        private void OnPlayerWins(string message)
        {
            string messagetext = message +
                "\n\nThank you for playing";

            string titleText = "Congratulations";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);
            QuiteApplication();
        }

        #endregion

        #region HELPER METHODS

        public int DieRoll(int sides)
		{
			return random.Next(1, sides + 1);
		}

		public void UnableToUse()
		{
			CurrentLocationInformation = "Cannot Use Selected Item.";
		}

		public void UnableToRecruit()
		{
			CurrentLocationInformation = "Cannot Recruit Selected Item.";
		}

		public void UnableToPickUp()
		{
			CurrentLocationInformation = "Cannot Pick Up Selected Item.";
		}

		public void UnableToInteract()
		{
			CurrentLocationInformation = "Cannot Interact with Selected Item.";
		}

		public void UnableToTalkTo()
		{
			CurrentLocationInformation = "Cannot Talk To with Selected Item.";
		}

		public void UnableToPutDown()
		{
			CurrentLocationInformation = "Cannot Put Down Selected Item.";
		}

		#endregion

		#endregion
	}
}
